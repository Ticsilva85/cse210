using System;
using ScriptureMemorizer.models;

class Program
{
    static void Main(string[] args)
    {
        // Setup the scripture (using the multiple-verse constructor)
        Reference scriptureReference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart and lean not unto thine own understanding";
        Scripture scripture = new Scripture(scriptureReference, scriptureText);

        string userInput = "";

        while (userInput.ToLower() != "quit")
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to end.");
            
            userInput = Console.ReadLine();

            // If the user presses Enter and there are still words to hide
            if (string.IsNullOrEmpty(userInput))
            {
                if (scripture.IsCompletelyHidden())
                {
                    break;
                }
                scripture.HideRandomWords(3); // Hides 3 words at a time
            }
        }

        // Final display to show the fully hidden scripture before closing
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Goodbye!");
    }
}