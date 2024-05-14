using AppBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppBroker.Data
{
    public class TechnicalReportData : ITechnicalReportData
    {
        private readonly IBroker _broker;
        public TechnicalReportData(IBroker broker)
        {
            _broker = broker;
        }

        public bool AddNewTechReportTransaction(JsonElement json, List<DefectiveItems> defectiveItemsList)
        {
            return _broker.AddDataTransaction(json, defectiveItemsList);
        }

        public bool DeleteTechReport(int id)
        {
            return _broker.ManageData("dbo.Delete_Tech_Report @IzvestajTehnickogID", new { IzvestajTehnickogID = id });
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            return await _broker.LoadData<EmployeeModel>("dbo.Get_All_Employees");
        }

        public async Task<List<TechnicalInspectionTypeModel>> GetAllTechnicalTypes()
        {
            return await _broker.LoadData<TechnicalInspectionTypeModel>("dbo.Get_All_Technical_Inspection_Type");
        }

        public async Task<List<TechnicalReportModel>> GetTechnicalReports()
        {
            var techReports = await _broker.LoadData<TechnicalReportModel>("dbo.Get_All_TechReport");
            foreach(var item in techReports)
            {
                var defectiveItems = await _broker.LoadData<DefectiveItems>("dbo.Get_Defective_Items_For_Report @TechReportID", new { TechReportID = item.BrojIzvestajaID });
                item.DefectiveItemsList = defectiveItems;
            }
            return techReports;
        }

        public bool UpdateTechnicalRepor(JsonElement jsonElement)
        {
            return _broker.UpdateDataTransaction(jsonElement);
        }
    }
}
