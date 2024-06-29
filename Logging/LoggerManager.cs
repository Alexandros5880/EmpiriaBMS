using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Logging;

public class LoggerManager
{
    private readonly ILogger<LoggerManager> _logger;

    public string ProjectName { get; set; }

    public LoggerManager(ILogger<LoggerManager> logger)
    {
        _logger = logger;
    }

    public LoggerManager(ILogger<LoggerManager> logger, string projectName)
    {
        _logger = logger;
        ProjectName = projectName;
    }

    public void LogInformation(string message)
    {
        var msg = $"\n\nLog {ProjectName} --> \n{message}";

        _logger.LogInformation(msg);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(msg);
        Debug.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void LogDebug(string message)
    {
        var msg = $"\n\nLog {ProjectName} --> \n{message}";

        _logger.LogDebug(msg);

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(msg);
        Debug.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void LogError(string message)
    {
        var msg = $"\n\nLog {ProjectName} --> \n{message}";

        _logger.LogError(msg);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Debug.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void LogWarning(string message)
    {
        var msg = $"\n\nLog {ProjectName} --> \n{message}";

        _logger.LogWarning(msg);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(msg);
        Debug.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }

}