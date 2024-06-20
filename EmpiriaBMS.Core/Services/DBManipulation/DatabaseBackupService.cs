using CsvHelper;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO.Compression;

namespace EmpiriaBMS.Core.Services.DBManipulation;

public class DatabaseBackupService : IDisposable
{
    private bool disposedValue;

    public readonly string ConnectionString;
    public readonly string DatabaseName;

    private string _separator = "---";

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

    public async Task<string?> DatabaseToCSV()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var data = _context.GetAllDbSets();
            string csv = await _convertDataToCsvAsync(data);
            return csv;
        }
    }

    public async Task<byte[]> CsvToZipBytes(string csvContent)
    {
        using var memoryStream = new MemoryStream();
        using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
        {
            var zipEntry = archive.CreateEntry("data.csv", CompressionLevel.Fastest);
            using var zipEntryStream = zipEntry.Open();
            using var streamWriter = new StreamWriter(zipEntryStream);
            await streamWriter.WriteAsync(csvContent);
        }
        return memoryStream.ToArray();
    }

    private string _getDbName()
    {
        int startIndex = ConnectionString.IndexOf("Initial Catalog=") + "Initial Catalog=".Length;
        int endIndex = ConnectionString.IndexOf(';', startIndex);
        string dataSource = ConnectionString.Substring(startIndex, endIndex - startIndex);

        return dataSource;
    }

    private async Task<string> _convertDataToCsvAsync(List<List<object>> data)
    {
        using var writer = new StringWriter();
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        // Iterate through each list in data
        foreach (var dataList in data)
        {
            // Write records for each inner list
            csv.WriteRecords(dataList);
            await writer.WriteAsync(_separator);
            await writer.WriteLineAsync();
        }

        await writer.FlushAsync();

        return writer.ToString();
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
