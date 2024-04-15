using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System;

public static class TimeSpanExtensions
{
    public static string DisplayHM(this TimeSpan date) => date.ToString(@"hh\:mm");

    public static string DisplayHMS(this TimeSpan time) => time.ToString(@"hh\\:mm\\:ss");
}
