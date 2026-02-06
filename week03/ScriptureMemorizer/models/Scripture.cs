using System;
using System.Collections.Generic;
using System.Linq;
using ScriptureMemorizer.models;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // ✅ Improvement: keep Random as a field (avoids repetition)
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Only select from words that are NOT already hidden
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < numberToHide; i++)
        {
            if (visibleWords.Count == 0) break;

            int randomIndex = _random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
        }
    }

    // ✅ NEW: reveal random visible word(s) (Hint feature)
    public void RevealRandomWords(int numberToReveal)
    {
        // select from hidden words
        List<Word> hiddenWords = _words.Where(w => w.IsHidden()).ToList();

        for (int i = 0; i < numberToReveal; i++)
        {
            if (hiddenWords.Count == 0) break;

            int randomIndex = _random.Next(hiddenWords.Count);
            hiddenWords[randomIndex].Show();
            hiddenWords.RemoveAt(randomIndex);
        }
    }

    // ✅ NEW: reset everything (useful for testing or extra command later)
    public void Reset()
    {
        foreach (var w in _words)
        {
            w.Show();
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

    // ✅ NEW: progress info
    public int GetTotalWordCount() => _words.Count;

    public int GetHiddenWordCount() => _words.Count(w => w.IsHidden());

    public double GetHiddenPercentage()
    {
        if (_words.Count == 0) return 0;
        return (double)GetHiddenWordCount() / _words.Count * 100.0;
    }
}
