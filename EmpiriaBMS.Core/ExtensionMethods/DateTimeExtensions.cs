using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System;

public static class DateTimeExtensions
{
    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    {
        int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
        return dt.AddDays(-1 * diff).Date;
    }

    public static string ToEuropeFormat(this DateTime date) => date.ToString("dd-MM-yyyy");

    public static string ToAmericanDateFormat(this DateTime dateTime) => dateTime.ToString("MM-dd-yyyy");

    public static string ToAsianDateFormat(this DateTime dateTime) => dateTime.ToString("yyyy-MM-dd");

}
