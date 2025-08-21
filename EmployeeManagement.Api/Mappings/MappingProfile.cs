using AutoMapper;
using EmployeeManagement.Api.DTO;
using EmployeeManagement.Api.Models;

namespace EmployeeManagement.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }        
    }
}