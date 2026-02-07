using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private readonly NonRepeatingPicker<string> _promptPicker;

    public ListingActivity(ActivityLogger logger)
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
            logger)
    {
        _promptPicker = new NonRepeatingPicker<string>(new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        });
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("List responses to the following prompt:\n");
        Console.WriteLine($"--- {_promptPicker.Next()} ---");

        Console.Write("\nYou may begin in: ");
        ShowCountdown(5);

        Console.WriteLine("\n\nStart listing items. Press Enter after each item:");

        List<string> items = new();
        DateTime end = DateTime.Now.AddSeconds(DurationSeconds);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string? entry = ReadLineWithTimeout(end);

            // If time ends, stop.
            if (entry == null) break;

            entry = entry.Trim();
            if (entry.Length > 0)
                items.Add(entry);
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
    }

    // Reads a line, but stops cleanly when the time runs out.
    private string? ReadLineWithTimeout(DateTime endTime)
    {
        if (DateTime.Now >= endTime) return null;

        var buffer = new List<char>();

        while (DateTime.Now < endTime)
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return new string(buffer.ToArray());
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (buffer.Count > 0)
                    {
                        buffer.RemoveAt(buffer.Count - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    buffer.Add(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }

            Thread.Sleep(20);
        }

        Console.WriteLine();
        return null;
    }
}
