using System.Globalization;

namespace Task3Matrices;

public static class MatrixMath
{
    private const double Epsilon = 1e-10;

    public static double[,] Add(double[,] a, double[,] b)
    {
        EnsureSameSize(a, b);
        return Map(a, b, (x, y) => x + y);
    }

    public static double[,] Subtract(double[,] a, double[,] b)
    {
        EnsureSameSize(a, b);
        return Map(a, b, (x, y) => x - y);
    }

    public static double[,] Multiply(double[,] a, double[,] b)
    {
        int rows = a.GetLength(0);
        int inner = a.GetLength(1);
        int cols = b.GetLength(1);

        if (inner != b.GetLength(0))
            throw new ArgumentException($"cannot multiply {Size(a)} by {Size(b)} (columns of A must equal rows of B)");

        var result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                double sum = 0;
                for (int k = 0; k < inner; k++)
                    sum += a[i, k] * b[k, j];
                result[i, j] = sum;
            }
        }
        return result;
    }

    // A / B = A * B^-1
    public static double[,] Divide(double[,] a, double[,] b) => Multiply(a, Inverse(b));

    // Gauss-Jordan elimination: [M | I] -> [I | M^-1]
    public static double[,] Inverse(double[,] m)
    {
        int n = m.GetLength(0);
        if (n != m.GetLength(1))
            throw new ArgumentException($"matrix {Size(m)} is not square, so it has no inverse");

        var work = new double[n, 2 * n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                work[i, j] = m[i, j];
            work[i, n + i] = 1;
        }

        for (int col = 0; col < n; col++)
        {
            int pivot = col;
            for (int r = col + 1; r < n; r++)
                if (Math.Abs(work[r, col]) > Math.Abs(work[pivot, col]))
                    pivot = r;

            if (Math.Abs(work[pivot, col]) < Epsilon)
                throw new ArgumentException("matrix is singular (determinant = 0), so it has no inverse");

            if (pivot != col)
                for (int j = 0; j < 2 * n; j++)
                    (work[col, j], work[pivot, j]) = (work[pivot, j], work[col, j]);

            double divisor = work[col, col];
            for (int j = 0; j < 2 * n; j++)
                work[col, j] /= divisor;

            for (int r = 0; r < n; r++)
            {
                if (r == col) continue;
                double factor = work[r, col];
                for (int j = 0; j < 2 * n; j++)
                    work[r, j] -= factor * work[col, j];
            }
        }

        var inverse = new double[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                inverse[i, j] = work[i, n + j];
        return inverse;
    }

    public static string Size(double[,] m) => $"{m.GetLength(0)}x{m.GetLength(1)}";

    public static string ToText(double[,] m)
    {
        int rows = m.GetLength(0);
        int cols = m.GetLength(1);

        var cells = new string[rows, cols];
        int width = 0;
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                cells[i, j] = Format(m[i, j]);
                width = Math.Max(width, cells[i, j].Length);
            }

        var lines = new List<string>();
        for (int i = 0; i < rows; i++)
        {
            var row = Enumerable.Range(0, cols).Select(j => cells[i, j].PadLeft(width));
            lines.Add("  " + string.Join("  ", row));
        }
        return string.Join(Environment.NewLine, lines);
    }

    private static string Format(double x)
    {
        double rounded = Math.Round(x, 2);
        if (rounded == 0) rounded = 0; // prevents "-0"
        return rounded.ToString(CultureInfo.InvariantCulture);
    }

    private static void EnsureSameSize(double[,] a, double[,] b)
    {
        if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            throw new ArgumentException($"sizes differ ({Size(a)} vs {Size(b)})");
    }

    private static double[,] Map(double[,] a, double[,] b, Func<double, double, double> operation)
    {
        var result = new double[a.GetLength(0), a.GetLength(1)];
        for (int i = 0; i < a.GetLength(0); i++)
            for (int j = 0; j < a.GetLength(1); j++)
                result[i, j] = operation(a[i, j], b[i, j]);
        return result;
    }
}