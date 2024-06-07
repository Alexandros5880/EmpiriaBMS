using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System;

public static class TimeSpanExtensions
{
    public static string DisplayHM(this TimeSpan time) => $"{time.Hours:D2}:{time.Minutes:D2}";

    public static string DisplayHMS(this TimeSpan time) => $"{time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}";

    public static string DisplayDHMS(this TimeSpan time) => $"{time.Days:D2} days, {time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}";
}
 