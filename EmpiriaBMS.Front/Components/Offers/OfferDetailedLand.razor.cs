using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.Offers;

public partial class OfferDetailedLand
{
    private bool _isNew = true;
    private bool _loading = false;

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

    private bool _contractTabEnable => Offer.ResultId == Results.FirstOrDefault(r => r.Name.Equals("SUCCESSFUL"))?.Id;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            TabMenuClick(0);

            Offer.PropertyChanged += Offer_PropertyChanged;

            StateHasChanged();
        }
    }

    private void Offer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        switch(e.PropertyName)
        {
            case nameof(Offer.ResultId):
                StateHasChanged();
                break;
        }
    }

    private async Task _offerSave()
    {
        _loading = true;
        // TODO: Save Offer
        await Task.Delay(1000);
        TabMenuClick(1);
        _loading = false;
    }

    private async Task _contractSave()
    {
        _loading = true;
        // TODO: Save Contract
        await Task.Delay(1000);
        TabMenuClick(2);
        _loading = false;
    }

    private async Task _projectSave()
    {
        _loading = true;
        // TODO: Save Project
        await Task.Delay(1000);
        _loading = false;
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
