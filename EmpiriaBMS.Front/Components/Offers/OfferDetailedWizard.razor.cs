using EmpiriaBMS.Front.Components.Offers.WizardSteps;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.Offers;

public partial class OfferDetailedWizard : ComponentBase
{

    private List<RenderFragment> _steps = new List<RenderFragment>();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _steps = new List<RenderFragment>
        {
            CreateComponent(0, typeof(Step1)),
            CreateComponent(1, typeof(Step2)),
            CreateComponent(2, typeof(Step3))
        };
    }

    private RenderFragment CreateComponent(int index, Type compoment) => builder =>
    {
        builder.OpenComponent(index, compoment);
        //builder.AddAttribute(1, "PetDetailsQuote", "Someone's best friend!");
        builder.CloseComponent();
    };

}
