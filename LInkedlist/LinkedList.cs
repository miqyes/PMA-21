using System;
public class LinkedList<T>
{
    private Node<T> Head;
    private Node<T> Tail;
    private int Count;

    public LinkedList()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }
    public int GetCount()
    {
        return Count;
    }

    public void Add(T Value)
    {
        Node<T> NewNode = new Node<T>(Value);
        if (Head == null)
        {
            Head = NewNode;
            Tail = NewNode;
        }
        else
        {
            Tail.Next = NewNode;
            NewNode.Prev = Tail;
            Tail = NewNode;
        }
        Count++;
    }

    public void Insert(int Index, T Value)
    {
        if (Index < 0 || Index > Count)
        {
            Console.WriteLine("Invalid index!");
            return;
        }
        if (Index == Count)
        {
            Add(Value);
            return;
        }
        Node<T> NewNode = new Node<T>(Value);
        if (Index == 0)
        {
            NewNode.Next = Head;
            Head.Prev = NewNode;
            Head = NewNode;
        }
        else
        {
            Node<T> Current = Head;
            for(int Step = 0; Step < Index; Step++)
            {
                Current = Current.Next;
            }
            NewNode.Prev = Current.Prev;
            NewNode.Next = Current;
            Current.Prev.Next = NewNode;
            Current.Prev = NewNode;
        }
        Count++;
    }

    public bool Remove(T Value)
    {
        Node<T> Current = Head;
        while(Current != null)
        {
            if (object.Equals(Current.Data, Value))
            {
                if (Current == Head && Current == Tail)
                {
                    Head = null;
                    Tail = null;
                } else if (Current == Head)
                {
                    Head = Head.Next;
                    Head.Prev = null;
                }else if (Current == Tail)
                {
                    Tail = Tail.Prev;
                    Tail.Next = null;
                }
                else
                {
                    Current.Prev.Next = Current.Next;
                    Current.Next.Prev = Current.Prev;
                }
                Count--;
                return true;
            }
            Current = Current.Next;
        }
        return false;
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public void Print()
    {
        if (Head == null)
        {
            Console.WriteLine("The list is empty!");
            return;
        }
        Node<T> Current = Head;
        while(Current != null)
        {
            Console.Write(Current.Data + " ");
            Current = Current.Next;
        }
        Console.WriteLine();
    }
}