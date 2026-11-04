class ArrayList<T>
{
    private T[] array;
    private int count;

    public ArrayList()
    {
        array = new T[10];
        count = 0;
    }

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
            return array.Length; 
        }
    }

    private void Expand()
    {
        int newSize = (int)(1.5 * array.Length) + 1;
        T[] newArray = new T[newSize];

        for (int i = 0; i < count; i++)
        {
            newArray[i] = array[i];
        }

        array = newArray;
    }

    public void Add(T value)
    {
        if (count == array.Length)
        {
            Expand();
        }

        array[count] = value;
        count++;
    }

    public void Insert(int index, T value)
    {
        if (index < 0 || index > count)
        {
            Console.WriteLine("Wrong index");
            return;
        }

        if (count == array.Length)
        {
            Expand();
        }

        for (int i = count; i > index; i--)
        {
            array[i] = array[i - 1];
        }

        array[index] = value;
        count++;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Wrong index");
            return default(T);
        }

        return array[index];
    }

    public int IndexOf(T value)
    {
        for (int i = 0; i < count; i++)
        {
            if (array[i].Equals(value))
            {
                return i;
            }
        }

        return -1;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Wrong index");
            return;
        }

        for (int i = index; i < count - 1; i++)
        {
            array[i] = array[i + 1];
        }

        count--;
    }

    public void Remove(T value)
    {
        int index = IndexOf(value);

        if (index == -1)
        {
            Console.WriteLine("Element not found");
            return;
        }

        RemoveAt(index);
    }

    public void Clear()
    {
        array = new T[10];
        count = 0;
    }

    public void Print()
    {
        Console.Write("Elements: ");
        for (int i = 0; i < count; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Count: " + count + ", array size: " + array.Length);
        Console.WriteLine();
    }
}