using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.SubConstructors;

public partial class SubConstructorDetailed
{
    [Parameter]
    public SubConstructorVM Content { get; set; } = default!;

    [Parameter]
    public EventCallback<SubConstructorVM> OnSave { get; set; }

    [Parameter]
    public EventCallback OnCancel { get; set; }

    [Parameter]
    public bool DisplayTitle { get; set; } = true;

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    public async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        SubConstructorDto dto = _mapper.Map<SubConstructorDto>(Content);


        if (Content.Id == 0)
        {
            var added = await _dataProvider.SubConstructors.Add(dto);
            await OnSave.InvokeAsync(_mapper.Map<SubConstructorVM>(added));
        }
        else
        {
            var updated = await _dataProvider.SubConstructors.Update(dto);
            await OnSave.InvokeAsync(_mapper.Map<SubConstructorVM>(updated));
        }
    }

    public async Task CancelAsync() => await OnCancel.InvokeAsync();

    #region Validation
    private bool validName = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validName = !string.IsNullOrEmpty(Content.Name);

            return validName;
        }
        else
        {
            validName = true;

            switch (fieldname)
            {
                case "Name":
                    validName = !string.IsNullOrEmpty(Content.Name);
                    return validName;
                default:
                    return true;
            }

        }
    }
    #endregion
}
