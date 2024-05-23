using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Hellpers;

public static class Data
{

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

            csvBuilder.AppendLine(string.Join(",", properties.Select(p => p.Name)));

            foreach (var item in data)
            {
                var line = string.Join(",", properties.Select(p => p.GetValue(item, null)));
                csvBuilder.AppendLine(line);
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
