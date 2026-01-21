using System;
using Journal.Models;

class Program
{
    static void Main(string[] args)
    {
        string option;
        bool showMenu = true;

        Journal.Models.Journal journal = new Journal.Models.Journal();
        PromptGenerator promptGenerator = new PromptGenerator();


        // TITLE OF THE PROGRAM //
        string title = "JOURNAL PROGRAM"; // Added for better UX 
        int width = 33;

        Console.WriteLine(new string('=', width));
        Console.WriteLine(title.PadLeft((width + title.Length) / 2));
        Console.WriteLine(new string('=', width));
        Console.WriteLine();

        Console.WriteLine("Welcome the Journal Program!");

        // MENU //
        while(showMenu) // If showMenu is false, while won't be executed
        {
            Console.WriteLine("\nPlease select one of the following choices: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.WriteLine("What do you want to do? ");
            option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");

                    Console.WriteLine("Your entry: ");
                    string response = Console.ReadLine();

                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(date,prompt, response);
                    journal.AddEntry(newEntry);

                    Console.WriteLine("Entry added succesful!");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter the filename: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal Loaded successfully.");
                    break;

                case "4":
                    Console.Write("Enter the filename: ");
                    string filename = Console.ReadLine();
                    journal.SaveToFile(filename);
                    Console.WriteLine("Journal saved successfully!");
                    break;

                case "5":
                    Console.WriteLine("Quit");
                    showMenu = false;
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

    }
}