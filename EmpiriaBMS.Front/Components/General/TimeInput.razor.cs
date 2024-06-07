using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EmpiriaBMS.Front.Components.General;

public partial class TimeInput : ComponentBase
{
    public string HoursId { get; set; }
    public string MinutesId { get; set; }

    [Parameter]
    public TimeSpan Time { get; set; }

    private TimeSpan _minTime = new TimeSpan(0, 0, 0, 0);
    [Parameter]
    public TimeSpan MinTime
    {
        get => _minTime;
        set
        {
            if (value == _minTime) return;
            _minTime = value;
        }
    }

    private TimeSpan _maxTime = new TimeSpan(0, 23, 60, 0);
    [Parameter]
    public TimeSpan MaxTime
    {
        get => _maxTime;
        set
        {
            if (value == _maxTime) return;
            _maxTime = value;
        }
    }

    [Parameter]
    public EventCallback<TimeSpan> OnPropertyChanged { get; set; }

    private TimeSpan _remainingTime;

    private int _prevHours;
    private int _hours;
    public int Hours
    {
        get => _hours;
        set
        {
            value = value > (int)_remainingTime.TotalHours ? (int)_remainingTime.TotalHours : value;
            value = value < (int)MinTime.TotalHours ? (int)MinTime.TotalHours : value;
            _hours = value;

            var time = TimeSpan.FromHours(_hours - _prevHours);
            _prevHours = _hours;
            Time = Time.Add(time);

            OnPropertyChanged.InvokeAsync(Time);
        }
    }

    private int _prevMinutes;
    private int _minutes;
    public int Minutes
    {
        get => _minutes;
        set
        {
            value = value > (int)_remainingTime.TotalMinutes ? (int)_remainingTime.TotalMinutes : value;
            value = value < (int)MinTime.TotalMinutes ? (int)MinTime.TotalMinutes : value;

            value = value >= 60 ? 60 : value;
            value = value <= 0 ? 0 : value;

            if (value <= 60 && value >= 0)
            {
                _minutes = value;

                var time = TimeSpan.FromMinutes(_minutes - _prevMinutes);
                _prevMinutes = _minutes;
                Time = Time.Add(time);

                OnPropertyChanged.InvokeAsync(Time);
            }
        }
    }

    protected override void OnInitialized()
    {
        Guid h = Guid.NewGuid();
        HoursId = Convert.ToBase64String(h.ToByteArray());

        Guid m = Guid.NewGuid();
        MinutesId = Convert.ToBase64String(m.ToByteArray());

        base.OnInitialized();
        _remainingTime = MaxTime;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            DotNetObjectReference<TimeInput> objRef = DotNetObjectReference.Create(this);
            await MicrosoftTeams.RegisterGlobalMouseWheelEvent(objRef, HoursId);
            await MicrosoftTeams.RegisterGlobalMouseWheelEvent(objRef, MinutesId);
        }
    }

    [JSInvokable("OnMouseWheel")]
    public void OnMouseWheel(double deltaY, string type)
    {
        int value = (int)deltaY;

        if (type == "hours")
        {
            if (value < 0)
                Hours = Hours + 1;
            else
                Hours = Hours - 1;
        }

        else if (type == "minutes")
        {
            if (value < 0)
                Minutes = Minutes + 1;
            else
                Minutes = Minutes - 1;
        }

        StateHasChanged();
    }
}
