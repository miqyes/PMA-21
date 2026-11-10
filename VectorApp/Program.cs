using System;
using System.IO;

public class Vector
{
    public double[] Elements;

    public Vector(double[] elements)
    {
        Elements = elements;
    }

    public static Vector Add(Vector v1, Vector v2)
    {
        double[] res = new double[v1.Elements.Length];
        for (int i = 0; i < res.Length; i++)
            res[i] = v1.Elements[i] + v2.Elements[i];
        return new Vector(res);
    }

    public static Vector Subtract(Vector v1, Vector v2)
    {
        double[] res = new double[v1.Elements.Length];
        for (int i = 0; i < res.Length; i++)
            res[i] = v1.Elements[i] - v2.Elements[i];
        return new Vector(res);
    }

    public static Vector Multiply(Vector v1, Vector v2)
    {
        double[] res = new double[v1.Elements.Length];
        for (int i = 0; i < res.Length; i++)
            res[i] = v1.Elements[i] * v2.Elements[i];
        return new Vector(res);
    }

    public static Vector Divide(Vector v1, Vector v2)
    {
        double[] res = new double[v1.Elements.Length];
        for (int i = 0; i < res.Length; i++)
        {
            if (v2.Elements[i] == 0)
                throw new DivideByZeroException("Ділення на нуль!");
            res[i] = v1.Elements[i] / v2.Elements[i];
        }
        return new Vector(res);
    }

    public static Vector Parse(string line)
    {
        string cleaned = line.Replace("(", "").Replace(")", "").Trim();
        string[] parts = cleaned.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        double[] nums = new double[parts.Length];
        for (int i = 0; i < parts.Length; i++)
            nums[i] = double.Parse(parts[i]);

        return new Vector(nums);
    }

    public override string ToString()
    {
        return "(" + string.Join(", ", Elements) + ")";
    }
}

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("vectors.txt");

        Vector v1 = Vector.Parse(lines[0]);
        Vector v2 = Vector.Parse(lines[1]);

        Vector sum = Vector.Add(v1, v2);
        Vector diff = Vector.Subtract(v1, v2);
        Vector prod = Vector.Multiply(v1, v2);
        Vector div = Vector.Divide(v1, v2);

        string[] results = new string[]
        {
            $"{v1} + {v2} = {sum}",
            $"{v1} - {v2} = {diff}",
            $"{v1} * {v2} = {prod}",
            $"{v1} / {v2} = {div}"
        };

        File.WriteAllLines("results.txt", results);

        Console.WriteLine("Готово! Результати записано в results.txt");
    }
}