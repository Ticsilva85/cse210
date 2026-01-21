using System;
using System.Collections.Generic;
using System.IO;

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
            if (_entries.Count == 0)
            {
                Console.WriteLine("The Journal is empty.");
                return;
            }

            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }

        public void SaveToFile(string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                { 
                    string line = $"{entry._date} | {entry._promptText} | {entry._entryText}";
                    writer.WriteLine(line);
                }
            }
        }

        public void LoadFromFile(string file)
        {
            _entries.Clear();

            if (!File.Exists(file))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[]lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (parts.Length == 3)
                {
                    string date = parts[0];
                    string prompt =parts[1];
                    string entryText = parts[2];

                    Entry entry = new Entry(date, prompt, entryText);
                    _entries.Add(entry);
                } 
            }
        }

    }
}