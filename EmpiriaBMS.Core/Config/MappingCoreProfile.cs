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
        CreateMap<DrawingDto, Drawing>().ReverseMap();
        CreateMap<InvoiceDto, Invoice>().ReverseMap();
        CreateMap<PermissionDto, Permission>().ReverseMap();
        CreateMap<RoleDto, Role>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<DisciplineDto, Discipline>().ReverseMap();
        CreateMap<ProjectDto, Project>().ReverseMap();
        CreateMap<ProjectTypeDto, ProjectType>().ReverseMap();
        CreateMap<OtherTypeDto, OtherType>().ReverseMap();
        CreateMap<DrawingTypeDto, DrawingType>().ReverseMap();
        CreateMap<DisciplineTypeDto, DisciplineType>().ReverseMap();
        CreateMap<PermissionDto, Permission>().ReverseMap();
    }
}
