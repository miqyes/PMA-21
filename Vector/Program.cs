using System.Text;

namespace Vector;

class Program
{
    private const string InputFilePath = "vector.txt";
    private const string OutputFilePath = "../../../result.txt";

    public static int[][] ReadVectors(string path, int dimensions = 3)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"Вхідний файл \"{path}\" не знайдено.");

        string rawContent = File.ReadAllText(path);
        
        int[] allNumbers = rawContent
            .Split(new[] { ';', ',', ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int totalVectors = allNumbers.Length / dimensions;
        int[][] vectors = new int[totalVectors][];

        for (int i = 0; i < totalVectors; i++)
        {
            vectors[i] = new int[dimensions];
            Array.Copy(allNumbers, i * dimensions, vectors[i], 0, dimensions);
        }

        return vectors;
    }

    public static void LogOperation<T>(string title, int[] v1, char op, int[] v2, T[] result)
    {
        string entry = $"{title}\n({Format(v1)}) {op} ({Format(v2)}) = ({Format(result)})\n\n";
        File.AppendAllText(OutputFilePath, entry, Encoding.UTF8);
    }

    private static string Format<T>(IEnumerable<T> items) => string.Join(", ", items);

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        try
        {
            File.WriteAllText(OutputFilePath, string.Empty);

            int[][] vectors = ReadVectors(InputFilePath);

            if (vectors.Length < 8)
            {
                Console.WriteLine($"Попередження: у файлі знайдено лише {vectors.Length} векторів, для демонстрації всіх дій потрібно мінімум 8.");
                return;
            }

            var headerLog = new StringBuilder("Початкові вектори:\n");
            for (int i = 0; i < vectors.Length; i++)
            {
                string line = $"{i + 1}) ({Format(vectors[i])})";
                Console.WriteLine(line);
                headerLog.AppendLine(line);
            }
            headerLog.AppendLine();
            File.AppendAllText(OutputFilePath, headerLog.ToString(), Encoding.UTF8);
            
            int[] sum = VectorOperations.Add(vectors[0], vectors[1]);
            LogOperation("1. Додавання 1-го і 2-го векторів:", vectors[0], '+', vectors[1], sum);
            
            int[] diff = VectorOperations.Subtract(vectors[2], vectors[3]);
            LogOperation("2. Віднімання 4-го вектора від 3-го:", vectors[2], '-', vectors[3], diff);
            
            int[] product = VectorOperations.Multiply(vectors[4], vectors[5]);
            LogOperation("3. Покоординатне множення 5-го і 6-го векторів:", vectors[4], '*', vectors[5], product);
            
            try
            {
                double[] quotient = VectorOperations.Divide(vectors[6], vectors[7]);
                string[] formattedQuotient = quotient.Select(x => x.ToString("F2")).ToArray();
                LogOperation("4. Покоординатне ділення 7-го на 8-й вектор:", vectors[6], '/', vectors[7], formattedQuotient);
            }  
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                File.AppendAllText(OutputFilePath, $"4. Покоординатне ділення:\n{ex.Message}\n\n", Encoding.UTF8);
            }
            Console.WriteLine($"\nОбчислення завершено. Результати збережено у: \"{OutputFilePath}\"");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Виникла помилка: {ex.Message}");
        }
    }
}