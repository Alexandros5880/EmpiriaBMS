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

    private string _customAxisTickCallback(JValue value, int index, JArray values)
    {
        return value?.ToString() ?? "--";
    }

    public string GenerateJavascript()
    {
        return @"
            function(value, index, values) {
                var ticks = value;
                var totalSeconds = ticks / 10000000; // Convert ticks to seconds
                var days = Math.floor(totalSeconds / 86400);
                totalSeconds %= 86400;
                var hours = Math.floor(totalSeconds / 3600);
                totalSeconds %= 3600;
                var minutes = Math.floor(totalSeconds / 60);
                var seconds = totalSeconds % 60;
                return days + 'd ' + hours + 'h:' + minutes + 'm:' + seconds + 's';
            }
        ";
    }
}