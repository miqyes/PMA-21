namespace Task2;
class Program
{
    public static int[][] read()
    {
        string line = File.ReadAllText("vector.txt");
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

    public static int[] add(int[] vec1, int[] vec2)
    {
        int[] res = new int[3];
        for (int i = 0; i < 3; i++)
            res[i] = vec1[i] + vec2[i];
        return res;
    }

    public static int[] difference(int[] vec1, int[] vec2)
    {
        int[] res = new int[3];
        for (int i = 0; i < 3; i++)
            res[i] = vec1[i] - vec2[i];
        return res;
    }

    public static int[] multiply(int[] vec1, int number)
    {
        int[] res = new int[3];
        for (int i = 0; i < 3; i++)
            res[i] = vec1[i] * number;
        return res;
    }

    public static double[] divide(int[] vec1, double number)
    {
        double[] res = new double[3];
        for (int i = 0; i < 3; i++)
            res[i] = vec1[i] / number;
        return res;
    }

    public static void write<T>(string text, int[] vector1, object vector2, T[] res, char operation)
    {
        if (vector2 is T[] vector)
            vector2 = "(" + string.Join(";", vector) + ")";
        else
            vector2 = vector2.ToString();
        
        using (StreamWriter writer = new StreamWriter("result.txt", true))
        {
            writer.WriteLine(
                text +"("+ string.Join(";", vector1) +")"+ operation  +  vector2  + "=(" + string.Join(";", res) +")");
        }
    }

    static void Main()
    {
        File.WriteAllText("result.txt", "");

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        int[][] vector = read();
        File.AppendAllText("result.txt","ВСІ ВЕКТОРИ \n");
        for (int i = 0; i < vector.Length; i++)
        {
            Console.WriteLine($"{i + 1} ) ({string.Join(";", vector[i])})");
            using (StreamWriter writer = new StreamWriter("result.txt", true))
            {
                writer.WriteLine($"{i + 1} ) ({string.Join(";", vector[i])})");
            }
        }

        int[] adding = add(vector[0], vector[2]);
        write("Додавання 1 і 3 векторів\n", vector[0], vector[2], adding, '+');
        
        int[] differencing = difference(vector[1], vector[3]);
        write("Віднімання 2 і 4 векторів\n", vector[1], vector[3], differencing, '-');
        
        Console.WriteLine("На яке число множимо вектор 5:");
        int num = int.Parse(Console.ReadLine());
        int[] multiplying = multiply(vector[4], num);
        write($"Множення вектора 5 на {num}\n",  vector[4],num, multiplying, '*');

        Console.WriteLine("На яке число ділимо вектор 6:");
        int number = int.Parse(Console.ReadLine());
        double[] dividing = divide(vector[5], number);
        write($"Ділення вектора 6 на {number}\n", vector[5],number, dividing, ':');
        
        Console.WriteLine("Результат у файлі \"result.txt\"");
    }
}
