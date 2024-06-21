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

    public async Task SaveToDB(List<List<object>> data)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                //_setDbIdentityInsert(_context, true); // Enable IDENTITY_INSERT for all tables
                try
                {

                    foreach (var items in data)
                    {
                        if (items == null || items.Count == 0)
                            continue;

                        Type type = Data.GetListItemType(items);

                        // Get the Set<T> method from DbContext
                        MethodInfo setMethod = typeof(DbContext).GetMethod("Set", Type.EmptyTypes).MakeGenericMethod(type);

                        // Invoke the Set<T> method to get the DbSet<T>
                        object dbSet = setMethod.Invoke(_context, null);

                        // Get the AddRangeAsync method from DbSet<T>
                        MethodInfo addRangeAsyncMethod = typeof(DbSet<>).MakeGenericType(type).GetMethod("AddRangeAsync", new[] { typeof(IEnumerable<>).MakeGenericType(type) });

                        if (addRangeAsyncMethod == null)
                        {
                            // Try another overload with params TEntity[]
                            addRangeAsyncMethod = typeof(DbSet<>).MakeGenericType(type).GetMethod("AddRangeAsync", new[] { type.MakeArrayType() });
                        }

                        if (addRangeAsyncMethod != null)
                        {
                            // Invoke the generic method and get the result
                            Array array = Array.CreateInstance(type, items.Count);
                            for (int i = 0; i < items.Count; i++)
                            {
                                array.SetValue(items[i], i);
                            }

                            // Invoke the AddRangeAsync method with the items
                            await (Task)addRangeAsyncMethod.Invoke(dbSet, new object[] { array });
                            await _context.SaveChangesAsync();

                        }
                    }

                    //_setDbIdentityInsert(_context, false); // Disable IDENTITY_INSERT for all tables
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // TODO: Log Exception
                    Console.WriteLine($"Exception DatabaseBackupService _convertCsvToDataAsync: {ex.Message}, \nInner: {ex.InnerException?.Message}");

                    //_setDbIdentityInsert(_context, false); // Disable IDENTITY_INSERT for all tables
                    transaction.Rollback();
                }
            }
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
            // TODO: Log Exception
            Console.WriteLine($"Exception DatabaseBackupService _convertCsvToDataAsync: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }
    #endregion

    //private void _setDbIdentityInsert(AppDbContext context, bool desiredState)
    //{
    //    // Get all entity types
    //    var entityTypes = context.Model.GetEntityTypes();

    //    // Find all tables with identity columns
    //    var tablesWithIdentityColumns = entityTypes
    //        .Where(e => e.FindPrimaryKey().Properties.Any(p => p.ValueGenerated == ValueGenerated.OnAdd))
    //        .Select(e => e.GetTableName())
    //        .Distinct()
    //        .ToList();

    //    // Enable IDENTITY_INSERT for each table
    //    foreach (var table in tablesWithIdentityColumns)
    //    {
    //        string tableName = $"empiriabms.dbo.{table}";

    //        string sql = $@"
    //            DECLARE @currentState BIT;
    //            SELECT @currentState = ISNULL(OBJECTPROPERTY(OBJECT_ID('{tableName}'), 'TableHasIdentity'), 0);
    //            IF (@currentState <> {(desiredState ? "1" : "0")})
    //            BEGIN
    //                SET IDENTITY_INSERT [{tableName}] {(desiredState ? "ON" : "OFF")};
    //            END
    //        ";

    //        //string sql = $@"SET IDENTITY_INSERT [{tableName}] {(desiredState ? "ON" : "OFF")};";

    //        Console.WriteLine($"\n\n{sql}\n\n");

    //        context.Database.ExecuteSqlRaw(sql);
    //    }
    //}

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
