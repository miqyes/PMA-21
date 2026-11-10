using System;

public class ArrayList
{
    private int[] items;
    private int count{ get; set; } 

    public ArrayList()
    {
        items = new int[6];
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    public int Capacity
    {
        get { return items.Length; }
    }

    private void Resize()
    {
        int newSize = items.Length * 3 / 2 + 1;
        int[] newItems = new int[newSize];

        for (int i = 0; i < count; i++)
        {
            newItems[i] = items[i];
        }

        items = newItems;
    }

    public void Add(int value)
    {
        if (count == items.Length)
        {
            Resize();
        }

        items[count] = value;
        count++;
    }

    public int Get(int index) 
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException();
        }

        return items[index];
    }

    public void Set(int index, int value) 
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException();
        }

        items[index] = value;
    }

    public void Insert(int index, int value)
    {
        if (index < 0 || index > count)
        {
            throw new IndexOutOfRangeException();
        }

        if (count == items.Length)
        {
            Resize();
        }

        for (int i = count; i > index; i--)
        {
            items[i] = items[i - 1];
        }

        items[index] = value;
        count++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        count--;
        items[count] = 0;
    }

    public bool Remove(int value)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[i] == value)
            {
                RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    public void Clear()
    {
        items = new int[10];
        count = 0;
    }

    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(items[i] + " ");
        }

        Console.WriteLine();
    }
}
