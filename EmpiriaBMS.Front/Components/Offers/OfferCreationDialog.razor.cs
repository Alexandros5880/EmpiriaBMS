using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Offers;

public partial class OfferCreationDialog : IDialogContentComponent<OfferVM>
{
    [Parameter]
    public OfferVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    private OfferDetailed _offerCompoment;
    private bool _isNew => Content?.Id == 0;
    private bool _loading = false;

    private async Task SaveAsync()
    {
        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

    private void _onOfferResultChanged((string Value, string Text) resultOption)
    {
        OfferResult result = (OfferResult)Enum.Parse(typeof(OfferResult), resultOption.Value);
        Content.Result = result;
        StateHasChanged();
    }

    private async Task _saveOffer(OfferVM offer)
    {
        _loading = true;


        //Content.LeadId = Led.Id;

        //if (valid)
        //{
        //    var dto = _mapper.Map<OfferDto>(Content);

        //    dto.Lead = null;
        //    dto.Type = null;
        //    dto.State = null;
        //    dto.Category = null;
        //    dto.SubCategory = null;

        //    // Save Offer
        //    if (await _dataProvider.Offers.Any(p => p.Id == Offer.Id))
        //    {
        //        var updated = await _dataProvider.Offers.Update(dto);
        //        if (updated != null)
        //            Content = _mapper.Map<OfferVM>(updated);
        //    }
        //    else
        //    {
        //        var updated = await _dataProvider.Offers.Add(dto);
        //        if (updated != null)
        //            Content = _mapper.Map<OfferVM>(updated);
        //    }
        //}

        _loading = false;
    }

}