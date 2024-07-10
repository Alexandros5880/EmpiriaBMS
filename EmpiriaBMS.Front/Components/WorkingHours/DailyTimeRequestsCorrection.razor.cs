using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.WorkingHours;

public partial class DailyTimeRequestsCorrection
{
    [Parameter]
    public int RequestCount { get; set; }

    [Parameter]
    public Dictionary<Type, List<DailyTimeRequest>> DailyRequests { get; set; }
}
