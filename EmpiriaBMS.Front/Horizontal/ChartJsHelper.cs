using MessagePack.Formatters;
using Microsoft.Recognizers.Text.Number.Italian;
using System;
using Color = System.Drawing.Color;

namespace EmpiriaBMS.Front.Horizontal
{
    public static class ChartJsHelper
    {

        private static Rgb[] _previusColors;

        public static List<(Color, Color)> GetPreferedRandomColors(int colorCount = 0, double transparency = 1)
        {
            if (colorCount == 0)
                return null;

            const int startHue = 0;
            const int endHue = 360;

            var colors = GenerateColors(colorCount, startHue, endHue, transparency);

            List<(Color, Color)> returnColors = new List<(Color, Color)>();

            foreach (var color in colors)
            {
                // Convert the hex color to a Color object
                Color bodyColor = RgbaStringToColor(color);

                // Create a slightly darker or lighter border color based on body color's brightness
                int darkerR = Math.Max(bodyColor.R - 20, 0); // Darker Red
                int darkerG = Math.Max(bodyColor.G - 20, 0); // Darker Green
                int darkerB = Math.Max(bodyColor.B - 20, 0); // Darker Blue

                Color borderColor = Color.FromArgb(darkerR, darkerG, darkerB); // Slightly darker border color

                returnColors.Add((bodyColor, borderColor));
            }

            return returnColors;
        }

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

        public static string[] GenerateColors(int count, int startHue = 0, int endHue = 360, double transparency = 1)
        {
            if (count <= 0 || startHue < 0 || startHue > 360 || endHue < 0 || endHue > 360)
                throw new ArgumentException("Invalid arguments");

            string[] colors = new string[count];
            _previusColors = new Rgb[count];
            double step = (endHue - startHue) / (double)count;
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                double hue = startHue + step * i;

                // Ensure saturation and brightness avoid dark/light
                double saturation = 0.6 + (random.NextDouble() * 0.4);  // Between 0.6 and 1.0
                double brightness = 0.5 + (random.NextDouble() * 0.3);  // Between 0.5 and 0.8

                _previusColors[i] = new Rgb(hue, saturation, brightness);  // Hue, saturation, brightness
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

        public static Color RgbaStringToColor(string rgbaString)
        {
            // Remove "rgba(" and ")" and split the string into components
            var rgbaValues = rgbaString
                .Replace("rgba(", "")
                .Replace(")", "")
                .Split(',');

            // Parse the values
            int r = int.Parse(rgbaValues[0].Trim());
            int g = int.Parse(rgbaValues[1].Trim());
            int b = int.Parse(rgbaValues[2].Trim());
            float alpha = float.Parse(rgbaValues[3].Trim()); // Alpha is a float from 0 to 1

            // Convert alpha to an integer value from 0 to 255
            int a = (int)(alpha * 255);

            // Return the color
            return Color.FromArgb(a, r, g, b);
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
