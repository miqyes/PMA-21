using Task6;

class Program
{
    static void Main()
    {
        ArrayList<int> firstExample = new ArrayList<int>(9);
        ArrayList<double> secondExample = new ArrayList<double>(1.3, 4.7, 2.9, 5.8);

        Console.WriteLine(firstExample);
        Console.WriteLine(secondExample);

        firstExample.Add(3);
        firstExample.Add(8);
        firstExample.Add(7);

        secondExample.Add(3.1);
        secondExample.Add(2);
        
        Console.WriteLine(firstExample);
        Console.WriteLine(secondExample);

        try
        {
            firstExample.AddIndx(3, 78);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            secondExample.AddIndx(71, 8);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine(firstExample);
        Console.WriteLine(secondExample);

        firstExample.Delete(3);
        firstExample.Delete(33);
        secondExample.Delete(3.1);
        secondExample.Delete(3.3);

        Console.WriteLine(firstExample);
        Console.WriteLine(secondExample);

        try
        {
            firstExample.DeleteIndx(33);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            secondExample.DeleteIndx(39);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine(firstExample);
        Console.WriteLine(secondExample);

        firstExample.Clear();
        secondExample.Clear();

        Console.WriteLine(firstExample);
        Console.WriteLine(secondExample);
    }
}