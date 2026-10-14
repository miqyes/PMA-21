namespace arrlist;

public class ArrayList<T>
{
    private T[] elements;
    private int count;
    private int capacity;
    
    public int Count
    {
        get
        {
            return count;
        }
    }

    public int Capacity
    {
        get
        {
            return elements.Length;
        }
    }
    
    public ArrayList()
    {
        capacity = 10;
        elements = new T[capacity];
        count = 0;
    }

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < count; i++)
        {
            result += elements[i] + " ";
        }

        return result;
    }

    private void Resize()
    {
        int newCapacity = (int) (capacity * 1.5 + 1);
        T[] newElements = new T[newCapacity];
        for (int i = 0; i < count; i++)
        {
            newElements[i] = elements[i];
        }
        
        elements = newElements;
        capacity = newCapacity;
    }
        
    public void Add(T value)
    {
        if (count == capacity)
        {
            Resize();
        }

        elements[count] = value;
        count++;
    }

    public void AddByIndex(int index, T value)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Error: invalid index!");
        }

        if (count == capacity)
        {
            Resize();
        }

        for (int i = count; i > index; i--)
        {
            elements[i] = elements[i - 1];
        }

        elements[index] = value;
        count++;
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Error: invalid index!");
        }

        for (int i = index; i < count - 1; i++)
        {
            elements[i] = elements[i + 1];
        }

        count--;
    }

    public void Clear()
    {
        count = 0;
    }
}
