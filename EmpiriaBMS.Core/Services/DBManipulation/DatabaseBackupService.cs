using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using System.Reflection;
using System.Text;


namespace EmpiriaBMS.Core.Services.DBManipulation;

public class DatabaseBackupService : IDisposable
{
    private bool disposedValue;

    public readonly string ConnectionString;
    public readonly string DatabaseName;

    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public DatabaseBackupService(IDbContextFactory<AppDbContext> dbFactory)
    {
        _dbContextFactory = dbFactory;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
            if (!string.IsNullOrEmpty(ConnectionString))
                DatabaseName = _getDbName();
        }
    }

    #region DATA To CSV
    public Dictionary<string, string> DatabaseToCSV()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var data = _context.GetAllDbSets();
            Dictionary<string, string> csvs = _convertDataToCsvAsync(data);
            return csvs;
        }
    }

    private Dictionary<string, string> _convertDataToCsvAsync(List<List<object>> data)
    {
        Dictionary<string, string> content = new Dictionary<string, string>();

        // Iterate through each list in data
        foreach (var dataList in data)
        {
            if (dataList == null || dataList.Count == 0)
                continue;

            // Get the type of the list
            Type listType = Data.GetListItemType(dataList);


            var date = DateTime.Today;
            var fileName = $"{listType.Name}-{date.ToEuropeFormat()}.csv";

            string csvContent = Data.GenerateCsvContentDynamic(dataList, listType);

            if (!string.IsNullOrEmpty(csvContent))
                content.Add(fileName, csvContent);
        }

        return content;
    }

    public async Task<byte[]> CsvToZipBytes(Dictionary<string, string> csvFiles)
    {
        using var memoryStream = new MemoryStream();
        using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
        {
            foreach (var c in csvFiles)
            {
                var fileName = c.Key;
                var csvContent = c.Value;

                var zipEntry = archive.CreateEntry(fileName, CompressionLevel.Fastest);
                using var zipEntryStream = zipEntry.Open();
                using var streamWriter = new StreamWriter(zipEntryStream, Encoding.UTF8);
                await streamWriter.WriteLineAsync(csvContent);
            }
        }
        return memoryStream.ToArray();
    }
    #endregion

    #region CSV To DATA
    public async Task<List<List<object>>?> ZipStreamToCsv(MemoryStream stream)
    {
        try
        {
            using var archive = new ZipArchive(stream, ZipArchiveMode.Read);

            var assemplyName = "EmpiriaBMS.Models";
            var nameSpace = "EmpiriaBMS.Models.Models";

            // Return Dictionary Entry Name and antry Content
            List<Tuple<Type?, ZipArchiveEntry>> csvEntries = archive.Entries
                .Where(entry => entry.Name.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                .Select(entry =>
                {
                    int indexOfDash = entry.Name.IndexOf('-');
                    var typeName = $"{nameSpace}.{entry.Name.Substring(0, indexOfDash)}, {assemplyName}";
                    Type? type = Type.GetType(typeName);
                    return Tuple.Create(type, entry);
                })
                .Where(t => t.Item1 != null)
                .ToList();

            if (csvEntries == null || csvEntries.Count == 0)
                return null;

            List<List<object>> data = new List<List<object>>();

            foreach (var tuple in csvEntries)
            {
                var type = tuple.Item1;
                var content = tuple.Item2;

                using var csvStream = content.Open();

                if (csvStream == null)
                    continue;


                // Constructing the method info for _convertCsvToDataAsync<T>
                var convertMethod = typeof(DatabaseBackupService)
                    .GetMethod("_convertCsvToDataAsync", BindingFlags.NonPublic | BindingFlags.Instance);
                if (convertMethod == null)
                    continue;
                // Constructing the generic method _convertCsvToDataAsync<T> based on 'type'
                var genericConvertMethod = convertMethod.MakeGenericMethod(type);
                if (genericConvertMethod == null)
                    continue;
                // Invoking the generic method dynamically
                var task = (Task)genericConvertMethod.Invoke(this, new object[] { csvStream });
                await task;
                // Extracting the result from the task
                var listProperty = task.GetType().GetProperty("Result");
                var resultValue = listProperty.GetValue(task);
                var list = (IEnumerable<object>)resultValue;

                if (list != null && list.Count() > 0)
                {
                    var objs = list.Cast<object>().ToList();
                    data.Add(objs);
                }
            }

            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception DatabaseBackupService ZipStreamToCsv: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            // TODO: log error

            return null;
        }
    }

    private async Task<List<T>?> _convertCsvToDataAsync<T>(Stream stream)
    {
        try
        {
            List<T> data = await Data.ImportData<T>(stream);
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception DatabaseBackupService _convertCsvToDataAsync: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }
    #endregion

    private string _getDbName()
    {
        int startIndex = ConnectionString.IndexOf("Initial Catalog=") + "Initial Catalog=".Length;
        int endIndex = ConnectionString.IndexOf(';', startIndex);
        string dataSource = ConnectionString.Substring(startIndex, endIndex - startIndex);

        return dataSource;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
