using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Services;

public class Culture
{
    private CultureInfo culture;
    private NumberFormatInfo numberFormat;

    public Culture()
    {
        culture = new CultureInfo("el-GR");
        // Customize number formatting
        numberFormat = culture.NumberFormat;
        numberFormat.CurrencyDecimalSeparator = ",";
        numberFormat.CurrencyGroupSeparator = ".";
        numberFormat.CurrencyGroupSizes = new[] { 3 }; // Group by thousands
    }

    public string GetNumberFromated(double number)
    {
        return number.ToString("C2", numberFormat);
    }
}
