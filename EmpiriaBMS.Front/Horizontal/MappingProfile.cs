﻿using AutoMapper;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Models.Models;
using EmpiriaBMS.Front.ViewModel;

namespace EmpiriaBMS.Front.Horizontal;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DeliverableDto, DeliverableVM>().ReverseMap();
        CreateMap<InvoiceDto, InvoiceVM>().ReverseMap();
        CreateMap<RoleDto, RoleVM>().ReverseMap();
        CreateMap<UserDto, UserVM>().ReverseMap();
        CreateMap<SupportiveWorkDto, SupportiveWorkVM>().ReverseMap();
        CreateMap<DisciplineDto, DisciplineVM>().ReverseMap();
        CreateMap<ProjectDto, ProjectVM>().ReverseMap();
        CreateMap<ProjectCategoryDto, ProjectCategoryVM>().ReverseMap();
        CreateMap<SupportiveWorkTypeDto, SupportiveWorkTypeVM>().ReverseMap();
        CreateMap<DeliverableTypeDto, DeliverableTypeVM>().ReverseMap();
        CreateMap<DisciplineTypeDto, DisciplineTypeVM>().ReverseMap();
        CreateMap<PermissionDto, PermissionVM>().ReverseMap();
        CreateMap<IssueDto, IssueVM>().ReverseMap();
        CreateMap<PaymentDto, PaymentVM>().ReverseMap();
        CreateMap<DocumentDto, DocumentVM>().ReverseMap();
        CreateMap<InvoiceTypeDto, InvoiceTypeVM>().ReverseMap();
        CreateMap<PaymentTypeDto, PaymentTypeVM>().ReverseMap();
        CreateMap<ProjectStageDto, ProjectStageVM>().ReverseMap();
        CreateMap<ProjectSubCategoryDto, ProjectSubCategoryVM>().ReverseMap();
        CreateMap<ClientDto, ClientVM>().ReverseMap();
        CreateMap<OfferTypeDto, OfferTypeVM>().ReverseMap();
        CreateMap<OfferStateDto, OfferStateVM>().ReverseMap();
        CreateMap<OfferDto, OfferVM>().ReverseMap();
        CreateMap<TeamsRequestedUserDto, TeamsRequestedUserVM>().ReverseMap();
        CreateMap<ExpensesTypeDto, ExpensesTypeVM>().ReverseMap();
        CreateMap<SubConstructorDto, SubConstructorVM>().ReverseMap();
    }
}