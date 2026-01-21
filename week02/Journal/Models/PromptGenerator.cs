using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Journal.Models
{
    public class PromptGenerator
    {
        private List<string> _prompts;
        private Random _random;

        public PromptGenerator()
        {
            _random= new Random();
            _prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What is something small that made me smile today?",
                "What challenge did I face today, and how did I handle it?",
                "What is something new I learned today?",
                "What part of the scriptures did I study today?",
                "What attribute of the Savior did I practice today?"
            };
        }

        // EXTRA FOR CREATIVITY CREDIT //
        public string GetRandomPrompt()
        {
            // When all the prompts are used, it permits free entries until the user decides to end
            if (_prompts.Count == 0)
            {
                return "What else do you want to say about today? ";
            }

            int index =_random.Next(_prompts.Count);
            string prompt = _prompts[index];

            _prompts.RemoveAt(index); // No prompts repeated
            return prompt;
        }
    }
}