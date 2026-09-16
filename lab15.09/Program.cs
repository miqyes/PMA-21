using System;
using System.Collections.Generic;
using System.IO;

namespace Task2;

class Vector
{
    public double[] Coords;

    public Vector(int size)
    {
        Coords = new double[size];
    }

    public Vector(double[] coords)
    {
        Coords = coords;
    }

    public static Vector operator +(Vector a, Vector b)
    {
        Vector res = new Vector(a.Coords.Length);
        for (int i = 0; i < a.Coords.Length; i++)
            res.Coords[i] = a.Coords[i] + b.Coords[i];
        return res;
    }

    public static Vector operator -(Vector a, Vector b)
    {
        Vector res = new Vector(a.Coords.Length);
        for (int i = 0; i < a.Coords.Length; i++)
            res.Coords[i] = a.Coords[i] - b.Coords[i];
        return res;
    }

    public static Vector operator *(Vector a, Vector b)
    {
        Vector res = new Vector(a.Coords.Length);
        for (int i = 0; i < a.Coords.Length; i++)
            res.Coords[i] = a.Coords[i] * b.Coords[i];
        return res;
    }

    public static Vector operator /(Vector a, Vector b)
    {
        Vector res = new Vector(a.Coords.Length);
        for (int i = 0; i < a.Coords.Length; i++)
            res.Coords[i] = b.Coords[i] != 0 ? a.Coords[i] / b.Coords[i] : 0;
        return res;
    }

    public override string ToString()
    {
        return "(" + string.Join("; ", Coords) + ")";
    }
}

class Program
{
    static List<Vector> ReadVectors(string path)
    {
        List<Vector> list = new List<Vector>();
        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string cleaned = line.Replace("(", "").Replace(")", "").Trim();
            string[] rawNumbers = cleaned.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double[] coords = new double[rawNumbers.Length];
            for (int i = 0; i < rawNumbers.Length; i++)
            {
                coords[i] = double.Parse(rawNumbers[i]);
            }

            list.Add(new Vector(coords));
        }

        return list;
    }

    static void Main()
    {
        if (!File.Exists("vector.txt"))
        {
            Console.WriteLine("File vector.txt not found!");
            return;
        }

        List<Vector> vectors = ReadVectors("vector.txt");
        List<string> logs = new List<string>();

        logs.Add("ALL VECTORS:");
        for (int i = 0; i < vectors.Count; i++)
        {
            string info = $"{i + 1}) {vectors[i]}";
            Console.WriteLine(info);
            logs.Add(info);
        }

        logs.Add("\nRESULTS:");

        for (int i = 0; i < vectors.Count - 1; i += 2)
        {
            Vector v1 = vectors[i];
            Vector v2 = vectors[i + 1];

            logs.Add($"\nPair {i / 2 + 1}:");
            logs.Add($"Add: {v1} + {v2} = {v1 + v2}");
            logs.Add($"Subtract: {v1} - {v2} = {v1 - v2}");
            logs.Add($"Multiply: {v1} * {v2} = {v1 * v2}");
            logs.Add($"Divide: {v1} / {v2} = {v1 / v2}");
        }

        File.WriteAllLines("result.txt", logs);
        Console.WriteLine("\nDone! Saved to result.txt");
    }
}