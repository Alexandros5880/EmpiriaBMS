﻿using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;
using EmpiriaBMS.Models.Enum;
using System.Globalization;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class InvoiceExport : IInport<InvoiceVM>
{
    public long TypeId { get; set; }
    public string TypeName { get; set; }
    public double Total { get; set; }
    public int Vat { get; set; }
    public double Fee { get; set; }
    public string EstimatedDate { get; set; }
    public int InvoiceNumber { get; set; }
    public string Mark { get; set; }
    public long ProjectId { get; set; }
    public string ProjectCode { get; set; }
    public string ProjectName { get; set; }
    public string ProjectPM { get; set; }

    public InvoiceExport(InvoiceVM model)
    {
        TypeId = model.TypeId;
        TypeName = model.Type?.Name ?? "";
        Total = model.Total;
        Vat = Convert.ToInt32(model.Vat);
        Fee = model.Fee;
        EstimatedDate = model.EstimatedPayment?.ToEuropeFormat() ?? "";
        InvoiceNumber = model.InvoiceNumber ?? 0;
        Mark = model.Mark ?? "";
        ProjectId = model.ProjectId;
        ProjectCode = model.Project?.Code ?? "";
        ProjectName = model.Project?.Name ?? "";
        ProjectPM = model.Project?.ProjectManager?.FirstName ?? "";
    }

    public InvoiceExport()
    {

    }

    public InvoiceVM Get()
    {
        DateTime? date;
        try
        {
            string format = "dd-MM-yyyy"; //  MM-dd-yyyy hh:mm:ss tt
            date = DateTime.ParseExact(EstimatedDate, format, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            date = null;
        }

        return new InvoiceVM()
        {
            TypeId = TypeId,
            Vat = 24,
            Fee = Fee,
            EstimatedPayment = date,
            InvoiceNumber = InvoiceNumber,
            Mark = Mark,
            ProjectId = ProjectId,
        };
    }
}
