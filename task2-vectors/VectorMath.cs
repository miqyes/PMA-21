using System.Globalization;

namespace Task2Vectors;

public static class VectorMath
{
    public static double[] Sum(double[] a, double[] b) => Combine(a, b, (x, y) => x + y);

    public static double[] Difference(double[] a, double[] b) => Combine(a, b, (x, y) => x - y);

    public static double[] Product(double[] a, double[] b) => Combine(a, b, (x, y) => x * y);

    public static string Quotient(double[] a, double[] b)
    {
        EnsureSameSize(a, b);

        var parts = a.Zip(b, (x, y) => y == 0 ? "undefined" : Format(Math.Round(x / y, 2)));
        return "(" + string.Join("; ", parts) + ")";
    }

    public static string ToText(double[] v) => "(" + string.Join("; ", v.Select(Format)) + ")";

    private static double[] Combine(double[] a, double[] b, Func<double, double, double> operation)
    {
        EnsureSameSize(a, b);
        return a.Zip(b, operation).ToArray();
    }

    private static void EnsureSameSize(double[] a, double[] b)
    {
        if (a.Length != b.Length)
            throw new ArgumentException($"Vectors have different sizes: {a.Length} and {b.Length}");
    }

    private static string Format(double x) => x.ToString(CultureInfo.InvariantCulture);
}