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
                    Console.WriteLine(prompt);

                    Console.WriteLine("Your entry: ");
                    string response = Console.ReadLine();

                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(date,prompt, response);
                    journal.AddEntry(newEntry);

                    Console.WriteLine("Entry added succesful!");
                    break;

                case "2":
                    Console.WriteLine("Busca de cliente");
                    break;

                case "3":
                    Console.WriteLine("Apagar de cliente");
                    break;

                case "4":
                    Console.WriteLine("Apagar de cliente");
                    break;

                case "5":
                    Console.WriteLine("Encerrar");
                    showMenu = false; // Com esse comando os códigos depois do while serão executados
                    // Environment.Exit(0); // Com o Enviroment.Exit() o programa encerra e não executa os comandos fora do loop
                    break;

                default:
                    Console.WriteLine("opção Inválida");
                    break;
            }
        }

    }
}