
using System.Net;
using System.IO;
using System.Drawing;

namespace EmpiriaBMS.Core.Hellpers;

public static class ImageHelper
{
    public static string? GetImageUrl(byte[] source)
    {
        if (source != null && source.Length > 0)
        {
            return $"data:image/png;base64,{Convert.ToBase64String(source)}";
        }
        else
        {
            return null;
        }
    }
}
