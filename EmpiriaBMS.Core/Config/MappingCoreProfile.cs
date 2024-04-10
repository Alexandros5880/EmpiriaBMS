using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Services.GooglePlaces.ViewModels;
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
        CreateMap<IssueDto, Issue>().ReverseMap();
        CreateMap<PaymentDto, Payment>().ReverseMap();
        CreateMap<DocumentDto, Document>().ReverseMap();
        CreateMap<InvoiceTypeDto, InvoiceType>().ReverseMap();
        CreateMap<PaymentTypeDto, PaymentType>().ReverseMap();
        CreateMap<ProjectStageDto, ProjectStage>().ReverseMap();
        CreateMap<ProjectGroupDto, ProjectGroup>().ReverseMap();
        CreateMap<AddressDto, Address>().ReverseMap();

        // ViewModels
        CreateMap<Address, AddressVM>().ReverseMap();
    }
}
