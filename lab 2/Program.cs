using System;
using System.IO;

class Program
{
    static double[] Add(double[] first, double[] second)
    {
        double[] result = new double[first.Length];
        for (int i = 0; i < first.Length; i++)
        {
            result[i] = first[i] + second[i];
        }
        return result;
    }

    static double[] Subtract(double[] first, double[] second)
    {
        double[] result = new double[first.Length];
        for (int i = 0; i < first.Length; i++)
        {
            result[i] = first[i] - second[i];
        }
        return result;
    }

    static double[] Multiply(double[] first, double[] second)
    {
        double[] result = new double[first.Length];
        for (int i = 0; i < first.Length; i++)
        {
            result[i] = first[i] * second[i];
        }
        return result;
    }

    static double[] Divide(double[] first, double[] second)
    {
        double[] result = new double[first.Length];
        for (int i = 0; i < first.Length; i++)
        {
            result[i] = first[i] / second[i];
        }
        return result;
    }

    static double[] ReadVector(string line)
    {
        string[] numbers = line.Split(' ');
        double[] vector = new double[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            vector[i] = double.Parse(numbers[i]);
        }
        return vector;
    }

    static string ShowVector(double[] vector)
    {
        return "(" + string.Join(", ", vector) + ")";
    }

    static void Main() {

        if (!File.Exists("input.txt")) {
            Console.WriteLine("Input file not found.");
            return;
        }

        string[] lines = File.ReadAllLines("input.txt");

        if (lines.Length != 2) {
            Console.WriteLine("Input file must contain exactly two lines.");
            return;
        }

        double[] first = ReadVector(lines[0]);
        double[] second = ReadVector(lines[1]);

        if (first.Length != second.Length) {
            Console.WriteLine("Vectors must be of the same length.");
            return;
        }

        for (int i = 0; i < second.Length; i++) {
            if (second[i] == 0) {
                Console.WriteLine("Division by 0 is not allowed.");
                return;
            }
        }
        double[] sum = Add(first, second);
        double[] diff = Subtract(first, second);
        double[] prod = Multiply(first, second);
        double[] quot = Divide(first, second);

        string result = "Results:\n" +
            ShowVector(first) + " + " + ShowVector(second) + " = " + ShowVector(sum) + "\n" + 
            ShowVector(first) + " - " + ShowVector(second) + " = " + ShowVector(diff) + "\n" +
            ShowVector(first) + " * " + ShowVector(second) + " = " + ShowVector(prod) + "\n" +
            ShowVector(first) + " / " + ShowVector(second) + " = " + ShowVector(quot);

        File.WriteAllText("results.txt", result);
        Console.WriteLine(result);
    }
}
