﻿using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Services.GooglePlaces.ViewModels;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Config;

public class MappingCoreProfile : Profile
{
    public MappingCoreProfile()
    {
        CreateMap<SupportiveWorkDto, SupportiveWork>().ReverseMap();
        CreateMap<DeliverableDto, Deliverable>().ReverseMap();
        CreateMap<InvoiceDto, Invoice>().ReverseMap();
        CreateMap<PermissionDto, Permission>().ReverseMap();
        CreateMap<RoleDto, Role>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<DisciplineDto, Discipline>().ReverseMap();
        CreateMap<ProjectDto, Project>().ReverseMap();
        CreateMap<ProjectCategoryDto, ProjectCategory>().ReverseMap();
        CreateMap<SupportiveWorkTypeDto, SupportiveWorkType>().ReverseMap();
        CreateMap<DeliverableTypeDto, DeliverableType>().ReverseMap();
        CreateMap<DisciplineTypeDto, DisciplineType>().ReverseMap();
        CreateMap<PermissionDto, Permission>().ReverseMap();
        CreateMap<IssueDto, Issue>().ReverseMap();
        CreateMap<PaymentDto, Payment>().ReverseMap();
        CreateMap<DocumentDto, Document>().ReverseMap();
        CreateMap<InvoiceTypeDto, InvoiceType>().ReverseMap();
        CreateMap<PaymentTypeDto, PaymentType>().ReverseMap();
        CreateMap<ProjectStageDto, ProjectStage>().ReverseMap();
        CreateMap<ProjectSubCategoryDto, ProjectSubCategory>().ReverseMap();
        CreateMap<AddressDto, Address>().ReverseMap();
        CreateMap<ClientDto, Client>().ReverseMap();
        CreateMap<OfferTypeDto, OfferType>().ReverseMap();
        CreateMap<OfferStateDto, OfferState>().ReverseMap();
        CreateMap<OfferDto, Offer>().ReverseMap();
        CreateMap<EmailDto, Email>().ReverseMap();
        CreateMap<DisciplineEngineerDto, DisciplineEngineer>().ReverseMap();
        CreateMap<TeamsRequestedUserDto, TeamsRequestedUser>().ReverseMap();
        CreateMap<ExpensesTypeDto, ExpensesType>().ReverseMap();
        CreateMap<SubConstructorDto, SubConstructor>().ReverseMap();

        // ViewModels
        CreateMap<Address, AddressVM>().ReverseMap();
    }
}
