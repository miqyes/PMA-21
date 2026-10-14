namespace linkList;

public class LinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;
    private int count;

    public Node<T> Head
    {
        get
        {
            return head;
        }
        set
        {
            head = value;
        }
    }

    public Node<T> Tail
    {
        get
        {
            return tail;
        }
        set
        {
            tail = value;
        }
    }

    public int Size
    {
        get
        {
            return count;
        }
    }

    public LinkedList()
    {
        this.head = null;
        this.tail = null;
        this.count = 0;
    }

    public bool IsEmpty()
    {
        return this.count == 0;
    }

    public override string ToString()
    {
        string result = "";
        Node<T> current = this.head;

        while (current != null)
        {
            result += current.Data + " ";
            current = current.Next;
        }

        return result;
    }
    
    public void Add(T value)
    {
        Node<T> newNode;
        if (IsEmpty())
        {
            newNode = new Node<T>(value, null, null);
            head = newNode;
        }
        else
        {
            newNode = new Node<T>(value, null, tail);
            tail.Next = newNode;
        }
//set map list queue stack 
        tail = newNode;
        count++;
    }
    public void AddByIndex(int index, T value)
    {
        Node<T> newNode;
        if (index < 0 || index > count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Error: invalid index!");
        }
        
        if (IsEmpty())
        {
            newNode = new Node<T>(value, null, null);
            head = newNode;
            tail = newNode;
        }
        
        else if (index == 0)
        {
            newNode = new Node<T>(value, head, null);
            head.Previous = newNode;
            head = newNode;
        }
        
        else if (index == count)
        {
            newNode = new Node<T>(value, null, tail);
            tail.Next = newNode;
            tail = newNode;
        }
        
        else
        {
            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode = new Node<T>(value, current.Next, current);
            current.Next.Previous = newNode;
            current.Next = newNode;
        }
        count++;
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Error: invalid index!");
        }
        
        T result;

        if (count == 1)
        {
            result = head.Data;
            head = null;
            tail = null;
        }
        else if (index == 0)
        {
            result = head.Data;
            head = head.Next;
            head.Previous = null;
        }
        else if (index == count - 1)
        {
            result = tail.Data;
            tail = tail.Previous;
            tail.Next = null;
        }
        else
        {
            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            result = current.Data;
            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
        }

        count--;
        return result;
    }

    public void Clear()
    {
        this.head = null;
        this.tail = null;
        this.count = 0;
    }
}
