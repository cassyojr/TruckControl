using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ITruckService
    {
        Task<IList<Truck>> GetTrucksAsync();
    }
}
