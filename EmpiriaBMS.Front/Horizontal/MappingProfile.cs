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
        CreateMap<DrawingDto, DrawingVM>().ReverseMap();
        CreateMap<InvoiceDto, InvoiceVM>().ReverseMap();
        CreateMap<RoleDto, RoleVM>().ReverseMap();
        CreateMap<UserDto, UserVM>().ReverseMap();
        CreateMap<OtherDto, OtherVM>().ReverseMap();
        CreateMap<DisciplineDto, DisciplineVM>().ReverseMap();
        CreateMap<ProjectDto, ProjectVM>().ReverseMap();
        CreateMap<ProjectTypeDto, ProjectTypeVM>().ReverseMap();
        CreateMap<OtherTypeDto, OtherTypeVM>().ReverseMap();
        CreateMap<DrawingTypeDto, DrawingTypeVM>().ReverseMap();
        CreateMap<DisciplineTypeDto, DisciplineTypeVM>().ReverseMap();
        CreateMap<PermissionDto, PermissionVM>().ReverseMap();
        CreateMap<IssueDto, IssueVM>().ReverseMap();
        CreateMap<PaymentDto, PaymentVM>().ReverseMap();
        CreateMap<DocumentDto, DocumentVM>().ReverseMap();
        CreateMap<InvoiceTypeDto, InvoiceTypeVM>().ReverseMap();
        CreateMap<PaymentTypeDto, PaymentTypeVM>().ReverseMap();
        CreateMap<ProjectStageDto, ProjectStageVM>().ReverseMap();
        CreateMap<ProjectGroupDto, ProjectGroupVM>().ReverseMap();
    }
}