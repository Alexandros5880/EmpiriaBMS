using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Logging;

public class LoggerManager
{
    private readonly ILogger<LoggerManager> _logger;

    public LoggerManager(ILogger<LoggerManager> logger)
    {
        _logger = logger;
    }

    public void LogInformation(string message)
    {
        _logger.LogInformation(message);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Debug.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void LogDebug(string message)
    {
        _logger.LogDebug(message);

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(message);
        Debug.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void LogError(string message)
    {
        _logger.LogError(message);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Debug.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void LogWarning(string message)
    {
        _logger.LogWarning(message);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(message);
        Debug.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Add other log levels as needed
}