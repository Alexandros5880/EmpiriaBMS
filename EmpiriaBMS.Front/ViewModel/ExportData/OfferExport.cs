using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData.Interfaces;
using EmpiriaBMS.Models.Enum;
using System.Globalization;

namespace EmpiriaBMS.Front.ViewModel.ExportData;

public class OfferExport : IInport<OfferVM>
{
    public int TypeId { get; set; }

    public string TypeName { get; set; }

    public int StateId { get; set; }

    public string StateName { get; set; }

    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public int SubCategoryId { get; set; }

    public string SubCategoryName { get; set; }

    public int LedId { get; set; }

    public string LedName { get; set; }

    public string Result { get; set; }

    public string Code { get; set; }

    public string Date { get; set; }

    public double PudgetPrice { get; set; }

    public double OfferPrice { get; set; }

    public string Description { get; set; }

    public string Observations { get; set; }

    public string TeamText { get; set; }

    public string Comments { get; set; }

    public OfferExport(OfferVM model)
    {
        TypeId = model.TypeId;
        TypeName = model.TypeName;
        StateId = model.StateId;
        StateName = model.StateName;
        CategoryId = model.CategoryId ?? 0;
        CategoryName = model.Category?.Name ?? "";
        SubCategoryId = model.SubCategoryId ?? 0;
        SubCategoryName = model.SubCategory?.Name ?? "";
        LedId = model.LeadId ?? 0;
        LedName = model.Lead?.Name ?? "";
        Result = Convert.ToString(model.Result);
        Code = model.Code;
        Date = model.Date?.ToEuropeFormat() ?? "";
        PudgetPrice = model.PudgetPrice ?? 0;
        OfferPrice = model.OfferPrice ?? 0;
        Description = model.Description ?? "";
        Observations = model.Observations ?? "";
        TeamText = model.TeamText ?? "";
        Comments = model.Comments ?? "";
    }

    public OfferExport()
    {

    }

    public OfferVM Get()
    {
        DateTime? date;
        try
        {
            string format = "dd-MM-yyyy"; //  MM-dd-yyyy hh:mm:ss tt
            date = DateTime.ParseExact(Date, format, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            date = null;
        }
        return new OfferVM()
        {
            TypeId = TypeId,
            StateId = StateId,
            CategoryId = CategoryId,
            SubCategoryId = SubCategoryId,
            LeadId = LedId,
            Result = Result.GetValueFromDisplayName<OfferResult>(),
            Code = Code,
            Date = date,
            PudgetPrice = PudgetPrice,
            OfferPrice = OfferPrice,
            Description = Description,
            Observations = Observations,
            TeamText = TeamText,
            Comments = Comments,
        };
    }
}
