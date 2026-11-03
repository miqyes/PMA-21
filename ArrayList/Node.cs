namespace LinkedList;

public class Node<T>
{
    private T element;
    private Node<T> previous;
    private Node<T> next;

    public T Element
    {
        get
        {
            return element;
        }
    }

    public Node<T> Previous
    {
        get
        {
            return previous;
        }
        set
        {
            previous = value;
        }
    }

    public Node<T> Next
    {
        get
        {
            return next;
        }
        set
        {
            next = value;
        }
    }

    public Node(T element)
    {
        this.element = element;
        previous = null;
        next = null;
    }
}