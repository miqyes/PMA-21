using System.Globalization;

namespace Task3Matrices;

class Program
{
    private const string InputFilePath = "matrices.txt";
    private const string OutputFilePath = "result.txt";

    static void Main()
    {
        List<double[,]> matrices;

        try
        {
            matrices = ReadMatrices(InputFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Cannot read {InputFilePath}: {ex.Message}");
            return;
        }

        if (matrices.Count < 2)
        {
            Console.WriteLine("Need at least two matrices in the file");
            return;
        }

        var lines = new List<string>();

        for (int i = 0; i < matrices.Count - 1; i++)
        {
            double[,] a = matrices[i];
            double[,] b = matrices[i + 1];

            lines.Add($"===== Matrices #{i + 1} and #{i + 2} =====");
            lines.Add($"A ({MatrixMath.Size(a)}) =");
            lines.Add(MatrixMath.ToText(a));
            lines.Add($"B ({MatrixMath.Size(b)}) =");
            lines.Add(MatrixMath.ToText(b));
            lines.Add("");

            RunOperation(lines, "A + B", () => MatrixMath.Add(a, b));
            RunOperation(lines, "A - B", () => MatrixMath.Subtract(a, b));
            RunOperation(lines, "A * B", () => MatrixMath.Multiply(a, b));
            RunOperation(lines, "A / B = A * B^-1", () => MatrixMath.Divide(a, b));
        }

        File.WriteAllLines(OutputFilePath, lines);
        Console.WriteLine($"Saved in {OutputFilePath}");
    }

    private static void RunOperation(List<string> lines, string title, Func<double[,]> operation)
    {
        try
        {
            double[,] result = operation();
            lines.Add($"{title} =");
            lines.Add(MatrixMath.ToText(result));
        }
        catch (ArgumentException ex)
        {
            lines.Add($"{title}: impossible, {ex.Message}");
        }

        lines.Add("");
    }
    
    private static List<double[,]> ReadMatrices(string path)
    {
        var matrices = new List<double[,]>();
        var rows = new List<double[]>();

        foreach (string line in File.ReadAllLines(path).Append(""))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (rows.Count > 0)
                {
                    matrices.Add(ToMatrix(rows));
                    rows.Clear();
                }
                continue;
            }

            rows.Add(line
                .Split(new[] { ' ', ';', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => double.Parse(s, CultureInfo.InvariantCulture))
                .ToArray());
        }

        return matrices;
    }

    private static double[,] ToMatrix(List<double[]> rows)
    {
        int cols = rows[0].Length;
        if (rows.Any(r => r.Length != cols))
            throw new FormatException("all rows of a matrix must have the same number of elements");

        var matrix = new double[rows.Count, cols];
        for (int i = 0; i < rows.Count; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = rows[i][j];
        return matrix;
    }
}