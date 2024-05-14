using AppBroker.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppBroker.Data
{
    public interface ITechnicalReportData
    {
        Task<List<TechnicalReportModel>> GetTechnicalReports();
        Task<List<EmployeeModel>> GetAllEmployees();
        Task<List<TechnicalInspectionTypeModel>> GetAllTechnicalTypes();
        bool UpdateTechnicalRepor(JsonElement jsonElement);
        bool DeleteTechReport(int id);
        //bool AddNewTechReport(JsonElement jsonElement, List<DefectiveItems> defectiveItemsList);
        bool AddNewTechReportTransaction(JsonElement jsonElement, List<DefectiveItems> defectiveItemsList);

    }
}