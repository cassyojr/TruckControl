using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces.Repository;
using Infrastructure.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TruckRepository : GenericRepositoryAsync<Truck>, ITruckRepository
    {
        public TruckRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IList<Truck>> GetTrucksAsync()
        {
            return await _unitOfWork.Context.Truck
                .Include(x => x.TruckModel)
                .ToListAsync();
        }
    }
}
