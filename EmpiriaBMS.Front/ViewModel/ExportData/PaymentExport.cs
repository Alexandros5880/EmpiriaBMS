﻿using EmpiriaBMS.Front.ViewModel.Components;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class PaymentExport
{
    public string PaymentDate { get; set; }
    public string Bank { get; set; }
    public double Fee { get; set; }
    public string Description { get; set; }
    public int TypeId { get; set; }
    public string TypeName { get; set; }
    public int InvoiceId { get; set; }
    public string InvoiceMark { get; set; }
    public string InvoiceType { get; set; }
    public double InvoiceContractFee { get; set; }
    public string InvoiceContractDate { get; set; }
    public int ProjectId { get; set; }
    public string ProjectCode { get; set; }
    public string ProjectName { get; set; }
    public string ProjectPM { get; set; }

    public PaymentExport(PaymentVM model)
    {
        try
        {
            PaymentDate = model.PaymentDate?.ToEuropeFormat() ?? "";
            Bank = model.Bank ?? "";
            Fee = model.Fee;
            Description = model.Description ?? "";
            TypeId = model.TypeId;
            TypeName = model.Type.Name;
            InvoiceId = model.InvoiceId;
            InvoiceMark = model.Invoice.Mark ?? "";
            InvoiceType = model.Invoice.Type.Name;
            InvoiceContractFee = model.Invoice.Contract?.ContractualFee ?? 0;
            InvoiceContractDate = model.Invoice.Contract?.Date.ToEuropeFormat() ?? "";
            ProjectId = model.Invoice.ProjectId;
            ProjectCode = model.Invoice.Project.Code ?? "";
            ProjectName = model.Invoice.Project.Name ?? "";
            ProjectPM = model.Invoice.Project.ProjectManager?.FullName ?? "";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in PaymentExport(): {ex.Message} \n InnerException: {ex.InnerException} \n\n");
            // TODO: Log Error
        }
    }
}