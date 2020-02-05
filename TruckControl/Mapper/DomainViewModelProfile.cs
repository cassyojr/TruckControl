using AutoMapper;
using Domain.Entities;
using TruckControl.Models;

namespace TruckControl.Mapper
{
    public class DomainViewModelProfile : Profile
    {
        public DomainViewModelProfile()
        {
            CreateMap<Truck, TruckViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.TruckId))
                .ForMember(x => x.TruckName, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.TruckModelName, opt => opt.MapFrom(x => x.TruckModel.Name));
        }
    }
}
