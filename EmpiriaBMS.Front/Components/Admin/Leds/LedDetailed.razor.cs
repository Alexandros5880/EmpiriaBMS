using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Leds;

public partial class LedDetailed
{
    [Parameter]
    public LedVM Content { get; set; } = default!;

    [Parameter]
    public FluentDialog Dialog { get; set; } = null;

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await Prepair();
        }
    }

    public async Task Prepair(LedVM record = null)
    {
        if (record != null)
            Content = record;

        if (Content == null)
            Content = new LedVM();

        StateHasChanged();
    }

    public async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        if (Content is not null)
        {
            var dto = _mapper.Map<LedDto>(Content);
            // Save Led
            if (await _dataProvider.Leds.Any(p => p.Id == Content.Id))
            {
                var updated = await _dataProvider.Leds.Update(dto);
                Content = _mapper.Map<LedVM>(updated);
            }
            else
            {
                var updated = await _dataProvider.Leds.Add(dto);
                Content = _mapper.Map<LedVM>(updated);
            }
        }
    }

    #region Validation
    private bool validInvoice = true;
    private bool validContractualFee = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validInvoice = true;
            validContractualFee = true;

            return validInvoice && validContractualFee;
        }
        else
        {
            validInvoice = true;

            switch (fieldname)
            {
                case "Invoice":
                    validInvoice = true;
                    return validInvoice;
                case "ContractualFee":
                    validContractualFee = true;
                    return validContractualFee;

                default:
                    return true;
            }

        }
    }
    #endregion

}
