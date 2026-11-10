using System;


class Program
{
    static void Main()
    {
        ArrayList list = new ArrayList();

        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(40);
        list.Add(50);
        list.Add(60);
        list.Add(70);
        Console.WriteLine("Capacity after adding elements: " + list.Capacity);
        Console.WriteLine("After adding elements:");
        list.Print();

        list.Insert(2, 25);
        Console.WriteLine("After inserting 25 at index 2:");
        list.Print();

        list.RemoveAt(1);
        Console.WriteLine("After removing element at index 1:");
        list.Print();

        list.Remove(40);
        Console.WriteLine("After removing number 40:");
        list.Print();

        Console.WriteLine("Element at index 1: " + list.Get(1));

        list.Set(1, 100);
        Console.WriteLine("After replacing element:");
        list.Print();

        /*list.Clear();
        Console.WriteLine("After clearing the list:");
        list.Print();
        */
        Console.WriteLine("Capacity:" + list.Capacity);
        Console.WriteLine("Number of elements: " + list.Count);
    }
}

