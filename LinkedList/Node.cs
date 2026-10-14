namespace linkList;

public class Node<T>
{
    private T data;
    private Node<T> next;
    private Node<T> previous;
    
    public Node(T data, Node<T> next, Node<T> previous)
    {
        this.data = data;
        this.next = next;
        this.previous = previous;
    }

    public T Data
    {
        get
        {
            return data;
        }
        set
        {
            data = value;
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
}
