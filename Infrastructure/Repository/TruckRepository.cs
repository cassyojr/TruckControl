using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repository;
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
                .OrderByDescending(x => x.TruckId)
                .ToListAsync();
        }
    }
}
