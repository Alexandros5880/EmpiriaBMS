using System.Reflection;
using System.Text;

namespace EmpiriaBMS.Core.Hellpers;

public static class Data
{
    private static string _seperator = "  ,  ";

    public static string GetCsvContent<T>(IList<T> data)
    {
        var content = SCV.GenerateCsvContent(data);

        return content;
    }

    public static string GenerateCsvContentDynamic(List<object> dataList, Type itemType)
    {
        MethodInfo method = typeof(Data).GetMethod("GetCsvContent", BindingFlags.Public | BindingFlags.Static);
        if (method == null)
            throw new InvalidOperationException("The method GetCsvContent could not be found.");

        // Make the method generic with the specified item type
        MethodInfo genericMethod = method.MakeGenericMethod(itemType);

        // Invoke the generic method and get the result
        Array array = Array.CreateInstance(itemType, dataList.Count);
        for (int i = 0; i < dataList.Count; i++)
        {
            array.SetValue(dataList[i], i);
        }

        // Invoke the generic method and get the result
        var result = genericMethod.Invoke(null, new object[] { array });

        return (string)result;
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

    public static Type GetListItemType(List<object> dataList)
    {
        foreach (var item in dataList)
        {
            if (item != null)
            {
                return item.GetType();
            }
        }

        return null;
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
            csvBuilder.AppendLine(string.Join(_seperator, columnValues));


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

                csvBuilder.AppendLine(string.Join(_seperator, lineValues));
            }

            return csvBuilder.ToString();
        }

        public static void SaveCsvToFile(string csvContent, string filePath)
        {
            File.WriteAllText(filePath, csvContent);
        }

        public static async Task<List<T>> ImportFromCsv<T>(Stream stream)
        {
            try
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
                            columns = new List<string>(line.Split(_seperator));
                        }
                        else
                        {
                            var row = new List<string>(line.Split(_seperator));
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
            catch (Exception ex)
            {
                // TODO: Log Exception
                Console.WriteLine($"Exception Data.ImportFromCsv: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                return null;
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
