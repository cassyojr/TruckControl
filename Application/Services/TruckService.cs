using Domain.Entities;
using Domain.Repository;
using Domain.Services;
using Infrastructure.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;
        private readonly ITruckModelRepository _truckModelRepository;
        private readonly IUnitOfWork _uow;

        public TruckService(IUnitOfWork uow, ITruckRepository truckRepository, ITruckModelRepository truckModelRepository)
        {
            _truckRepository = truckRepository;
            _truckModelRepository = truckModelRepository;
            _uow = uow;
        }

        public async Task<Truck> AddTruckAsync(Truck truck)
        {
            //Unity of work added just to show db transaction control on the repository pattern
            //It's not needed on only one repository call
            _uow.BeginTransaction();

            truck.ProductionYear = DateTime.Now.Year;
            truck.CreationDate = DateTime.Now;
            truck = await _truckRepository.AddAsync(truck);

            await _uow.CommitAsync();

            return truck;
        }

        public async Task DeleteTruckAsync(int id)
        {
            await _truckRepository.DeleteAsync(id);
        }

        public async Task<Truck> GetTruckByIdAsync(int truckId)
        {
            return await _truckRepository.GetByIdAsync(truckId);
        }

        public async Task<IEnumerable<TruckModel>> GetTruckModelsAsync()
        {
            return await _truckModelRepository.GetAllAsync();
        }

        public async Task<IList<Truck>> GetTrucksAsync()
        {
            return await _truckRepository.GetTrucksAsync();
        }

        public async Task<Truck> UpdateTruckAsync(int id, Truck truckToUpdate)
        {
            var truck = await _truckRepository.GetByIdAsync(id);
            truck.Name = truckToUpdate.Name;
            truck.ModelYear = truckToUpdate.ModelYear;
            truck.TruckModelId = truckToUpdate.TruckModelId;

            return await _truckRepository.UpdateAsync(truck);
        }
    }
}
