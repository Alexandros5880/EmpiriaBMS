using System.Reflection;
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

    public static async Task<List<T>> ImportData<T>(Stream stream, FileType fileType = FileType.CSV)
    {
        switch (fileType)
        {
            case FileType.CSV:
                return await SCV.ImportFromCsv<T>(stream);

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

        public static async Task<List<T>> ImportFromCsv<T>(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {

                List<string> columns = new List<string>();
                List<List<string>> rows = new List<List<string>>();

                string line;
                int count = 0;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (count == 0)
                    {
                        columns = new List<string>(line.Split(','));
                    }
                    else
                    {
                        var row = new List<string>(line.Split(','));
                        if (row.Count > 1)
                            rows.Add(row);
                    }
                    count++;
                }

                // Create Instance
                PropertyInfo[] properties = typeof(T).GetProperties();
                List<T> data = new List<T>();

                foreach (var row in rows)
                {
                    if (row == null || row.Count == 0)
                        continue;
                    var column = 0;
                    T instance = Activator.CreateInstance<T>();
                    foreach (var val in row)
                    {
                        _setProperty(instance, columns[column], val);
                        column++;
                    }
                    data.Add(instance);
                }

                return data;
            }
        }
    }

    private static void _setProperty<T>(T instance, string propertyName, string propertyValue)
    {
        PropertyInfo property = typeof(T).GetProperty(propertyName);
        if (property != null && property.CanWrite)
        {
            Type propertyType = property.PropertyType;
            object value = Convert.ChangeType(propertyValue, propertyType);
            property.SetValue(instance, value);
        }
    }
}

public enum FileType
{
    CSV
}
