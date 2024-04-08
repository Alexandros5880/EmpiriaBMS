using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System;

public static class TimeSpanExtensions
{
    public static string Display(this TimeSpan date) => date.ToString(@"hh\:mm");
}
