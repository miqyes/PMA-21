using System;
using System.IO;
namespace TaskTwo;

class Program {
    public static int[] AddVectors(int[] a, int[] b) {
        int[] c = new int[a.Length];
        for (int i = 0; i < c.Length; i++) {
            c[i] = a[i] + b[i];
        }
        return c;
    }
    public static int[] SubtractionVectors(int[] a, int[] b) {
        int[] c = new int[a.Length];
        for (int i = 0; i < c.Length; i++) {
            c[i] = a[i] - b[i];
        }
        return c;
    }
    public static int[] MultiplicationVectors(int[] a, int[] b) {
        int[] c = new int[a.Length];
        for (int i = 0; i < c.Length; i++) {
            c[i] = a[i] * b[i];
        }
        return c;
    }
    public static double[] DivisionVectors(int[] a, int[] b) {
        double[] c = new double[a.Length];
        for (int i = 0; i < c.Length; i++) {
            c[i] = (double)a[i] / b[i];
        }
        return c;
    }
    public static string[] Convertation(int[] a, int[] b, int[] c, int[] s, int[] m, double[] d) {
        return new string[] {
            string.Join(", ", a),
            string.Join(", ", b),
            string.Join(", ", c),
            string.Join(", ", s),
            string.Join(", ", m),
            string.Join(", ", d)
        };
    }

    static void Main(string[] args) {
        string file = "vectors.txt";

        if (!File.Exists(file)) {
            Console.WriteLine($"File {file} is NOT founded!");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        if (lines.Length < 2) {
            Console.WriteLine($"File {file} has to have at least 2 lines!");
            return;
        }

        string[] v1 = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] v2 = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (v1.Length != v2.Length) {
            Console.WriteLine("Vectors are NOT eqaul in leangth.");
            return;
        }

        int[] a = new int[v1.Length];
        int[] b = new int[v2.Length];

        for (int i = 0; i < a.Length; i++) {
            a[i] = int.Parse(v1[i]);
        }
        for (int j = 0; j < b.Length; j++) {
            b[j] = int.Parse(v2[j]);
            if (b[j] == 0) {
                Console.WriteLine("Second vector can not contain zero! Error: division by zero.");
                return;
            }
        }

        int[] sum = AddVectors(a, b);
        int[] sub = SubtractionVectors(a, b);
        int[] mult = MultiplicationVectors(a, b);
        double[] div = DivisionVectors(a, b);
        string[] vectors = Convertation(a, b, sum, sub, mult, div);

        File.WriteAllText("result.txt", "Resulsts:\n" +
            "(" + vectors[0] + ") + (" + vectors[1] + ") = (" + vectors[2] + ")\n" +
            "(" + vectors[0] + ") - (" + vectors[1] + ") = (" + vectors[3] + ")\n" +
            "(" + vectors[0] + ") * (" + vectors[1] + ") = (" + vectors[4] + ")\n" +
            "(" + vectors[0] + ") / (" + vectors[1] + ") = (" + vectors[5] + ")\n");

        Console.WriteLine($"Results are successfully saved to {file}.");    
    }
}
