namespace UNI
{
   class Program
   {
      static void Main()
      {
         LinkedList<int> list = new LinkedList<int>();

         list.add(5);
         list.add(17);
         list.add(19);
         list.add(22);
         list.add(25);
         list.print();
         
         list.index(4, 24);
         Console.WriteLine("After adding 24 in 4 position");
         list.print();
         list.delete(2);
         Console.WriteLine("After deleting number on 2 position");
         list.print();
         
         list.clear();
         Console.WriteLine("After clearing list"); 
         list.print();
      }
   } 
}