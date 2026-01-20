using System;
using Resumes.Models;

class Program
{
    static void Main(string[] args)
    {
        // === JOB CREATION === //
        Job j1 = new Job();
        j1._company = "Microsoft";
        j1._jobTitle = "Software Engineer";
        j1._startYear = 2019;
        j1._endYear = 2022;

        Job j2 = new Job();
        j2._company = "Apple";
        j2._jobTitle = "Manager";
        j2._startYear = 2022;
        j2._endYear = 2023;

        // === RESUME CREATION === //
        Resume myResume = new Resume();
        myResume._name = "Alisson Rose";

        // Add Jobs to the Resume List
        myResume._jobs.Add(j1);
        myResume._jobs.Add(j2);

        // Verification
        myResume.Display();

    }
}