using VectorClass;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("vectors.txt");

        string[] first = lines[0].Split(',');
        string[] second = lines[1].Split(',');

        if (first.Length != second.Length)
        {
            Console.WriteLine("Вектори повинні мати однакову кількість координат");
            return;
        }

        double[] a = new double[first.Length];
        double[] b = new double[second.Length];

        for (int i = 0; i < first.Length; i++)
        {
            a[i] = double.Parse(first[i]);
            b[i] = double.Parse(second[i]);
        }

        Vector vectorA = new Vector(a);
        Vector vectorB = new Vector(b);

        StreamWriter file = new StreamWriter("result.txt");

        file.WriteLine(GetResult(vectorA, vectorB, '+'));
        file.WriteLine(GetResult(vectorA, vectorB, '-'));
        file.WriteLine(GetResult(vectorA, vectorB, '*'));
        file.WriteLine(GetResult(vectorA, vectorB, '/'));

        file.Close();

        Console.WriteLine("Готово");
    }

    static Vector Calculate(Vector a, Vector b, char operation)
    {
        switch (operation)
        {
            case '+':
                return a.Add(b);
            case '-':
                return a.Sub(b);
            case '*':
                return a.Mult(b);
            case '/':
                return a.Div(b);
            default:
                throw new Exception($"операція {operation} не розпізнано");
        }
    }

    
    static string GetResult(Vector a, Vector b, char operation)
    {
        Vector result = Calculate(a, b, operation);
        
        return $"{a.ToString()} {operation} {b.ToString()} = {result.ToString()}";
    }
}