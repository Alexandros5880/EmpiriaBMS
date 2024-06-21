using CsvHelper;
using CsvHelper.Configuration;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO.Compression;
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
            var fileName = $"{listType.Name}s-{date.ToEuropeFormat()}.csv";

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
    public async Task<List<List<object>>> ZipStreamToCsv(MemoryStream stream)
    {
        try
        {
            using var archive = new ZipArchive(stream, ZipArchiveMode.Read);
            var csvEntry = archive.Entries.FirstOrDefault(entry => entry.Name.EndsWith(".csv", StringComparison.OrdinalIgnoreCase));
            if (csvEntry == null)
                throw new NullReferenceException(nameof(csvEntry));

            using var csvStream = csvEntry.Open();

            List<List<object>> data = await _convertCsvToDataAsync(csvStream);

            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception DatabaseBackupService ZipStreamToCsv: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            // TODO: log error

            return null;
        }
    }

    private async Task<List<List<object>>> _convertCsvToDataAsync(Stream stream)
    {
        using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
        {
            var content = await sr.ReadToEndAsync();
            var data = new List<List<object>>();

            if (content == null)
                return data;

            using var reader = new StringReader(content);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ",",
            });

            using (var _context = _dbContextFactory.CreateDbContext())
            {

                var users = csv.GetRecords<User>();


                var dbSetTypes = _context.GetAllDbSetsTypes();

                foreach (var entityType in dbSetTypes)
                {


                    // Construct the GetRecords<T> method dynamically
                    var getRecordsMethod = typeof(CsvReader).GetMethod("GetRecords", new Type[] { });
                    var genericGetRecordsMethod = getRecordsMethod.MakeGenericMethod(entityType);
                    // Invoke GetRecords<T> to get records of current entityType
                    var records = (IEnumerable<object>)genericGetRecordsMethod.Invoke(csv, null);

                    // Convert records to List<List<object>> format
                    var entityData = new List<List<object>>();
                    foreach (var record in records)
                    {
                        var recordProperties = record.GetType().GetProperties();
                        var rowData = recordProperties.Select(p => p.GetValue(record)).Cast<object>().ToList();
                        entityData.Add(rowData);
                    }

                    // Add entityData to main data list
                    data.AddRange(entityData);
                }
            }

            //    var users = csv.GetRecords<User>();
            //var roles = csv.GetRecords<Role>();

            return data;

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
