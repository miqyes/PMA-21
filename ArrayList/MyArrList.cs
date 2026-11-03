namespace ArrayList
{
    public class MyArrList<T>
    {
        private T[] array;
        private int capacity;
        private int size;


        public MyArrList()
        {
            Initialize();
        }


        public void Initialize()
        {
            capacity = 4;
            array = new T[capacity];
            size = 0;
        }


        public int GetSize
        {
            get { return size; }
        }



        private void CheckAndResize()
        {
            if (size >= capacity)
            {
                capacity = (int)(capacity * 1.5 + 1);
                T[] newArr = new T[capacity];
                for (int i = 0; i < size; i++)
                {
                    newArr[i] = array[i];
                }

                array = newArr;
            }

        }

        public void Add(T item)
        {
            CheckAndResize();
            array[size] = item;
            size++;

        }

        public void Clear()
        {
            Initialize();
        }

        public T GetItem(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new Exception("Index is in wrong range");

            }

            return array[index];

        }



        public void DeleteByIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new Exception("Index is in wrong range");
            }

            for (int i = index; i < size - 1; i++)
            {
                array[i] = array[i + 1];
            }

            size--;

        }


        public void DeleteByElement(T element)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i].Equals(element))
                {
                    DeleteByIndex(i);
                    return;
                }
            }

            throw new Exception("Couldnt find element in list");
        }


        public void Insert(T element, int index)
        {
            if (index < 0 || index > size)
            {
                throw new Exception("Index is in wrong range");
            }

            CheckAndResize();

            for (int i = size; i > index; i--)
            {
                array[i] = array[i - 1];

            }

            array[index] = element;
            size++;

        }

        public void Output(MyArrList<T> list)
        {

            for (int i = 0; i < size; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();
        }

    }

}
