using System;

class Program
{
    static void Main()
    {
        Console.Title = "Mindfulness Program";

        // Extra creativity: simple session log to a file.
        var logger = new ActivityLogger("activity_log.txt");

        // Create activities (inherit from Activity base class).
        Activity breathing = new BreathingActivity(logger);
        Activity reflection = new ReflectionActivity(logger);
        Activity listing   = new ListingActivity(logger);

        // Extra activity (creativity / exceeding requirements).
        Activity gratitude = new GratitudeActivity(logger);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude activity (extra)");
            Console.WriteLine("  5. View log (extra)");
            Console.WriteLine("  6. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = (Console.ReadLine() ?? "").Trim();

            switch (choice)
            {
                case "1":
                    breathing.Run();
                    break;
                case "2":
                    reflection.Run();
                    break;
                case "3":
                    listing.Run();
                    break;
                case "4":
                    gratitude.Run();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("=== Activity Log ===\n");
                    Console.WriteLine(logger.ReadAll() ?? "(No entries yet)");
                    Console.WriteLine("\nPress Enter to return to menu...");
                    Console.ReadLine();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}