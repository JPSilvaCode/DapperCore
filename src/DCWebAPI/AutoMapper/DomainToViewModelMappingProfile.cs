using AutoMapper;
using DCDomain.Models;
using DCWebAPI.ViewModels;

namespace DCWebAPI.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}