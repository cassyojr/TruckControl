using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using Domain.Entities;
using Infrastructure.Interfaces.Repository;

namespace Application.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<IList<Truck>> GetTrucksAsync()
        {
            return await _truckRepository.GetTrucksAsync();
        }
    }
}
