namespace Task7;

class LinkedList<T> {
    private Node<T> _head;
    private Node<T> _tail;
    private int _count;

    public LinkedList()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public LinkedList(params T[] data)
    {
        _head = null;
        _tail = null;
        _count = 0;
        foreach(var element in data)
            Add(element);
    }

    public int Count
    {
        get { return _count; }
    }

    public void Add(T element) {
        Node<T> newNode = new Node<T>(element);
        if (_count == 0)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            _tail = newNode;
        }

        _count++; }

    public void AddIndex(T element, int index)
    {
        if (index < 0 || index > _count)
            throw new Exception("Invalid index");
        Node<T> newNode = new Node<T>(element);
        if (_count == 0)
        {
            _head = newNode;
            _tail = newNode;
        }
        else if (index == 0)
        {
            newNode.Next = _head;
            _head = newNode;
        }
        else if (index == _count){
            Add(element);
        return;
    }
    else
    {
            Node<T> current = _head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            newNode.Previous = current.Previous;
            newNode.Next = current;
        }
        _count++;
    }


    public void Delete()
    {
        if (_count == 0)
            return;
        if (_count == 1) {
            _head = null;
            _tail = null; }
        else {
            _tail = _tail.Previous;
            _tail.Next = null; }
        _count--;
    }

    public void DeleteIndex(int index) {
        if (index < 0 || index >= _count)
            throw new Exception("Invalid index");
        Node<T> current = _head;
        for (int i = 0; i < index; i++)
            current = current.Next;
        if (_count == 1) {
            _head = null;
            _tail = null;
        }
        else if (index == 0) {
            _head = current.Next;
            _head.Previous = null;
        }
        else if (index == _count - 1)
        {
            Delete();
            return;
        }
        else
            current.Previous.Next = current.Next;
        _count--;
    }

    public void Clear() {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public override string ToString() {
        string res = $"Linked List type: {typeof(T)} with size {_count} and element: ";
        if (_count == 0)
            res += "none :(";
        else
        {
            Node<T> current = _head;
            
            for (int i = 0; i < _count; i++)
            {
                res += current.Element;
                if (current.Next != null)
                    res += ",";
                current = current.Next;
            }
        }

        return res;
    }
}