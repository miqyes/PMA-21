namespace Task3;

class Program
{
     private static string readFile = "matrix.txt";
     private static string writeFile = "result.txt";
     private static string enter = " ";
    
    public static int[][,] read()
    {
        string line = File.ReadAllText(readFile);
        int[] parts = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int n = parts.Length / 4;
        int[][,] res = new int[n][,];
        int index = 0;
        for (int i = 0; i < n; i++)
        {
            res[i] = new int[2, 2];
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                    res[i][j, k] = parts[index++];
            }
        }

        return res;
    }

    public static void write<T>(string text, int[,] matrixFirst, int[,] matrixSecond, char operation, T[,] res)
    {
        using (StreamWriter writer = new StreamWriter(writeFile, true))
        {
            writer.WriteLine(text);
            char operation1 = '=';
            for (int i = 0; i < 2; i++)
            {
                string op1 = i == 0 ? operation.ToString() : enter;
                string op2 = i == 0 ? operation1.ToString() : enter;
                writer.WriteLine(
                    $"{matrixFirst[i, 0]} {matrixFirst[i, 1]} {op1} {matrixSecond[i, 0]} {matrixSecond[i, 1]} {op2} {res[i, 0]} {res[i, 1]}");
            }
        }
    }

    static void Main()
    {
        File.WriteAllText(writeFile, enter);
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        int[][,] matrix = read();
        for (int i = 0; i < matrix.Length; i++)
        {
            using (StreamWriter writer = new StreamWriter(writeFile, true))
            {
                writer.WriteLine($"{i + 1} матриця");
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                        writer.Write(matrix[i][j, k] + " ");
                    writer.WriteLine();
                }
            }
        }

        int[,] adding = Operation.add(matrix[0], matrix[2]);
        write("Додавання 1 і 3 матриць", matrix[0], matrix[2], '+', adding);

        int[,] differencing = Operation.difference(matrix[1], matrix[3]);
        write("Віднімання 2 і 4 матриці", matrix[1], matrix[3], '-', differencing);

        int[,] multiplying = Operation.multiply(matrix[4], matrix[5]);
        write("Множення матриці 5 на матрицю 6", matrix[4], matrix[5], '*', multiplying);
        try
        {
            double[,] dividing = Operation.divide(matrix[6], matrix[7]);
            write("Ділення матриці 7 на матрицю 8", matrix[6], matrix[7], '/', dividing);
        }
        catch (Exception)
        {
            File.AppendAllText(writeFile, "Ми не можемо поділити,бо визначник=0");
        }

        Console.WriteLine($"Результат у файлі \"{writeFile}\"");
    }
}