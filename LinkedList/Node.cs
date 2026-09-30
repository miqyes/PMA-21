namespace Task7;
class Node<T>
{
    private T _element;
    private Node<T> _previous;
    private Node<T> _next;

    public T Element
    {
        get { return _element; }
    }
    public Node<T> Previous
    {
        get { return _previous; }
        set {
            _previous = value;
            if (value != null)
                value._next = this; }
    }

    public Node<T> Next {
        get { return _next; }
        set {
            _next = value;
            if (value != null)
                value._previous = this; }
    }

    public Node(T element) {
        _element = element;
        _previous = null;
        _next = null; }
}