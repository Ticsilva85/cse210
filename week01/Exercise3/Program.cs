using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        string response;
        
        do
        {         
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100);

            // Console.Write("What is the magic number? ");
            // string x = Console.ReadLine();
            // int magicNumber = int.Parse(x);

            int guess = -1;
            int attemptCounter = 0;
            while (guess != number)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attemptCounter++;

                if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
            }

            Console.WriteLine("You guessed it!");
            Console.WriteLine($"You guessed in {attemptCounter} tries.");
        
            Console.Write("Do you want to play again? ");
            response = Console.ReadLine();
        } while (response == "yes");

    }
}