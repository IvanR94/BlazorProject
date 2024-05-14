using AppBroker.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppBroker.Data
{
    public interface IVehicleData
    {
        Task<List<VehicleModel>> GetVehicles();
        bool UpdateVehicle(JsonElement jsonObject);
        bool DeleteVehicle(int id);
        bool AddNewVehicle(JsonElement jsonObject);
    }
}