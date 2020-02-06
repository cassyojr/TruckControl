using AutoMapper;
using Domain.Entities;
using TruckControl.Models;

namespace TruckControl.Mapper
{
    public class ViewModelDomainProfile : Profile
    {
        public ViewModelDomainProfile()
        {
            CreateMap<RegisterTruckViewModel, Truck>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.TruckName))
                .ForMember(x => x.TruckModelId, opt => opt.MapFrom(x => x.TruckModelId));
        }
    }
}
