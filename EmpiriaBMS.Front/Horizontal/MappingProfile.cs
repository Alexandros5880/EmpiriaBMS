using AutoMapper;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaMS.Models.Models;
using System;
using System.Linq;
using System.Reflection;
using EmpiriaBMS.Models.Models;
using EmpiriaBMS.Core.Dtos;

namespace EmpiriaBMS.Front.Horizontal;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<InvoiceDto, InvoiceVM>();
        CreateMap<InvoiceVM, InvoiceDto>();

        CreateMap<ProjectDto, ProjectVM>();
        CreateMap<ProjectVM, ProjectDto>();

        CreateMap<RoleDto, RoleVM>();
        CreateMap<RoleVM, RoleDto>();

        CreateMap<UserDto, UserVM>();
        CreateMap<UserVM, UserDto>();
    }
}