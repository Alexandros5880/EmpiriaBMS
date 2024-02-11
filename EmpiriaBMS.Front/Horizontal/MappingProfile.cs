using AutoMapper;
using EmpiriaBMS.Front.ViewModels;
using EmpiriaMS.Models.Models;
using System;
using System.Linq;
using System.Reflection;

namespace EmpiriaBMS.Front.Horizontal;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();
    }
}