using Microsoft.Extensions.Logging;

namespace Logging;

public class LoggerManager
{
    private readonly ILogger<LoggerManager> _logger;

    public string ProjectName { get; set; }

    public LoggerManager(ILogger<LoggerManager> logger, string projectName)
    {
        _logger = logger;
        ProjectName = projectName;
    }

    public void LogInformation(string message)
    {
        var msg = $"\n\nLog {ProjectName} --> \n{message}";

        Console.ForegroundColor = ConsoleColor.Yellow;
        _logger.LogInformation(msg);
        //Console.WriteLine(msg);
        //Debug.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void LogDebug(string message)
    {
        var msg = $"\n\nLog {ProjectName} --> \n{message}";

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        _logger.LogDebug(msg);
        //Console.WriteLine(msg);
        //Debug.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void LogError(string message)
    {
        var msg = $"\n\nLog {ProjectName} --> \n{message}";

        Console.ForegroundColor = ConsoleColor.Red;
        _logger.LogError(msg);
        //Console.WriteLine(msg);
        //Debug.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void LogWarning(string message)
    {
        var msg = $"\n\nLog {ProjectName} --> \n{message}";

        Console.ForegroundColor = ConsoleColor.Magenta;
        _logger.LogWarning(msg);
        //Console.WriteLine(msg);
        //Debug.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }

}