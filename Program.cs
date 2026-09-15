using System;
using System.IO;
using System.Linq;

class Program
{
    static float[][] getvectors(string filepath)
    {
        // Зчитуємо рядки з файлу та ділимо по комі з пробілом
        float[][] data = File.ReadAllLines(filepath)
            .Select(line => line.Split(", ").Select(num => float.Parse(num)).ToArray())
            .ToArray();
        return data;
    }

    static string parsevector(float[] v)
    {
        return "(" + string.Join(", ", v) + ")";
    }

    static float[] plus(float[] v1, float[] v2)
    {
        float[] res = new float[v1.Length];
        if (v1.Length != v2.Length) return res;
        
        for (int k = 0; k < v1.Length; k++) res[k] = v1[k] + v2[k];
        return res;
    }

    static float[] minus(float[] v1, float[] v2)
    {
        float[] res = new float[v1.Length];
        if (v1.Length != v2.Length) return res;

        for (int k = 0; k < v1.Length; k++) res[k] = v1[k] - v2[k];
        return res;
    }

    static float[] multi(float[] v1, float[] v2)
    {
        float[] res = new float[v1.Length];
        if (v1.Length != v2.Length) return res;

        for (int k = 0; k < v1.Length; k++) res[k] = v1[k] * v2[k];
        return res;
    }

    static float[] div(float[] v1, float[] v2)
    {
        float[] res = new float[v1.Length];
        if (v1.Length != v2.Length) return res;

        for (int k = 0; k < v1.Length; k++)
        {
            if (v2[k] == 0) res[k] = 0; // Захист від ділення на нуль
            else res[k] = v1[k] / v2[k];
        }
        return res;
    }

    static void Main()
    {
        string input = "start.txt";
        string output = "result.txt";

        float[][] allVectors = getvectors(input);

        // Витягуємо перший та другий вектори з файлу
        float[] a = allVectors[0];
        float[] b = allVectors[1];

        string log = "";
        log += parsevector(a) + " + " + parsevector(b) + " = " + parsevector(plus(a, b)) + "\n";
        log += parsevector(a) + " - " + parsevector(b) + " = " + parsevector(minus(a, b)) + "\n";
        log += parsevector(a) + " * " + parsevector(b) + " = " + parsevector(multi(a, b)) + "\n";
        log += parsevector(a) + " / " + parsevector(b) + " = " + parsevector(div(a, b)) + "\n";

        // Записуємо результати у файл
        File.WriteAllText(output, log);
    }
}
