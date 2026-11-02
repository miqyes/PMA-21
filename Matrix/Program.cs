using System.Text;

namespace Matrix;

class Program
{
    private const string InputFile = "matrix.txt";
    private const string OutputFile = "../../../result.txt";

    public static int[][,] LoadMatrices()
    {
        if (!File.Exists(InputFile))
            throw new FileNotFoundException($"Файл {InputFile} не знайдено!");

        string rawContent = File.ReadAllText(InputFile);
        int[] numbers = rawContent
            .Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int matrixCount = numbers.Length / 4;
        if (numbers.Length == 0)
        {
            Console.WriteLine("Помилка: файл матриць порожній.");
            return Array.Empty<int[,]>();
        }
        if (numbers.Length % 4 != 0)
        {
            Console.WriteLine("Попередження: кількість чисел у файлі не кратна 4.");
        }
        int[][,] matrices = new int[matrixCount][,];
        int ptr = 0;

        for (int idx = 0; idx < matrixCount; idx++)
        {
            matrices[idx] = new int[2, 2];
            for (int r = 0; r < 2; r++)
            {
                for (int c = 0; c < 2; c++)
                    matrices[idx][r, c] = numbers[ptr++];
            }
        }

        return matrices;
    }

    public static void SaveOperation<T>(string title, int[,] first, int[,] second, char op, T[,] result)
    {
        using StreamWriter writer = new StreamWriter(OutputFile, append: true, Encoding.UTF8);
        writer.WriteLine(title);

        for (int r = 0; r < 2; r++)
        {
            string opSymbol = (r == 0) ? op.ToString() : " ";
            string eqSymbol = (r == 0) ? "=" : " ";

            string res0 = result[r, 0] is double d0 ? $"{d0:F2}" : result[r, 0]?.ToString() ?? "0";
            string res1 = result[r, 1] is double d1 ? $"{d1:F2}" : result[r, 1]?.ToString() ?? "0";

            writer.WriteLine($"{first[r, 0],3} {first[r, 1],3}   {opSymbol}   {second[r, 0],3} {second[r, 1],3}   {eqSymbol}   {res0,6} {res1,6}");
        }
        writer.WriteLine();
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        File.WriteAllText(OutputFile, string.Empty);

        int[][,] matrices = LoadMatrices();
        
        if (matrices.Length < 8)
        {
            Console.WriteLine($"Помилка: у файлі знайдено лише {matrices.Length} матриць. Для виконання всіх операцій потрібно щонайменше 8 матриць (32 числа).");
            return;
        }

        using (StreamWriter writer = new StreamWriter(OutputFile, append: true, Encoding.UTF8))
        {
            writer.WriteLine("Вхідні матриці:");
            for (int i = 0; i < matrices.Length; i++)
            {
                writer.WriteLine($"Матриця №{i + 1}:");
                for (int r = 0; r < 2; r++)
                {
                    writer.WriteLine($"{matrices[i][r, 0],3} {matrices[i][r, 1],3}");
                }
                writer.WriteLine();
            }
            writer.WriteLine("Результати операцій:");
        }
        
        int[,] sum = MatrixOperations.Add(matrices[0], matrices[2]);
        SaveOperation("1. Додавання 1-ї та 3-ї матриць:", matrices[0], matrices[2], '+', sum);

        int[,] diff = MatrixOperations.Subtract(matrices[1], matrices[3]);
        SaveOperation("2. Віднімання 4-ї матриці від 2-ї:", matrices[1], matrices[3], '-', diff);

        int[,] prod = MatrixOperations.Multiply(matrices[4], matrices[5]);
        SaveOperation("3. Множення 5-ї та 6-ї матриць:", matrices[4], matrices[5], '*', prod);

        try
        {
            double[,] quot = MatrixOperations.Divide(matrices[6], matrices[7]);
            SaveOperation("4. Ділення 7-ї матриці на 8-му:", matrices[6], matrices[7], '/', quot);
        }
        catch (InvalidOperationException)
        {
            File.AppendAllText(OutputFile, "4. Ділення 7-ї на 8-му неможливе: визначник 8-ї матриці дорівнює 0.\n");
        }

        Console.WriteLine($"Усі операції успішно виконано! Результат записано у \"{OutputFile}\".");
    }
}