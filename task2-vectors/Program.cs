using System.Globalization;

namespace Task2Vectors;

class Program
{
    private const string InputFilePath = "vectors.txt";
    private const string OutputFilePath = "result.txt";

    static void Main()
    {
        List<double[]> vectors;

        try
        {
            vectors = ReadVectors(InputFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Cannot read {InputFilePath}: {ex.Message}");
            return;
        }

        if (vectors.Count < 2)
        {
            Console.WriteLine("Need at least two vectors in the file");
            return;
        }

        var lines = new List<string>();

        for (int i = 0; i < vectors.Count - 1; i++)
        {
            double[] a = vectors[i];
            double[] b = vectors[i + 1];

            lines.Add($"Vectors #{i + 1} and #{i + 2}: a = {VectorMath.ToText(a)}, b = {VectorMath.ToText(b)}");

            if (a.Length != b.Length)
            {
                lines.Add($"  Cannot compute: sizes differ ({a.Length} vs {b.Length})");
            }
            else
            {
                lines.Add($"  a + b = {VectorMath.ToText(VectorMath.Sum(a, b))}");
                lines.Add($"  a - b = {VectorMath.ToText(VectorMath.Difference(a, b))}");
                lines.Add($"  a * b = {VectorMath.ToText(VectorMath.Product(a, b))}");
                lines.Add($"  a / b = {VectorMath.Quotient(a, b)}");
            }

            lines.Add("");
        }

        File.WriteAllLines(OutputFilePath, lines);
        Console.WriteLine($"Saved in {OutputFilePath}");
    }

    private static List<double[]> ReadVectors(string path)
    {
        return File.ReadAllLines(path)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line
                .Split(new[] { ' ', ';', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => double.Parse(s, CultureInfo.InvariantCulture))
                .ToArray())
            .ToList();
    }
}