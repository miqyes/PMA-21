class Program
{
    static void Main()
    {
        ArrayList<int> list = new ArrayList<int>();

        for (int i = 1; i <= 10; i++)
        {
            list.Add(i);
        }
        Console.WriteLine("Added 10 elements:");
        list.Print();

        list.Add(11);
        Console.WriteLine("Added 11 element:");
        list.Print();

        list.Insert(2, 100);
        Console.WriteLine("Inserted 100 at position 2:");
        list.Print();

        Console.WriteLine("Get value of index 2 = " + list.Get(2));
        Console.WriteLine("Get index of 100 = " + list.IndexOf(100));
        Console.WriteLine("Get index of 555 = " + list.IndexOf(555));
        Console.WriteLine();

        list.RemoveAt(0);
        Console.WriteLine("Removed the element at index 0:");
        list.Print();

        list.Remove(100);
        Console.WriteLine("Removed the value 100:");
        list.Print();

        list.Clear();
        Console.WriteLine("Cleared the list:");
        list.Print();

        ArrayList<string> words = new ArrayList<string>();
        words.Add("Hello");
        words.Add("world");
        words.Insert(1, "beautiful");
        Console.WriteLine("List of strings:");
        words.Print();
        Console.WriteLine("Get index of world = " + words.IndexOf("world"));
    }
}