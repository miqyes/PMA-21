namespace UNI;

public class LinkedList<T>
{
    private Node<T> top;
    private Node<T> last;

    public int count
    {
        get;
        private set;
    }

    public void add(T value)
    {
        Node<T> newnode = new Node<T>(value);

        if (top == null)
        {
            top=newnode;
            last=newnode;
        }
        else
        {
            last.next = newnode;
            newnode.prev = last;
            last = newnode;
        }

        count++;
    }

    public void delete(int i)
    {
        if (i < 0 || i > count)
        {
            throw new ArgumentOutOfRangeException(nameof(i), "No index like this");
        }

        Node<T> remove = top;
        for (int j = 0; j < i; j++)
        {
            remove = remove.next;
        }

        if (remove == top)
        {
            top = top.next;
        }
        else
        {
            remove.prev.next = remove.next;
        }

        if (remove == last)
        {
            last = last.prev;
        }
        else
        {
            remove.next.prev = remove.prev;
        }
        
        count--;
    }


    public void index(int i,T value)
    {
        if (i < 0 || i > count)
        {
            throw new ArgumentOutOfRangeException(nameof(i),"No index like this");
        }
        if (i==count)
        {
            add(value);
            return;
        }

        Node<T> newnode = new Node<T>(value);
        if (i == 0)
        {
            newnode.next = top;
            top.prev = newnode;
            top=newnode;
        }
        else
        {
            Node<T> curnode = top;
            for (int j = 0; j < i; j++)
            {
                curnode = curnode.next;
            }
            Node<T> prevnode = curnode.prev;
            newnode.prev = prevnode;
            prevnode.next = newnode;
            newnode.next = curnode;
            curnode.prev = newnode;
        }

        count++;
    }

    public void clear()
    {
        top = null;
        last = null;
        count = 0;
    }

    public void print()
    {
        Node<T> current = top;
        while (current != null)
        {
            Console.Write(current.Element + " ");
            current = current.next;
        }
        Console.WriteLine("null");
    }
}