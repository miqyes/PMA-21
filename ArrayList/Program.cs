namespace arrlist
{
    class Program
    {
        static void Main()
        {
            ArrayList<int> list = new ArrayList<int>();

            try
            {
                Console.WriteLine("List:");
                list.Add(2);
                list.Add(4);
                list.Add(6);
                list.Add(8);
                list.Add(10);
                Console.WriteLine(list);

                Console.WriteLine("Add number 7 with index 3 and number 16 with index 5 to list:");
                list.AddByIndex(3, 7);
                list.AddByIndex(5, 16);
                Console.WriteLine(list);

                Console.WriteLine("Remove numbers 4 and 10 from list:");
                list.Remove(1);
                list.Remove(5);
                Console.WriteLine(list);

                Console.WriteLine("Clear list:");
                list.Clear();
                Console.WriteLine(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

