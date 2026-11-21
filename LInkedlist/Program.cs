using System;
using System.IO;

class Program
{
    public const string Filename = "result.txt";
    static void Main()
    {
        ArrayList<int> arrayList = new ArrayList<int>();
        LinkedList<int> linkedList = new LinkedList<int>();

        Console.Write("Enter how many numbers to add: ");
        int n = int.Parse(Console.ReadLine());

        for(int i = 0; i < n; i++)
        {
            Console.Write("Number: ");
            int val = int.Parse(Console.ReadLine());
            arrayList.Add(val);
            linkedList.Add(val);
        }
        Console.WriteLine("\nArrayList: ");
        arrayList.Print();
        Console.WriteLine("\nLinkedList: ");
        linkedList.Print();

        Console.Write("\nInsert(index): ");
        int insertIndex = int.Parse(Console.ReadLine());
        Console.Write("\nInsert(value): ");
        int insertValue = int.Parse(Console.ReadLine());

        arrayList.Insert(insertIndex, insertValue);
        linkedList.Insert(insertIndex, insertValue);

        Console.WriteLine("\nArrayList after insert: ");
        arrayList.Print();
        Console.WriteLine("\nLinkedList after insert: ");
        linkedList.Print();

        Console.Write("\nRemove number: ");
        int removeValue = int.Parse(Console.ReadLine());

        arrayList.Remove(removeValue);
        linkedList.Remove(removeValue);

        Console.WriteLine("\nArrayList after remove: ");
        arrayList.Print();
        Console.WriteLine("\nLinkedList after remove: ");
        linkedList.Print();

        arrayList.Clear();
        linkedList.Clear();

        Console.WriteLine("Array after clear:");
        arrayList.Print();
        Console.WriteLine("LInked after clear:");
        linkedList.Print();

        string result = "Program finished.\n" + $"Added {n} elements.\n" + $"Value to insert {insertValue} at index {insertIndex}.\n" + $"Value to remove {removeValue}.\n" + "Lists cleared.";

        File.WriteAllText(Filename, result);
    }
}