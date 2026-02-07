using System;
using Homework.models;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Tiago Cavalcante", "Inheritance");

        string summary = assignment.GetSummary();
        Console.WriteLine(summary);

        MathAssignment mathAssignment = new MathAssignment("Tiago Cavalcante", "Fractions", "7.3", "8-19");

        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        WritingAssignment writingAssignment = new WritingAssignment("Tiago Cavalcante", "Inheritance", "The Great Ideas Journal");

        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}