using System;
using System.Collections.Generic;

namespace Journal.Models
{
    public class Journal
    {
        public List<Entry> _entries;

        public Journal()
        {
            _entries = new List<Entry>();
        }

        public void AddEntry(Entry newEntry)
        {
            _entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            // Will be implemented after
        }

        public void SaveToFile(string file)
        {
            // Will be implemented after
        }

        public void LoadFromFile(string file)
        {
            // Will be implemented after
        }

    }
}