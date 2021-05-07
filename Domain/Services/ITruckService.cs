using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ITruckService
    {
        Task<Truck> GetTruckByIdAsync(int truckId);
        Task<IList<Truck>> GetTrucksAsync();
        Task<Truck> AddTruckAsync(Truck truck);
        Task<IEnumerable<TruckModel>> GetTruckModelsAsync();
        Task DeleteTruckAsync(int id);
        Task<Truck> UpdateTruckAsync(int id, Truck truckToUpdate);
    }
}
