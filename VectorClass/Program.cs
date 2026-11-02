using System.Globalization;
using System.Text;

namespace VectorClass;

internal class Program
{
    private const string InputFilePath = "vector.txt";
    private const string OutputFilePath = "../../../result.txt";

    private static List<Vector> LoadVectors(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Вхідний файл '{filePath}' не знайдено.");

        return File.ReadAllLines(filePath)
            .Select(line => line.Trim().Trim('(', ')'))
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries))
            .Select(parts => parts.Select(p => double.Parse(p, NumberStyles.Any, CultureInfo.InvariantCulture)).ToArray())
            .Select(components => new Vector(components))
            .ToList();
    }

    private static void ExecuteVectorOperation(StreamWriter writer, string operationName, Vector a, Vector b, char symbol, Func<Vector, Vector, Vector> op)
    {
        writer.WriteLine($"{operationName}");
        try
        {
            Vector res = op(a, b);
            writer.WriteLine($"{a} {symbol} {b} = {res}");
        }
        catch (Exception ex)
        {
            writer.WriteLine($"Помилка: {ex.Message}");
        }
        writer.WriteLine();
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        List<Vector> vectors;
        try
        {
            vectors = LoadVectors(InputFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Не вдалося зчитати файл: {ex.Message}");
            return;
        }

        if (vectors.Count < 2)
        {
            Console.WriteLine("Для демонстрації операцій потрібно щонайменше 2 вектори у файлі.");
            return;
        }

        using var writer = new StreamWriter(OutputFilePath, false, Encoding.UTF8);

        writer.WriteLine("Початкові вектори");
        for (int i = 0; i < vectors.Count; i++)
        {
            writer.WriteLine($"Вектор [{i + 1}]: {vectors[i]}");
        }
        writer.WriteLine();

        ExecuteVectorOperation(writer, "Додавання векторів (1 і 2)", vectors[0], vectors[1], '+', (v1, v2) => v1 + v2);
        ExecuteVectorOperation(writer, "Віднімання векторів (1 і 2)", vectors[0], vectors[1], '-', (v1, v2) => v1 - v2);
        ExecuteVectorOperation(writer, "Покоординатне множення векторів (1 і 2)", vectors[0], vectors[1], '*', (v1, v2) => v1 * v2);
        ExecuteVectorOperation(writer, "Покоординатне ділення векторів (1 і 2)", vectors[0], vectors[1], '/', (v1, v2) => v1 / v2);

        Console.Write("Введіть число для множення першого вектора: ");
        if (double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double mulScalar))
        {
            writer.WriteLine("Множення вектора на скаляр");
            writer.WriteLine($"{vectors[0]} * {mulScalar.ToString(CultureInfo.InvariantCulture)} = {vectors[0] * mulScalar}\n");
        }

        Console.Write("Введіть число для ділення першого вектора: ");
        if (double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double divScalar))
        {
            writer.WriteLine("Ділення вектора на скаляр");
            try
            {
                writer.WriteLine($"{vectors[0]} / {divScalar.ToString(CultureInfo.InvariantCulture)} = {vectors[0] / divScalar}\n");
            }
            catch (Exception ex)
            {
                writer.WriteLine($"Помилка: {ex.Message}\n");
            }
        }

        Console.WriteLine($"Обчислення завершено. Результат збережено у '{OutputFilePath}'.");
    }
}