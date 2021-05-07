using Domain.Entities;
using Domain.Repository;
using Infrastructure.Repository.UnitOfWork;

namespace Infrastructure.Repository
{
    public class TruckModelRepository : GenericRepositoryAsync<TruckModel>, ITruckModelRepository
    {
        public TruckModelRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
