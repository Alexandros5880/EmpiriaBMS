using AutoMapper;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaMS.Models.Models;
using System;
using System.Linq;
using System.Reflection;
using EmpiriaBMS.Models.Models;
using EmpiriaBMS.Front.ViewModel.Components.Projects;

namespace EmpiriaBMS.Front.Horizontal;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Invoice, InvoiceVM>();
        CreateMap<InvoiceVM, Invoice>();

        CreateMap<Project, ProjectVM>();
        CreateMap<ProjectVM, Project>();

        CreateMap<Role, RoleVM>();
        CreateMap<RoleVM, Role>();

        CreateMap<User, UserVM>();
        CreateMap<UserVM, User>();
    }
}