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
        CreateMap<Invoice, InvoiceDto>();
        CreateMap<InvoiceDto, Invoice>();

        CreateMap<Project, ProjectDto>();
        CreateMap<ProjectDto, Project>();

        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();

        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}
