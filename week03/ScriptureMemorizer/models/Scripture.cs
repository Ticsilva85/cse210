using System;
using System.Collections.Generic;
using System.Linq;
using ScriptureMemorizer.models;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        // Split text by spaces and convert each string into a Word object
        string[] splitWords = text.Split(' ');
        foreach (string wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        
        // "Stretch Challenge": Only select from words that are NOT already hidden
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < numberToHide; i++)
        {
            if (visibleWords.Count == 0) break;

            int randomIndex = random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex); // Remove from temporary list so we don't pick it again
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} - {scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}