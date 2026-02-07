using System;
using System.Threading;

public abstract class Activity
{
    private readonly string _name;
    private readonly string _description;
    private int _durationSeconds;

    protected readonly ActivityLogger _logger;

    protected Activity(string name, string description, ActivityLogger logger)
    {
        _name = name;
        _description = description;
        _logger = logger;
    }

    // Template method: all activities follow the same overall flow.
    public void Run()
    {
        ShowStartMessage();
        PerformActivity();
        ShowEndMessage();

        // Extra creativity: log session info.
        _logger.Log(_name, _durationSeconds);
    }

    protected int DurationSeconds => _durationSeconds;

    // Each derived activity implements its own core behavior.
    protected abstract void PerformActivity();

    private void ShowStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name} ===\n");
        Console.WriteLine(_description);

        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _durationSeconds = ReadIntFromUser(min: 1, max: 3600);

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(seconds: 3);
        Console.WriteLine();
    }

    private void ShowEndMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(seconds: 2);

        Console.WriteLine($"\nYou have completed the {_name} for {_durationSeconds} seconds.");
        ShowSpinner(seconds: 3);

        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    // Common animation: spinner
    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(500);
            Console.Write("\b");
            i++;
        }
    }

    // Common animation: countdown
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected int ReadIntFromUser(int min, int max)
    {
        while (true)
        {
            string input = (Console.ReadLine() ?? "").Trim();
            if (int.TryParse(input, out int value) && value >= min && value <= max)
                return value;

            Console.Write($"Please enter a valid number ({min}-{max}): ");
        }
    }
}
