using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Entry<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }
    public Entry<TKey, TValue>? Next { get; set; }

    public Entry(TKey key, TValue val)
    {
        Key = key;
        Value = val;
        Next = null;
    }
}

public class Wordhord<TKey, TValue>
{
    private Entry<TKey, TValue>?[] _buckets;
    private int _count;
    public int Count => _count;

    public Wordhord(int capicity = 16)
    {
        if (capicity <= 0)
        {
            throw new ArgumentOutOfRangeException("Ємність повинна бути більшою за нуль.");
        }

        _buckets = new Entry<TKey, TValue>?[capicity];
        _count = 0;
    }
    
    private int GetBucketIndex(TKey key)
    {
        if (key == null)
        {
            throw new ArgumentNullException("Ключ не може бути null.");
        }

        return Math.Abs(key.GetHashCode()) % _buckets.Length;
    }
    
    private Entry<TKey, TValue>? FindEntry(TKey key)
    {
        int index = GetBucketIndex(key);
        Entry<TKey, TValue>? current = _buckets[index];
        
        while (current != null)
        {
            if (object.Equals(current.Key, key))
            {
                return current; 
            }
            current = current.Next;
        }
        return null;
    }

    public TValue this[TKey key]
    {
        get
        {
            var entry = FindEntry(key);
            if (entry == null)
            {
                throw new KeyNotFoundException($"Ключ '{key}' не знайдено.");
            }
            return entry.Value;
        }
        set
        {
            var entry = FindEntry(key);
            if (entry != null)
                entry.Value = value;
            else
                Add(key, value);
        }
    }

    // ДІЇ З СЛОВНИКОМ
    public void Add(TKey key, TValue val)
    {
        if (FindEntry(key) != null)
        {
            throw new ArgumentException($"Ключ '{key}' вже існує.");
        }

        int index = GetBucketIndex(key);
        _buckets[index] = new Entry<TKey, TValue>(key, val) { Next = _buckets[index] };
        _count++;
    }

    public bool Remove(TKey key)
    {
        int index = GetBucketIndex(key);
        Entry<TKey, TValue>? current = _buckets[index];
        Entry<TKey, TValue>? previous = null;
        
        while (current != null)
        {
            if (EqualityComparer<TKey>.Default.Equals(current.Key, key))
            {
                if (previous == null)
                    _buckets[index] = current.Next;
                else
                    previous.Next = current.Next;

                _count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }

    public void PrintAll()
    {
        PrintTo(Console.Out);
        Console.WriteLine();
    }
    public void PrintAll(string filePath, bool append = false)
    {
        using (StreamWriter writer = new StreamWriter(filePath, append))
        {
            writer.WriteLine($"\n--- Вміст словника (всього елементів: {_count}) ---");
            if (_count == 0)
            {
                writer.WriteLine("[Порожньо]");
                return;
            }

            for (int i = 0; i < _buckets.Length; i++)
            {
                Entry<TKey, TValue>? current = _buckets[i];
                while (current != null)
                {
                    writer.WriteLine($"  [{current.Key}] => {current.Value}");
                    current = current.Next;
                }
            }
        }
    }
    private void PrintTo(TextWriter writer)
    {
        writer.WriteLine($"--- Вміст словника (всього елементів: {_count}) ---");
        if (_count == 0)
        {
            writer.WriteLine("[Порожньо]");
            return;
        }

        for (int i = 0; i < _buckets.Length; i++)
        {
            Entry<TKey, TValue>? current = _buckets[i];
            while (current != null)
            {
                writer.WriteLine($"  [{current.Key}] => {current.Value}");
                current = current.Next;
            }
        }
    }
}
    
    