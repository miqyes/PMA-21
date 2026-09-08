namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string file = "input.txt";
            string str = File.ReadAllText(file);
            string[] strArr = str.Split(' ', ',');
            int a = int.Parse(strArr[0]);
            int b = int.Parse(strArr[1]);
            if (a < 0 || b < 0 || (a == 0 && b == 0))
            {
                throw new ArgumentException("Invalid input(output.txt)");

            }

            List<int> f = new List<int> { a, b };
            string file2 = "steps.txt";
            string str2 = File.ReadAllText(file2);
            int n = int.Parse(str2);
            if (n < 0)
            {
                throw new ArgumentException("Invalid input(steps.txt)");
            }

            fibonacci(f, n);
            string rf = string.Join(" ", f);
            Console.WriteLine("Written to file output.txt: " + rf);
            File.WriteAllText("output.txt", rf);

        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
        catch (FormatException)
        {
            Console.WriteLine("Not correct numbers");
        }
        catch (ArgumentException i)
        {
            Console.WriteLine(i.Message);
        }
        
    }
    public static List<int> fibonacci(List<int> f,int n)
    {
        if (n <= 2)
        {
            return f;
            
        }
        else
        {
            f.Add(f[^1]+f[^2]);
            return fibonacci(f, n - 1);
        }
    }
}
