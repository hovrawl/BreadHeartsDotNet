using Avalonia.Controls;

namespace BreadHeartsLauncher.Classes;

public static class ConsoleManager
{
    private static TextBlock _console;
    private static bool _initialized;
    
    public static void Initialize(TextBlock consoleTextBlock)
    {
        // Cache console
        _console = consoleTextBlock;

        // Finished initialization
        _initialized = true;
    }

    public static void Write(string text)
    {
        if (_console == null || !_initialized) return;

        _console.Text += $"{text}";
    }
    
    public static void WriteLine(string text)
    {
        if (_console == null || !_initialized) return;

        _console.Text += $"\n\r{text}";
    }
}