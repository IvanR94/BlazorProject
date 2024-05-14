using AppBroker.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;

namespace AppBroker
{
    public class Broker : IBroker
    {
        private readonly IConfiguration _config;

        public Broker(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnString(string name)
        {
            return _config.GetConnectionString(name);
        }
        
        public async Task<List<T>> LoadData<T>(string storeProcedure, object parameters = null)
        {
            string connectionString = GetConnString("LocalDB");

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var data = await connection.QueryAsync<T>(storeProcedure, parameters);
                    return data.ToList();
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }

        public bool ManageData(string storeProcedure, object parameters = null)
        {
            string connectionString = GetConnString("LocalDB");

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var result = connection.Execute(storeProcedure, parameters);
                    return result > 0;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }

        public void TransactionManageData(IDbTransaction transaction, string storeProcedure, object parameters = null)
        {
            try
            {
                var result = transaction.Connection.Execute(storeProcedure, parameters, transaction);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public int TransactionGetID(IDbConnection connection, IDbTransaction transaction, string storeProcedure)
        {
            try
            {
                int maxID = connection.QueryFirstOrDefault<int>(storeProcedure, commandType: CommandType.StoredProcedure, transaction: transaction);

                return maxID;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public bool AddDataTransaction(JsonElement json, List<DefectiveItems> defectiveItemsList)
        {
            var idZaposlenog = Convert.ToInt32(json.GetProperty("EmployeeId").GetString());
            var idTipTehnickog = Convert.ToInt32(json.GetProperty("TehnicalTypeID").GetString());
            var datumTehnickog = Convert.ToDateTime(json.GetProperty("DateOfTechReport").GetString());
            var statusTehnickog = Convert.ToBoolean(json.GetProperty("IsPass").GetString());
            var marka = json.GetProperty("MarkaJson").GetString();
            var model = json.GetProperty("ModelJson").GetString();
            var godiste = Convert.ToInt32(json.GetProperty("GodisteJson").GetString());
            var imeVlasnika = json.GetProperty("ImeVlasnikaJson").GetString();
            var prezimeVlasnika = json.GetProperty("PrezimeVlasnikaJson").GetString();

            if (!statusTehnickog)
            {
                var connectionString = GetConnString("LocalDB");

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            TransactionManageData(transaction, "dbo.Add_New_Tech_Report @ZaposleniID, @TipTehnickogPregledaID, @DatumVrsenjaTehnickogPregleda, @StatusTehnickogPregleda, @MarkaVozila, @ModelVozila, @Godiste, @ImeVlasnika, @PrezimeVlasnika", new { ZaposleniID = idZaposlenog, TipTehnickogPregledaID = idTipTehnickog, DatumVrsenjaTehnickogPregleda = datumTehnickog, StatusTehnickogPregleda = statusTehnickog, MarkaVozila = marka, ModelVozila = model, Godiste = godiste, ImeVlasnika = imeVlasnika, PrezimeVlasnika = prezimeVlasnika });

                            var id = TransactionGetID(connection, transaction, "dbo.Get_Max_ID_From_Tech_Report");

                            foreach (var item in defectiveItemsList)
                            {
                               TransactionManageData(transaction, "dbo.Add_New_Defective_Item @TechReportID ,@NazivStavke, @OpisStavke", new { TechReportID = id, NazivStavke = item.NazivNeispravnogDela, OpisStavke = item.OpisNeispravnosti });
                            }
                            transaction.Commit();
                            connection.Close();
                            return true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            connection.Close();
                            return false;
                        }
                    }
                }
            }
            else
            {
                return ManageData("dbo.Add_New_Tech_Report @ZaposleniID, @TipTehnickogPregledaID, @DatumVrsenjaTehnickogPregleda, @StatusTehnickogPregleda, @MarkaVozila, @ModelVozila, @Godiste, @ImeVlasnika, @PrezimeVlasnika", new { ZaposleniID = idZaposlenog, TipTehnickogPregledaID = idTipTehnickog, DatumVrsenjaTehnickogPregleda = datumTehnickog, StatusTehnickogPregleda = statusTehnickog, MarkaVozila = marka, ModelVozila = model, Godiste = godiste, ImeVlasnika = imeVlasnika, PrezimeVlasnika = prezimeVlasnika });
            }
        }

        public bool UpdateDataTransaction(JsonElement jsonElement)
        {
            var connectionString = GetConnString("LocalDB");

            var idTehnickog = Convert.ToInt32(jsonElement.GetProperty("TehnickiIDJson").GetString());
            var idTipTehnickog = Convert.ToInt32(jsonElement.GetProperty("TechTypeJson").GetString());
            List<DefectiveItems> defectiveItemsList = new List<DefectiveItems>();

            JsonElement defectiveItemsArray = jsonElement.GetProperty("DefectiveItemsJson");
            foreach (JsonElement defectiveItemJson in defectiveItemsArray.EnumerateArray())
            {
                DefectiveItems defectiveItem = new DefectiveItems
                {
                    NeispravneStavkeID = defectiveItemJson.GetProperty("NeispravneStavkeID").GetInt32(),
                    BrojIzvestajaID = defectiveItemJson.GetProperty("BrojIzvestajaID").GetInt32(),
                    NazivNeispravnogDela = defectiveItemJson.GetProperty("NazivNeispravnogDela").GetString(),
                    OpisNeispravnosti = defectiveItemJson.GetProperty("OpisNeispravnosti").GetString()
                };
                defectiveItemsList.Add(defectiveItem);
            }

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        TransactionManageData(transaction, "dbo.Delete_all_item_for_techReport @IDTehnickog", new { IDTehnickog = idTehnickog });

                        TransactionManageData(transaction, "dbo.Update_Technical_Report @IDTehnickog, @TipTehnickogID", new { IDTehnickog = idTehnickog, TipTehnickogID = idTipTehnickog });

                        foreach (var item in defectiveItemsList)
                        {
                            TransactionManageData(transaction, "dbo.Add_New_Defective_Item @TechReportID ,@NazivStavke, @OpisStavke", new { TechReportID = idTehnickog, NazivStavke = item.NazivNeispravnogDela, OpisStavke = item.OpisNeispravnosti });
                        }
                        transaction.Commit();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        connection.Close();
                        return false;
                    }
                }
            }
        }
    }
}
