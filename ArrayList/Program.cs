using System;
namespace UNI
{
    class Program
    {
        static void Main()
        {
            ArrayList arr = new ArrayList(4);

            arr.add(1);
            arr.add(4);
            arr.add(7);
            arr.add(9);
            Console.WriteLine("Array: ");
            arr.print();

            arr.addindex(3, 5);
            Console.WriteLine("Array after adding 5 on 3d position: ");
            arr.print();

            arr.delete(4);
            Console.WriteLine("Array after deleting element ob 4th position: ");
            arr.print();

            arr.clear();
            Console.WriteLine("Array after clearing: ");
            arr.print();
        }
    }
}