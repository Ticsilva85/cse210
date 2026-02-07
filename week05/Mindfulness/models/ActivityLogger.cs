using System;
using System.IO;

public class ActivityLogger
{
    private readonly string _filePath;

    public ActivityLogger(string filePath)
    {
        _filePath = filePath;
    }

    // Appends a single log entry line to the file.
    public void Log(string activityName, int durationSeconds)
    {
        string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {activityName} | {durationSeconds}s";
        File.AppendAllLines(_filePath, new[] { line });
    }

    public string? ReadAll()
    {
        if (!File.Exists(_filePath)) return null;
        return File.ReadAllText(_filePath);
    }
}
