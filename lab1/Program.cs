namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        string file = "input.txt";
        string str = File.ReadAllText(file);
        string[] strArr = str.Split(' ', ',');
        int a = int.Parse(strArr[0]);
        int b = int.Parse(strArr[1]);
        List<int> fib = new List<int> { a, b };
        List<int> fib1= new List<int> { a, b };
        string file2 = "steps.txt"; 
        string str2 = File.ReadAllText(file2);
        int n = int.Parse(str2);
        string file3 = "lim.txt"; 
        string str3 = File.ReadAllText(file3);
        int lim=int.Parse(str3);
        
        Fibonachii.RecursiveFib(fib, n);
        Fibonachii.LimitsFib(fib1, lim);
        string rf = string.Join(" ", fib);
        string rf1 = string.Join(" ", fib1);
        File.WriteAllText("output.txt", rf+"\n"+rf1 );
        Console.WriteLine("Written to file output.txt:\n" + rf+"\n"+rf1);
        
    }

}
