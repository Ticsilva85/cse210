using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Homework.models
{
    public class WritingAssignment : Assignment
    {
        private string _title;

        public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
        {
            _title = title;
        }

        public string GetWritingInformation()
        {
            string studentName = GetStudentName();
            
            return $"{_title} by {studentName}";
        }
    }
}