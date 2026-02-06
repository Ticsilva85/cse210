using System;
using ScriptureMemorizer.models;

class Program
{
    static void Main(string[] args)
    {
        // Setup the scripture
        Reference scriptureReference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart and lean not unto thine own understanding";
        Scripture scripture = new Scripture(scriptureReference, scriptureText);

        // ✅ Difficulty selection
        int wordsToHide = ChooseDifficulty();

        string userInput = "";

        while (userInput.ToLower() != "quit")
        {
            Console.Clear();

            // ✅ Progress display
            int hidden = scripture.GetHiddenWordCount();
            int total = scripture.GetTotalWordCount();
            double percent = scripture.GetHiddenPercentage();

            Console.WriteLine($"Progress: {hidden}/{total} hidden ({percent:0}%)");
            Console.WriteLine(new string('-', 40));

            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to hide words");
            Console.WriteLine("Type 'hint' to reveal 1 word");
            Console.WriteLine("Type 'quit' to end");
            Console.Write("> ");

            userInput = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(userInput))
            {
                if (scripture.IsCompletelyHidden())
                {
                    break;
                }

                scripture.HideRandomWords(wordsToHide);
            }
            else if (userInput.Trim().ToLower() == "hint")
            {
                // ✅ Hint: reveal 1 hidden word
                scripture.RevealRandomWords(1);
            }
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden (or you quit). Goodbye!");
    }

    private static int ChooseDifficulty()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose a difficulty:");
            Console.WriteLine("1 - Easy (hide 1 word)");
            Console.WriteLine("2 - Normal (hide 3 words)");
            Console.WriteLine("3 - Hard (hide 5 words)");
            Console.Write("\nYour choice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice.Trim())
            {
                case "1": return 1;
                case "2": return 3;
                case "3": return 5;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
