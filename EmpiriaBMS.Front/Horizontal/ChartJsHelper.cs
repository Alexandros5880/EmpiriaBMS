using MessagePack.Formatters;
using Microsoft.Recognizers.Text.Number.Italian;

namespace EmpiriaBMS.Front.Horizontal
{
    public static class ChartJsHelper
    {

        private static Rgb[] _previusColors;

        public static string[] GenerateColors(int count, double transparency = 1)
        {
            string[] colors = new string[count];
            _previusColors = new Rgb[count];
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                _previusColors[i] = new Rgb(r, g, b);
                colors[i] = _previusColors[i].GetRgb(transparency);
            }
            return colors;
        }

        public static string[] GenerateColors(int count, int startHue, int endHue, double transparency = 1)
        {
            if (count <= 0 || startHue < 380 || startHue > 700 || endHue < 380 || endHue > 700)
                    throw new ArgumentException("Invalid arguments");

            string[] colors = new string[count];
            _previusColors = new Rgb[count];
            double step = (endHue - startHue) / (double)count;

            for (int i = 0; i < count; i++)
            {
                double hue = startHue + step * i;
                _previusColors[i] = new Rgb(hue, 1.0, 1.0);
                colors[i] = _previusColors[i].GetRgb(transparency);
            }

            return colors;
        }

        public static string[] GetPreviusRgb(double transparency = 1)
        {
            var count = _previusColors.Count();
            string[] colors = new string[count];
            for (int i = 0; i < count; i++)
                colors[i] = _previusColors[i].GetRgb(transparency);

            return colors;
        }

    }

    public class Rgb
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public void SetRgb(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public string GetRgb(double transparency = 1)
        {
            return $"rgba({R}, {G}, {B}, {transparency})";
        }

        public Rgb()
        {
            
        }

        public Rgb(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Rgb(double hue, double saturation, double value)
        {
            HsvToRgb(hue, saturation, value);
        }

        private string HsvToRgb(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            switch (hi)
            {
                case 0:
                    R = v; G = t; B = p;
                    return $"rgb({v}, {t}, {p})";
                case 1:
                    R = v; G = t; B = p;
                    return $"rgb({q}, {v}, {p})";
                case 2:
                    R = v; G = t; B = p;
                    return $"rgb({p}, {v}, {t})";
                case 3:
                    R = v; G = t; B = p;
                    return $"rgb({p}, {q}, {v})";
                case 4:
                    R = v; G = t; B = p;
                    return $"rgb({t}, {p}, {v})";
                default:
                    R = v; G = t; B = p;
                    return $"rgb({v}, {p}, {q})";
            }
        }

    }

}
