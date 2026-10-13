using System;

class ArrayList
{
    const int START_CAPACITY = 10;

    private int[] elements;
    private int count;

    public ArrayList()
    {
        elements = new int[START_CAPACITY];
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    public int Capacity
    {
        get { return elements.Length; }
    }

    private void Expand()
    {
        int newSize = (int)(1.5 * elements.Length) + 1;
        int[] newElements = new int[newSize];

        for (int i = 0; i < count; i++)
        {
            newElements[i] = elements[i];
        }

        elements = newElements;
    }

    public void Add(int value)
    {
        if (count == elements.Length)
        {
            Expand();
        }

        elements[count] = value;
        count++;
    }

    public bool Insert(int index, int value) // п->п
    {
        if (index < 0 || index > count)
        {
            return false;
        }

        if (count == elements.Length)
        {
            Expand();
        }

        for (int i = count; i > index; i--) // л<-п
        {
            elements[i] = elements[i - 1];
        }

        elements[index] = value;
        count++;

        return true;
    }

    public bool RemoveByIndex(int index) //п->л
    {
        if (index < 0 || index >= count)
        {
            return false;
        }

        for (int i = index; i < count - 1; i++) // л->п
        {
            elements[i] = elements[i + 1];
        }

        count--;

        return true;
    }

    // Видалення першого елемента з вказаним значенням
    public bool RemoveByValue(int value)
    {
        for (int i = 0; i < count; i++)
        {
            if (elements[i] == value)
            {
                return RemoveByIndex(i);
            }
        }

        return false;
    }

    public void Clear()
    {
        elements = new int[START_CAPACITY];
        count = 0;
    }

    public override string ToString()
    {
        string result = "(";

        for (int i = 0; i < count; i++)
        {
            if (i > 0)
            {
                result += ", ";
            }

            result += elements[i];
        }

        return result + ")";
    }
}