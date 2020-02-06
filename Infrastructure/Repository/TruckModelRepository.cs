using Domain.Entities;
using Infrastructure.Interfaces.Repository;
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
