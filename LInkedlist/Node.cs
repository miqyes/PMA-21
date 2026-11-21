public class Node<T>
{
    public T Data;
    public Node<T> Next;
    public Node<T> Prev;

    public Node(T Value)
    {
        Data = Value;
        Next = null;
        Prev = null;
    }
}