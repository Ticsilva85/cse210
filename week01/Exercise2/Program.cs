using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string studentGrade = Console.ReadLine();

        int x = int.Parse(studentGrade);

        string letter = "";

        //------- Short Code -------

        if (x >= 90)
        {
            letter = "A";
        }

        else if (x >= 80)
        {
            letter = "B";
        }

        else if (x >=70)
        {
            letter = "C";
        }

        else if (x >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign = "";
        int lastDigit = x % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }

        else if (lastDigit < 3)
        {
            sign = "-";
        }

        if (x >= 94 || letter == "F") // If the grade is 94 or greater(including 100) or if it is F, remove the signal 
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is {letter}{sign}.");

        //------- Long Code -------

        // if (x >= 90)
        // {
        //     if (x >=90 && x <= 93)
        //     {
        //         letter ="A-";
        //     }
        //     else
        //     {
        //         letter = "A";
        //     }
        // }

        // else if (x >=80)
        // {
        //     if (x >= 87)
        //     {
        //         letter = "B+";
        //     }

        //     else if (x >=80 && x <= 83)
        //     {
        //         letter ="B-";
        //     }
        //     else
        //     {
        //         letter = "B";
        //     }
        // }

        // else if (x >=70)
        // {
        //     if (x >= 77)
        //     {
        //         letter = "C+";
        //     }

        //     else if (x >=70 && x <= 73)
        //     {
        //         letter ="C-";
        //     }
        //     else
        //     {
        //         letter = "C";
        //     }
        // }        
        
        // else if (x >=60)
        // {
        //     if (x >= 67)
        //     {
        //         letter = "D+";
        //     }

        //     else if (x >=60 && x <= 63)
        //     {
        //         letter ="D-";
        //     }
        //     else
        //     {
        //         letter = "D";
        //     }
        // }

        // else
        // {
        //     letter = "F";
        // }

        // Console.WriteLine($"Your grade is {letter}.");


       
        if (x >= 70)
        {
            Console.WriteLine("Congratulations! You passed!");
        }

        else
        {
            Console.WriteLine("Sorry, you failed. Keep trying!");
        }
    }
}