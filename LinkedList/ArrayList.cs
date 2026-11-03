namespace arrayList;

public class ArrayList<T>
{
    private T[] elements;
    private int capacity;
    private int size;

    public int Size
    {
        get
        {
            return size;
        }
    }

    public int Capacity
    {
        get
        {
            return capacity;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index >= size || index < 0)
            {
                throw new Exception("Індекс вийшов за межі ArrayList ");
            }
            return elements[index];
        }
    }

    public ArrayList()
    {
        capacity = 10;
        elements = new T[capacity];
        size = 0;
    }

    public ArrayList(int capacity)
    {
        this.capacity = capacity;
        elements = new T[this.capacity];
        size = 0;
    }

    private void resize()
    {
        capacity = (int)(capacity * 1.5 + 1);
        T[] newelements = new T[capacity];
        for (int i = 0; i < size; i++)
        {
            newelements[i] = elements[i];
        }

        elements = newelements;
    }

    public void add(T newElement)
    {
        if (size >= capacity)
        {
            resize();
        }

        elements[size] = newElement;
        size++;
    }

    public void delete(T number)
    {
        bool found = false;
        for (int i = 0; i < size; i++)
        {
            if (elements[i].Equals(number))
            {
                found = true;
                for (int j = i; j < size - 1; j++)
                {
                    elements[j] = elements[j + 1];
                }
                size--;
                elements[size] = default;
            }
        }

        if (!found)
        {
            throw new Exception("Немає такого елемента у масиві");
        }
    }

    public void insertByIndex(int index, T newElement)
    {
        if (index >= size || index < 0)
        {
            throw new Exception("Індекс вийшов за межі ArrayList ");
        }

        if (size >= capacity)
        {
            resize();
        }

        for (int i = size; i > index; i--)
        {
            elements[i] = elements[i - 1];
        }

        elements[index] = newElement;
        size++;
    }

    public void deleteByIndex(int index)
    {
        if (index >= size || index < 0)
        {
            throw new Exception("Індекс вийшов за межі ArrayList ");
        }

        for (int i = index; i < size - 1; i++)
        {
            elements[i] = elements[i + 1];
        }

        size--;
        elements[size] = default;
    }
    
    public void clear()
    {
        for (int i = 0; i < size; i++)
        {
            elements[i] = default;
        }
        size = 0;
    }
}