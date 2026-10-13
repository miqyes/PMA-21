namespace UNI;

    public class Node <T>
    {
        private T element;
        public T Element
        {
            get
            {
                return element;
            }
            set
            {
                element = value;
            }
        }

        public Node<T> next
        {
            get;
            set;
        }

        public Node<T> prev
        {
            get;
            set;
        }

        public Node(T el)
        {
            Element = el;
            next = null;
            prev = null;
        }
    }