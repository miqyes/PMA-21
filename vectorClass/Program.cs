namespace Task4;

class Program
{
    const string readFile = "vector.txt";
    const string writeFile = "result.txt";
    public static Vector[] read()
    {
        string[] line = File.ReadAllLines(readFile);
        Vector[] vectors = new Vector[line.Length];

        for (int i = 0; i < line.Length; i++)
        {
            double[] data = line[i].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();
            vectors[i] = new Vector(data);
        }

        return vectors;
    }

    public static void write(string text, Vector first, object second, Vector res, char operation)
    {
        using (StreamWriter writer = new StreamWriter(writeFile, true))
        {
            writer.WriteLine(
                text + first + operation + second + "=" + res);
        }
    }

    static void Main()
    {
        File.WriteAllText("result.txt", "");
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Vector[] vectors = read();
        File.AppendAllText("result.txt", "Всі вектори\n");
        for (int i = 0; i < vectors.Length; i++)
        {
            using (StreamWriter writer = new StreamWriter("result.txt", true))
            {
                writer.WriteLine($"{i + 1} ) {vectors[i]}");
            }
        }

        try
        {
            write("Додавання 1 і 3 векторів\n", vectors[0], vectors[2], vectors[0] + vectors[2], '+');
        }
        catch (Exception ex)
        {
            File.AppendAllText("result.txt", $"Помилка: {ex.Message}");
        }

        try
        {
            write("\nВіднімання 2 і 4 векторів\n", vectors[1], vectors[3], vectors[1] - vectors[3], '-');
        }
        catch (Exception ex)
        {
            File.AppendAllText("result.txt", $"Помилка: {ex.Message}");
        }

        Console.WriteLine("На яке число множимо вектор 5:");
        double num = double.Parse(Console.ReadLine());
        write($"Множення вектора 5 на {num}\n", vectors[4], num, vectors[4] * num, '*');
        try
        {
            Console.WriteLine("На яке число ділимо вектор 6:");
            double number = double.Parse(Console.ReadLine());
            write($"Ділення вектора 6 на {number}\n", vectors[5], number, vectors[5] / number, '/');
        }
        catch (Exception ex)
        {
            File.AppendAllText("result.txt", $"Помилка: {ex.Message}");
        }


        Console.WriteLine("Результат у файлі \"result.txt\"");
    }
}