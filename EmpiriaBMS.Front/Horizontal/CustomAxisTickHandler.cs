using ChartJs.Blazor.Common.Handlers;
using ChartJs.Blazor.Interop;
using Newtonsoft.Json.Linq;

namespace EmpiriaBMS.Front.Horizontal;

public class CustomAxisTickHandler : IMethodHandler<AxisTickCallback>
{
    public string MethodName => "_customAxisTickCallback";

    public string Handler(JValue value, int index, JArray values)
    {
        return _customAxisTickCallback(value, index, values);
    }

    public string _customAxisTickCallback(JValue value, int index, JArray values)
    {
        if (value != null)
        {
            DateTime dateTimeValue = value.ToObject<DateTime>();
            return $"{dateTimeValue.Day}d {dateTimeValue.Hour}h:{dateTimeValue.Minute}m:{dateTimeValue.Second}s";
        }
        else
        {
            return "--";
        }
    }
}