namespace LinkedList;

public class LinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;
    private int size;

    public int Size
    {
        get
        { 
            return size;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Індекс виходить за межі списку.");
            }
            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Element;
        } 
    }
    public LinkedList()
    {
        head = null;
        tail = null;
        size=0;
    }

    public void add(T item)
    {
        Node<T> newNode = new Node<T>(item);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
        size++;
    }
    public void insertByIndex(int index, T item)
    {
        if (index < 0 || index > size)
        {
            throw new Exception("Індекс вийшов за межі LinkedList");
        }

        Node<T> newNode = new Node<T>(item);

        if (index == size)
        {
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }
        else if (index == 0)
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            Node<T> prev = current.Previous;
            prev.Next = newNode;
            newNode.Previous = prev;
            newNode.Next = current;
            current.Previous = newNode;
        }

        size++;
    }
    public void delete(T item)
    {
        Node<T> current = head;
        bool found = false;
        for (int i = 0; i < size; i++)
        {
            if (current.Element.Equals(item))
            {
                found = true;
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next; 
                }
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                    
                }
                else
                {
                    tail = current.Previous; 
                }
                size--;
                return; 
            }
            current = current.Next;
        }

        if (!found)
        {
            throw new Exception(" Біда");
        }
    }
    public void deleteByIndex(int index)
    {
        if (index < 0 || index >= size)
        {
            throw new Exception("Індекс вийшов за межі LinkedList");
        }

        Node<T> nodeToDelete = head;
        for (int i = 0; i < index; i++)
        {
            nodeToDelete = nodeToDelete.Next;
        }

        if (nodeToDelete.Previous != null)
        {
            nodeToDelete.Previous.Next = nodeToDelete.Next;
        }
        else
        {
            head = nodeToDelete.Next; 
        }
        if (nodeToDelete.Next != null)
        {
            nodeToDelete.Next.Previous = nodeToDelete.Previous;
        }
        else
        {
            tail = nodeToDelete.Previous; 
        }
        size--;
    }
    public void clear()
    {
        head = null;
        tail = null;
        size = 0;
    }
}