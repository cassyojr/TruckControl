using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repository
{
    public interface ITruckRepository : IGenericRepositoryAsync<Truck>
    {
        Task<IList<Truck>> GetTrucksAsync();
    }
}
