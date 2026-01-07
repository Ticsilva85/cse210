using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        // Variables created to store the return of the methods
        string name = PromptUserName();
        int numFav = PromptUserNumber();
        int square = SquareNumber(numFav);

        DisplayResult(name, square);
    }

    static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }
        
    static string PromptUserName() 
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter you favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"Brother {name}, the square of your number is {square}.");
    }
}