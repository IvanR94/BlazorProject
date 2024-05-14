using AppBroker.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppBroker.Data
{
    public class VehicleData : IVehicleData
    {
        private readonly IBroker _broker;

        public VehicleData(IBroker broker)
        {
            _broker = broker;
        }

        public async Task<List<VehicleModel>> GetVehicles()
        {
            try
            {
                return await _broker.LoadData<VehicleModel>("dbo.Get_All_Vehicles");
            }
            catch (Exception)
            {
                return new List<VehicleModel>();
            }
        }

        public bool UpdateVehicle(JsonElement jsonObject)
        {
            try
            {
                var id = Convert.ToInt32(jsonObject.GetProperty("VehicleIDJson").GetString());
                var marka = jsonObject.GetProperty("MarkaJson").GetString();
                var model = jsonObject.GetProperty("ModelJson").GetString();
                var godiste = Convert.ToInt32(jsonObject.GetProperty("GodisteJson").GetString());
                var imePrezime = jsonObject.GetProperty("FullNameJson").GetString();

                var ime = "";
                var prezime = "";

                ime = imePrezime.Split(' ')[0];
                prezime = imePrezime.Split(' ')[1];

                return _broker.ManageData("dbo.Update_Vehicle @VoziloID, @MarkaVozila, @ModelVozila, @GodisteVozila, @ImeVlasnika, @PrezimeVlasnika", new { VoziloID = id, MarkaVozila = marka, ModelVozila = model, GodisteVozila = godiste, ImeVlasnika = ime, PrezimeVlasnika = prezime });
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteVehicle(int id)
        {
            try
            {
                return _broker.ManageData("dbo.Delete_Vehicle @VoziloID", new { VoziloID = id });
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddNewVehicle(JsonElement jsonObject)
        {
            try
            {
                var marka = jsonObject.GetProperty("MarkaJson").GetString();
                var model = jsonObject.GetProperty("ModelJson").GetString();
                var godiste = Convert.ToInt32(jsonObject.GetProperty("GodisteJson").GetString());
                var ime = jsonObject.GetProperty("ImeJson").GetString();
                var prezime = jsonObject.GetProperty("PrezimeJson").GetString();

                return _broker.ManageData("dbo.Add_New_Vehicle @MarkaVozila, @ModelVozila, @GodisteVozila, @ImeVlasnika, @PrezimeVlasnika", new { MarkaVozila = marka, ModelVozila = model, GodisteVozila = godiste, ImeVlasnika = ime, PrezimeVlasnika = prezime });
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
