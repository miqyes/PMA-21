using System;
using System.Collections;
using System.Collections.Generic;

public class ArrayList<T> 
{
    private T[] _items;
    private int _count;

    public int Count => _count;
    public int Capacity => _items.Length;

    public ArrayList(int initialCapacity = 4)
    {
        if (initialCapacity < 0)
            throw new ArgumentOutOfRangeException("initialCapacity", "The initial capacity cannot be less than zero.");

        _items = new T[initialCapacity];
        _count = 0;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException("index", "Index out of bounds");
            return _items[index];
        }
    }

    private void Grow()
    {
        int newCapacity = (_items.Length * 3) / 2 + 1;

        T[] newArray = new T[newCapacity];
        Array.Copy(_items, newArray, _count);
        _items = newArray;
    }

    public void Clear()
    {
        Array.Clear(_items, 0, _count);
        _count = 0;
    }

    public int IndexOf(T item)  
    {
        for (int i = 0; i < _count; i++)
        {
            if (object.Equals(_items[i], item))
            {
                return i;
            }
        }
        return -1;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException("index", "Index out of bounds");

        for (int i = index; i < _count - 1; i++)
            _items[i] = _items[i + 1];

        _count--;
        _items[_count] = default;
    }

    public void Add(T item)
    {
        if (_count == _items.Length)
                Grow();
        _items[_count] = item;
        _count++;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > _count)
            throw new ArgumentOutOfRangeException("index", "Index out of bounds");
        if (_count == _items.Length)
            Grow();

        for (int i = _count; i > index; i--)
            _items[i] = _items[i -1];

        _items[index] = item;
        _count++;
    }
}
