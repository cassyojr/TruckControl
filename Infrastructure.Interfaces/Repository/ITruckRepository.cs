using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Interfaces.Repository
{
    public interface ITruckRepository : IGenericRepositoryAsync<Truck>
    {
        Task<IList<Truck>> GetTrucksAsync();
    }
}
