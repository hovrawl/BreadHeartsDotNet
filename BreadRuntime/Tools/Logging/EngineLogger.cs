namespace BreadRuntime.Tools.Logging;

internal class EngineLogger
{
    private readonly Dictionary<string, List<LogEntry>> _pluginLogs;
    private readonly object _lockObject = new();
    public event EventHandler<LogEventArgs> OnNewLog;

    public EngineLogger()
    {
        _pluginLogs = new Dictionary<string, List<LogEntry>>();
    }

    public void Log(string pluginName, LogLevel level, string message)
    {
        var entry = new LogEntry(DateTime.Now, pluginName, level, message);

        lock (_lockObject)
        {
            if (!_pluginLogs.ContainsKey(pluginName))
            {
                _pluginLogs[pluginName] = new List<LogEntry>();
            }
            _pluginLogs[pluginName].Add(entry);
        }

        OnNewLog?.Invoke(this, new LogEventArgs(entry));
    }

    public IReadOnlyList<LogEntry> GetPluginLogs(string pluginName)
    {
        lock (_lockObject)
        {
            return _pluginLogs.TryGetValue(pluginName, out var logs) 
                ? logs.AsReadOnly() 
                : new List<LogEntry>().AsReadOnly();
        }
    }

    public IReadOnlyList<LogEntry> GetAllLogs()
    {
        lock (_lockObject)
        {
            return _pluginLogs.Values
                .SelectMany(x => x)
                .OrderBy(x => x.Timestamp)
                .ToList()
                .AsReadOnly();
        }
    }
}

public enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error
}

public class LogEntry
{
    public DateTime Timestamp { get; }
    public string PluginName { get; }
    public LogLevel Level { get; }
    public string Message { get; }

    public LogEntry(DateTime timestamp, string pluginName, LogLevel level, string message)
    {
        Timestamp = timestamp;
        PluginName = pluginName;
        Level = level;
        Message = message;
    }

    public override string ToString() => 
        $"[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{Level}] [{PluginName}] {Message}";
}

public class LogEventArgs : EventArgs
{
    public LogEntry LogEntry { get; }
    public LogEventArgs(LogEntry entry) => LogEntry = entry;
}

