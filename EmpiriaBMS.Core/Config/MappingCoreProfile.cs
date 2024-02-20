using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Config;

public class MappingCoreProfile : Profile
{
    public MappingCoreProfile()
    {
        CreateMap<OtherDto, Other>().ReverseMap();
        CreateMap<DrawDto, Draw>().ReverseMap();
        CreateMap<InvoiceDto, Invoice>().ReverseMap();
        CreateMap<RoleDto, Role>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<DisciplineDto, Discipline>().ReverseMap();
        CreateMap<ProjectDto, Project>().ReverseMap();
    }
}
