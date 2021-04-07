using AutoMapper;
using DCDomain.Models;
using DCWebAPI.ViewModels;

namespace DCWebAPI.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}