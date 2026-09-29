namespace Task7;
class Program {
    static void Main() {
        LinkedList<int> list = new LinkedList<int>();
        Console.WriteLine(list);

        list.Add(10);
        Console.WriteLine("1.Add(10):");
        Console.WriteLine(list);

        list.Add(20);
        Console.WriteLine("2.Add(20):");
        Console.WriteLine(list);

        list.Add(30);
        Console.WriteLine("3.Add(30):");
        Console.WriteLine(list);

        Console.WriteLine("\n4. AddIndex(5, 0) —add to beginning:");
        list.AddIndex(5, 0);
        Console.WriteLine(list);

        Console.WriteLine("\n5. AddIndex(15, 2) — add to the middle:");
        list.AddIndex(15, 2);
        Console.WriteLine(list);

        Console.WriteLine("\n6. AddIndex(40, list.Count) — add to the end:");
        list.AddIndex(40, list.Count);
        Console.WriteLine(list);
        

        Console.WriteLine("7.Delete the last element:");
        list.Delete();
        Console.WriteLine(list);
        
        Console.WriteLine("\n8. DeleteIndex(0) — delete first element:");
        list.DeleteIndex(0);
        Console.WriteLine(list);
        
        Console.WriteLine("\n9. DeleteIndex(2) — delete from middle:");
        list.DeleteIndex(2);
        Console.WriteLine(list);

        Console.WriteLine("\n10. DeleteIndex(list.Count - 1) — delete the last:");
        list.DeleteIndex(list.Count - 1);
        Console.WriteLine(list);
        
        Console.WriteLine("11.List after Clear():");
        list.Clear();
        Console.WriteLine(list);

        Console.WriteLine("\n12. Test constructor params:");
        LinkedList<int> list2 = new LinkedList<int>(1, 2, 3, 4, 5);
        Console.WriteLine(list2);


        Console.WriteLine("\n13. Test LinkedList<string>:");
        LinkedList<string> names =
            new LinkedList<string>("Anna", "Oleh", "Ivan");

        Console.WriteLine(names);
        names.Add("Petro");
        Console.WriteLine("14.After Add(\"Petro\"):");
        Console.WriteLine(names);

        names.AddIndex("Maria", 1);
        Console.WriteLine("15.After AddIndex(\"Maria\", 1):");
        Console.WriteLine(names);

        names.DeleteIndex(2);
        Console.WriteLine("16.After DeleteIndex(2):");
        Console.WriteLine(names);


        Console.WriteLine("\n17. Error handling attempt:");
        try {
            names.AddIndex("Test", 100); }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}"); }

        try {
            names.DeleteIndex(-1); }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}"); }
    }
}