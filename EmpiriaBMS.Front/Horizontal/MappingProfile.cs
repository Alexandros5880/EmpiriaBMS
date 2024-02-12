using AutoMapper;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaMS.Models.Models;
using System;
using System.Linq;
using System.Reflection;
using EmpiriaMS.Models.Models.Base;

namespace EmpiriaBMS.Front.Horizontal;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerVM>();
        CreateMap<CustomerVM, Customer>();

        CreateMap<Employee, EmployeeVM>();
        CreateMap<EmployeeVM, Employee>();

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