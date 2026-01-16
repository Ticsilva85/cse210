using System;
using System.Collections.Generic;

namespace Resumes.Models
{
    public class Resume
    {
        public string _name;

        public List<Job> _jobs = new List<Job>();

        public void Display()
        {
            Console.WriteLine($"{_name}.");
            Console.WriteLine("Jobs: ");

            foreach (Job job in _jobs)
            {
                job.Present();
            }
        }
    }
}