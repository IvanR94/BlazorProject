using AppBroker.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppBroker
{
    public interface IBroker
    {
        Task<List<T>> LoadData<T>(string sql, object parameters = null);
        bool ManageData(string sql, object parameters = null);
        bool AddDataTransaction(JsonElement json, List<DefectiveItems> defectiveItemsList);
        bool UpdateDataTransaction(JsonElement jsonElement);
    }
}