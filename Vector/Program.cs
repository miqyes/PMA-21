namespace Task2;
class Program
{
    private static string readFile = "vector.txt";
    private static string writeFile = "result.txt";

    public static int[][] read()
    {
        string line = File.ReadAllText(readFile);
        int[] parts = line.Split(new[]{',',' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int n = parts.Length / 3;
        int[][] res = new int[n][];
        int index = 0;
        for (int i = 0; i < n; i++)
        {
            res[i] = new int[3];
            for (int j = 0; j < 3; j++)
                res[i][j] = parts[index++];
        }
        return res;
    }
    public static void write<T>(string text, int[] vectorFirst, object vectorSecond, T[] res, char operation)
    {
        if (vectorSecond is T[] vector)
            vectorSecond = "(" + string.Join(";", vector) + ")";
        else
            vectorSecond = vectorSecond.ToString();
        
        using (StreamWriter writer = new StreamWriter(writeFile, true))
        {
            writer.WriteLine(
                text +"("+ string.Join(";", vectorFirst) +")"+ operation  +  vectorSecond  + "=(" + string.Join(";", res) +")");
        }
    }

    static void Main()
    {
        File.WriteAllText(writeFile, "");

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        int[][] vector = read();
        File.AppendAllText(writeFile,"ВСІ ВЕКТОРИ \n");
        for (int i = 0; i < vector.Length; i++)
        {
            Console.WriteLine($"{i + 1} ) ({string.Join(";", vector[i])})");
            using (StreamWriter writer = new StreamWriter(writeFile, true))
            {
                writer.WriteLine($"{i + 1} ) ({string.Join(";", vector[i])})");
            }
        }

        int[] adding = Operations.add(vector[0], vector[2]);
        write("Додавання 1 і 3 векторів\n", vector[0], vector[2], adding, '+');
        
        int[] differencing = Operations.difference(vector[1], vector[3]);
        write("Віднімання 2 і 4 векторів\n", vector[1], vector[3], differencing, '-');
        
        Console.WriteLine("На яке число множимо вектор 5:");
        int num = int.Parse(Console.ReadLine());
        int[] multiplying = Operations.multiply(vector[4], num);
        write($"Множення вектора 5 на {num}\n",  vector[4],num, multiplying, '*');

        Console.WriteLine("На яке число ділимо вектор 6:");
        int number = int.Parse(Console.ReadLine());
        try
        {
            double[] dividing = Operations.divide(vector[5], number);
            write($"Ділення вектора 6 на {number}\n", vector[5], number, dividing, ':');
        }
        catch (Exception ex)
        {
            File.AppendAllText(writeFile, ex.Message);
        }
        

        Console.WriteLine($"Результат у файлі \"{writeFile}\"");
    }
}
