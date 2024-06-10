using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace EmpiriaBMS.Core.Hellpers;

public static class Data
{
    public static string GetCsvContent<T>(IList<T> data)
    {
        var content = SCV.GenerateCsvContent(data);

        return content;
    }

    public static void ExportData<T>(string filePath, IList<T> data, FileType fileType = FileType.CSV)
    {
        switch (fileType)
        {
            case FileType.CSV:
                var csvContent = SCV.GenerateCsvContent(data);
                SCV.SaveCsvToFile(csvContent, filePath);
                break;

            default:
                break;
        }
    }

    public static List<T>? ImportData<T>(string filePath, FileType fileType = FileType.CSV)
    {
        switch (fileType)
        {
            case FileType.CSV:
                return SCV.ImportFromCsv<T>(filePath);

            default:
                return null;
        }
    }

    private static class SCV
    {
        public static string GenerateCsvContent<T>(IList<T> data)
        {
            var properties = typeof(T).GetProperties();
            var csvBuilder = new StringBuilder();


            // Add Columns
            var columnValues = new List<string>();
            foreach (var prop in properties)
                if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string))
                    columnValues.Add(prop.Name);
            csvBuilder.AppendLine(string.Join(",", columnValues));


            // Add Values
            foreach (var item in data)
            {
                var lineValues = new List<string>();

                foreach (var prop in properties)
                {
                    var propValue = prop.GetValue(item);

                    if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string))
                        lineValues.Add(propValue?.ToString() ?? "");
                }

                csvBuilder.AppendLine(string.Join(",", lineValues));
            }

            return csvBuilder.ToString();
        }



        public static void SaveCsvToFile(string csvContent, string filePath)
        {
            File.WriteAllText(filePath, csvContent);
        }

        public static List<T>? ImportFromCsv<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            });

            var records = csv.GetRecords<T>().ToList();
            return records;
        }
    }
}

public enum FileType
{
    CSV
}
