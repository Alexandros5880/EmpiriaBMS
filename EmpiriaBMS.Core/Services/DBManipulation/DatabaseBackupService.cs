using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
    protected readonly Logging.LoggerManager _logger;

    public DatabaseBackupService(
        IDbContextFactory<AppDbContext> dbFactory,
        Logging.LoggerManager logger
    )
    {
        _dbContextFactory = dbFactory;
        _logger = logger;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            ConnectionString = Environment.GetEnvironmentVariable("ConnectionString") ?? default(string)!;
            if (!string.IsNullOrEmpty(ConnectionString))
                DatabaseName = GetDbName();
        }
    }

    public async Task SaveToDB(List<List<object>> data)
    {

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            foreach (var items in data)
            {
                if (items == null || items.Count == 0)
                    continue;

                Type type = Data.GetListItemType(items);
                var tableName = GetTableName(_context, type!);
                await SetDbIdentityInsert(_context, _logger, tableName, true);
                foreach (var item in items)
                {
                    try
                    {
                        await Data.UpsertAsync(_context, item);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Exception DatabaseBackupService.SaveToDB(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
                    }
                }

                await SetDbIdentityInsert(_context, _logger, tableName, false);
            }
        }

    }

    #region DATA To CSV
    public async Task<Dictionary<string, string>> DatabaseToCSV()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            Dictionary<string, List<object>> data = await _context.GetAllDbSets();
            Dictionary<string, string> csvs = _convertDataToCsvAsync(data);
            return csvs;
        }
    }

    private Dictionary<string, string> _convertDataToCsvAsync(Dictionary<string, List<object>> data)
    {
        Dictionary<string, string> content = new Dictionary<string, string>();

        // Iterate through each list in data
        foreach (var dict in data)
        {
            var tableName = dict.Key;
            var dataList = dict.Value;

            if (dataList == null || dataList.Count == 0)
                continue;

            // Get the type of the list
            Type listType = Data.GetListItemType(dataList);

            var date = DateTime.Today;
            var fileName = $"{listType.Name}-{date.ToEuropeFormat()}.csv";

            string csvContent = Data.GetCsvContent(dataList);

            if (!string.IsNullOrEmpty(csvContent))
                if (!content.ContainsKey(fileName))
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
                var genericConvertMethod = convertMethod.MakeGenericMethod(type!);
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
            _logger.LogError($"Exception DatabaseBackupService.ZipStreamToCsv(): {ex.Message}, \n Inner Exception: {ex.InnerException}");

            return null;
        }
    }

    private async Task<List<T>?> _convertCsvToDataAsync<T>(Stream stream)
    {
        try
        {
            List<T> data = await Data.ImportDataFromCsv<T>(stream);
            return data;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception DatabaseBackupService._convertCsvToDataAsync(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
            return null;
        }
    }
    #endregion

    #region DB Settings
    public static async Task<bool> SetDbIdentityInsert(AppDbContext context, Logging.LoggerManager logger, string tableName, bool desiredState)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "The database context cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(tableName))
        {
            throw new ArgumentException("The table name cannot be null or empty.", nameof(tableName));
        }

        try
        {
            // Check if the database connection is open
            if (context.Database.GetDbConnection().State != System.Data.ConnectionState.Open)
                await context.Database.OpenConnectionAsync();

            // SQL command to set IDENTITY_INSERT
            string sqlSetIdentityInsert = $"SET IDENTITY_INSERT [{tableName}] {(desiredState ? "ON" : "OFF")};";

            // Execute the SQL command to set IDENTITY_INSERT
            var result = await context.Database.ExecuteSqlRawAsync(sqlSetIdentityInsert);

            // Check if the database connection is open
            if (context.Database.GetDbConnection().State != System.Data.ConnectionState.Open)
                await context.Database.CloseConnectionAsync();

            return true;
        }
        catch (Exception ex)
        {
            logger.LogError($"Exception DatabaseBackupService.SetDbIdentityInsert(): {ex.Message}, \n Inner Exception: {ex.InnerException}");

            return false;
        }
    }
    #endregion

    #region Retrieve Db Information
    public static async Task<List<string>> GetTablesNames(AppDbContext context, Logging.LoggerManager logger)
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            try
            {
                // Get all entity types
                var entityTypes = context.Model.GetEntityTypes();

                // Find all tables with identity columns
                var tablesWithIdentityColumns = entityTypes
                    .Where(e => e.FindPrimaryKey().Properties.Any(p => p.ValueGenerated == ValueGenerated.OnAdd))
                    .Select(e => e.GetTableName())
                    .Distinct()
                    .ToList();

                await transaction.CommitAsync();
                return tablesWithIdentityColumns!;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception DatabaseBackupService._getDBTablesNames(): {ex.Message}, \n Inner Exception: {ex.InnerException}");

                await transaction.RollbackAsync();
                return default(List<string>)!;
            }
        }
    }

    public string GetTableName(AppDbContext context, Type type)
    {
        var model = context.Model;
        if (model != null)
        {
            var entityType = model.FindEntityType(type);
            if (entityType != null)
            {
                return entityType.GetTableName()!;
            }
        }
        return default(string)!;
    }

    private string GetDbName()
    {
        int startIndex = ConnectionString.IndexOf("Initial Catalog=") + "Initial Catalog=".Length;
        int endIndex = ConnectionString.IndexOf(';', startIndex);
        string dataSource = ConnectionString.Substring(startIndex, endIndex - startIndex);

        return dataSource;
    }
    #endregion

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
