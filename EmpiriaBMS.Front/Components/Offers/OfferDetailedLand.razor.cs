using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.Offers;

public partial class OfferDetailedLand
{
    private bool _isNew = true;

    private OfferVM _offer;
    [Parameter]
    public OfferVM Offer
    {
        get => _offer;
        set
        {
            _offer = value;
            _isNew = _offer.Id == 0;
        }
    }

    [Parameter]
    public ICollection<OfferTypeVM> Types { get; set; }

    [Parameter]
    public ICollection<OfferStateVM> States { get; set; }

    [Parameter]
    public ICollection<OfferResultVM> Results { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    [Parameter]
    public EventCallback OnCansel { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            TabMenuClick(0);
            StateHasChanged();
        }
    }

    #region Tab Actions
    bool[] tabs = new bool[50];

    private void TabMenuClick(int tabIndex)
    {
        for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
        tabs[tabIndex] = true;
    }
    #endregion
}
