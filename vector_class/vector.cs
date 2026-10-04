using System;
using System.Numerics;
using System.Runtime.ExceptionServices;

namespace program 
{

    public class Vector
    {
        public double[] Coordinates;

        public Vector(double[] coordinates)
        {
            Coordinates = coordinates;
        }
        
        public int Dimension
        {
            get { return Coordinates.Length; }
        }

        private static void CheckDimensions(Vector a, Vector b)
        {
            if (a.Dimension != b.Dimension)
                throw new InvalidOperationException($"Various size: {a.Dimension} & {b.Dimension}");
        }

        public static Vector operator +(Vector a, Vector b)
        {
            CheckDimensions(a, b);
            double[] res = new double[a.Dimension];
            for (int i = 0; i < a.Dimension; i++)
                res[i] = a.Coordinates[i] + b.Coordinates[i];
            return new Vector(res);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            CheckDimensions(a, b);
            double[] res = new double[a.Dimension];
            for(int i = 0; i < a.Dimension; i++)
                res[i] = a.Coordinates[i] - b.Coordinates[i];
            return new Vector(res);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            CheckDimensions(a, b);
            double[] res = new double[a.Dimension];
            for (int i = 0; i < a.Dimension; i++)
                res[i] = a.Coordinates[i] * b.Coordinates[i];
            return new Vector(res);
        }

        public static Vector operator /(Vector a, Vector b)
        {
            CheckDimensions(a, b);
            double[] res = new double[a.Dimension];
            for (int i = 0; i < a.Dimension; i++)
            {
                if (b.Coordinates[i] == 0)
                    res[i] = double.NaN;
                else
                    res[i] = a.Coordinates[i] / b.Coordinates[i];
            }
            return new Vector(res);
        }

        public override string ToString()
        {
            string s = "(";
            for (int i = 0; i < Coordinates.Length; i++)
            {
                if (double.IsNaN(Coordinates[i]))
                    s += "imposible to divide by zero";
                else
                    s += Math.Round(Coordinates[i], 2);

                if (i < Coordinates.Length - 1)
                    s += ", ";
            }
            s += ")";
            return s;
        }
    }

    public static class VectorFileManager
    {
        public static Vector[] ReadVectors(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File was not found");
            }

            string[] lines = File.ReadAllLines(filePath);
            Vector[] vectors = new Vector[lines.Length];
            char[] skip = { ' ', ',', '(', ')' };

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(skip, StringSplitOptions.RemoveEmptyEntries);
                double[] coords = new double[parts.Length];

                for (int j = 0; j < parts.Length; j++)
                    coords[j] = double.Parse(parts[j]);
                vectors[i] = new Vector(coords);
            }

            return vectors;
        }

        public static void WriteResults(string filePath, string[] result)
        {
            File.WriteAllLines(filePath, result);
        }
    }
}