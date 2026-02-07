using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeActivity : Activity
{
    private readonly NonRepeatingPicker<string> _promptPicker;

    public GratitudeActivity(ActivityLogger logger)
        : base(
            "Gratitude Activity",
            "This activity helps you build gratitude. You'll write short gratitude notes as quickly as you can.",
            logger)
    {
        _promptPicker = new NonRepeatingPicker<string>(new List<string>
        {
            "Write something you're grateful for today.",
            "Write a person you're grateful for and why.",
            "Write a small moment from today that made you smile.",
            "Write something you learned recently that you appreciate."
        });
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Gratitude prompt:\n");
        Console.WriteLine($"--- {_promptPicker.Next()} ---");

        Console.Write("\nYou may begin in: ");
        ShowCountdown(3);

        Console.WriteLine("\n\nWrite as many short lines as you can. Press Enter after each one:");

        int count = 0;
        DateTime end = DateTime.Now.AddSeconds(DurationSeconds);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string? line = ReadLineWithTimeout(end);
            if (line == null) break;

            if (!string.IsNullOrWhiteSpace(line))
                count++;
        }

        Console.WriteLine($"\nNice! You wrote {count} gratitude lines.");
    }

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
