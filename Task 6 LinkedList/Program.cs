class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();

        list.AddLast(20);
        list.AddLast(30);
        Console.Write("After AddLast: ");
        list.Print();
        list.AddFirst(10);
        Console.Write("After AddFirst: ");
        list.Print();

        list.AddIndex(2, 25);
        Console.Write("After adding element 25 on idnex 2: ");
        list.Print();

        Console.Write("Reversed: ");
        list.PrintReverse();

        Console.WriteLine("Index of 30: " + list.GetIndex(30));
        Console.WriteLine("Element at index 1: " + list.GetElement(1));

        list.Remove(25);
        Console.Write("After Remove element 25: ");
        list.Print();

        Console.WriteLine("Getting index of unexisting element 505: " + list.GetIndex(505));

        list.RemoveIndex(1);
        Console.Write("After RemoveIndex at index 1: ");
        list.Print();

        list.RemoveFirst();
        Console.Write("After RemoveFirst: ");
        list.Print();

        list.RemoveLast();
        Console.Write("After RemoveLast: ");
        list.Print();
        Console.WriteLine("Count: " + list.Count);

        list.AddLast(1);
        list.AddLast(2);
        Console.Write("After AddLast: ");
        list.Print();
        list.Clear();
        Console.WriteLine("Count after Clear: " + list.Count);
    }
}