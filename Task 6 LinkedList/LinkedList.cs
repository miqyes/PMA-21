class LinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;
    private int count;

    public int Count
    {
        get
        {
            return count;
        }
    }

    public void AddFirst(T value)
    {
        Node<T> node = new Node<T>(value);

        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.Next = head;
            head.Prev = node;
            head = node;
        }
        count++;
    }

    public void AddLast(T value)
    {
        Node<T> node = new Node<T>(value);

        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            tail.Next = node;
            node.Prev = tail;
            tail = node;
        }
        count++;
    }

    public void AddIndex(int index, T value)
    {
        if (index < 0 || index > count)
            throw new IndexOutOfRangeException();

        if (index == 0)
        {
            AddFirst(value);
        }
        else if (index == count)
        {
            AddLast(value);
        }
        else
        {
            Node<T> next = GetNode(index);
            Node<T> prev = next.Prev;
            Node<T> node = new Node<T>(value);

            prev.Next = node;
            node.Prev = prev;
            node.Next = next;
            next.Prev = node;
            count++;
        }
    }

    public void Remove(T value)
    {
        int index = GetIndex(value);
        if (index != -1)
            RemoveIndex(index);
    }

    public void RemoveIndex(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        Node<T> node = GetNode(index);

        if (node.Prev != null)
            node.Prev.Next = node.Next;
        else
            head = node.Next;

        if (node.Next != null)
            node.Next.Prev = node.Prev;
        else
            tail = node.Prev;

        count--;
    }

    public void RemoveFirst()
    {
        if (count > 0)
            RemoveIndex(0);
    }

    public void RemoveLast()
    {
        if (count > 0)
            RemoveIndex(count - 1);
    }

    public int GetIndex(T value)
    {
        Node<T> current = head;
        int index = 0;

        while (current != null)
        {
            if (Equals(current.Value, value))
                return index;
            current = current.Next;
            index++;
        }
        return -1;
    }

    public T GetElement(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        return GetNode(index).Value;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    private Node<T> GetNode(int index)
    {
        Node<T> current = head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current;
    }

    public void Print()
    {
        Node<T> current = head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void PrintReverse()
    {
        Node<T> current = tail;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Prev;
        }
        Console.WriteLine();
    }
}