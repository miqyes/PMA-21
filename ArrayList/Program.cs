using Task6;

class Program
{
static void Main()
{

    ArrayList<int> example1 = new ArrayList<int>(4);
    ArrayList<double> example2 = new ArrayList<double>(1.3, 4.7, 2.9, 5.8);

    Console.WriteLine(example1);
    Console.WriteLine(example2);

    example1.Add(3);
    example1.Add(8);
    example1.Add(7);
    example1.Add(-1);
    example1.Add(3);
    example1.Add(-57);
    example2.Add(3.1);
    example2.Add(2);
    Console.WriteLine(example1);
    Console.WriteLine(example2);

    try
    {
        example1.AddIndx(3, 78);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    try
    {
        example1.AddIndx(-78, 0);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }      
    try
    {
        example2.AddIndx(-7.8, 0);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }      
    try
    {
        example2.AddIndx(71, 8);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    Console.WriteLine(example1);
    Console.WriteLine(example2);

    example1.Delete(3);
    example1.Delete(33);
    example2.Delete(3.1);
    example2.Delete(3.3);

    Console.WriteLine(example1);
    Console.WriteLine(example2);
    try
    {
        example1.DeleteIndx(3);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    try
        {
            example1.DeleteIndx(33);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }       
    try
        {
            
            example2.DeleteIndx(2);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    
  try{
      example2.DeleteIndx(39);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

    Console.WriteLine(example1);
    Console.WriteLine(example2);

    example1.Clear();
    example2.Clear();

    Console.WriteLine(example1);
    Console.WriteLine(example2);

}
}
