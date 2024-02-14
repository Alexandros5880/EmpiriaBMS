using AutoMapper;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaMS.Models.Models;
using System;
using System.Linq;
using System.Reflection;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.Horizontal;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, CustomerVM>();
        CreateMap<CustomerVM, User>();

        CreateMap<User, EmployeeVM>();
        CreateMap<EmployeeVM, User>();

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