namespace BauProjekt.Logger;
public class MyLogger
{
    private static MyLogger _instance;
    private List<string> _logEntries = new List<string>();

    private MyLogger() { }

    public static MyLogger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MyLogger();
            }
            return _instance;
        }
    }

    public double MessageCount { get; set; }

    public void Log(string message)
    {
        _logEntries.Add(message);
        Console.WriteLine($"Logged: {message}");
    }

    public void WriteLogToFile(string filePath)
    {
        Console.WriteLine($"Writing log to {filePath}...");
        _logEntries.Clear();
    }
}
