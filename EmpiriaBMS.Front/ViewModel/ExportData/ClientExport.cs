﻿using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class ClientExport : IInport<ClientVM>
{
    public string CompanyName { get; set; }

    public int AddressId { get; set; }

    public string Address { get; set; }

    public string ProxyAddress { get; set; }

    public string PasswordHash { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string MidName { get; set; }

    public string TeamsObjectId { get; set; }

    public string Phone1 { get; set; }

    public string Phone2 { get; set; }

    public string Phone3 { get; set; }

    public string Description { get; set; }

    public ClientExport(ClientVM model)
    {
        CompanyName = model.CompanyName;
        AddressId = model.AddressId ?? 0;
        Address = model.Address?.FormattedAddress ?? "";
        ProxyAddress = model.ProxyAddress;
        PasswordHash = model.PasswordHash ?? "";
        LastName = model.LastName;
        MidName = model.MidName ?? "";
        FirstName = model.FirstName;
        TeamsObjectId = model.TeamsObjectId ?? "";
        Phone1 = model.Phone1;
        Phone2 = model.Phone2 ?? "";
        Phone3 = model.Phone3 ?? "";
        Description = model.Description ?? "";
    }

    public ClientExport()
    {

    }

    public ClientVM Get() => new ClientVM()
    {
        CompanyName = CompanyName,
        AddressId = AddressId,
        ProxyAddress = ProxyAddress,
        PasswordHash = PasswordHash,
        LastName = LastName,
        MidName = MidName,
        FirstName = FirstName,
        TeamsObjectId = TeamsObjectId,
        Phone1 = Phone1,
        Phone2 = Phone2,
        Phone3 = Phone3,
        Description = Description,
    };
}
