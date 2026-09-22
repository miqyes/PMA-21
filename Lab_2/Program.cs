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

        StreamWriter file = new StreamWriter("result.txt");

        file.WriteLine(GetResult(a, b, '+'));
        file.WriteLine(GetResult(a, b, '-'));
        file.WriteLine(GetResult(a, b, '*'));
        file.WriteLine(GetResult(a, b, '/'));

        file.Close();

        Console.WriteLine("Готово");
    }

    static double[] Calculate(double[] a, double[] b, char operation)
    {
        if (a.Length != b.Length)
        {
            throw new Exception("вектори мають бути одтнакового розміру");
        }
        
        switch (operation)
        {
            case '+':
                return Add(a, b);
            case '-':
                return Sub(a, b);
            case '*':
                return Mult(a, b);
            case '/':
                return Div(a, b);
            default:
                throw new Exception($"операція {operation} не розпізнано");
        }
    }

    static double[] Add(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] + b[i];
        }
        return result;
    }

    static double[] Sub(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] - b[i];
        }
        return result;
    }
    
    static double[] Mult(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] * b[i];
        }
        return result;
    }
    
    static double[] Div(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            if (b[i] == 0)
            {
                throw new Exception("вектор-дільник не може містити нульових елементів при діленні");
            }
            result[i] = a[i] / b[i];
        }
        return result;
    }
    
    static string ToString(double[] a)
    {
        return "(" + string.Join(", ", a) + ")";
    }

    static string GetResult(double[] a, double[] b, char operation)
    {
        double[] result = Calculate(a, b, operation);
        
        return $"{ToString(a)} {operation} {ToString(b)} = {ToString(result)}";
    }
}