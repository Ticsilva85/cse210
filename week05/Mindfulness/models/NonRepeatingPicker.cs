using System;
using System.Collections.Generic;

public class NonRepeatingPicker<T>
{
    private readonly Random _rng = new Random();
    private readonly List<T> _original;
    private List<T> _bag;

    public NonRepeatingPicker(List<T> items)
    {
        _original = items ?? throw new ArgumentNullException(nameof(items));
        if (_original.Count == 0) throw new ArgumentException("List cannot be empty.");
        _bag = new List<T>(_original);
    }

    // Returns a random item without repetition until all items are used once.
    public T Next()
    {
        if (_bag.Count == 0)
            _bag = new List<T>(_original);

        int index = _rng.Next(_bag.Count);
        T item = _bag[index];
        _bag.RemoveAt(index);
        return item;
    }
}