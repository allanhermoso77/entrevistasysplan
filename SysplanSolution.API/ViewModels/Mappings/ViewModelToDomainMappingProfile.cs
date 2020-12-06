using AutoMapper;
using SysplanSolution.Model;
using System.Collections.Generic;

namespace SysplanSolution.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
        }
    }
}
