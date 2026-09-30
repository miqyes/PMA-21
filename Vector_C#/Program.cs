using System;
using System.IO;

namespace Vector_C_
{ 
    public class Vector
    {
        public double X;
        public double Y;
        public double Z;

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public static Vector Add(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        public static Vector Subtract(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
        public static Vector Multiply(Vector v1, Vector v2)
        {
            return new Vector(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
        }
        public static Vector Divide(Vector v1, Vector v2)
        {
            return new Vector(v1.X / v2.X, v1.Y / v2.Y, v1.Z / v2.Z);
        }
        public string toVector()
        {
            return $"({X},{Y},{Z})";
        }
    }

    public class fileWorker
    {
        public static Vector ReadVector(string line)
        {
            string[] parts = line.Split(',');

            double x = double.Parse(parts[0]);
            double y = double.Parse(parts[1]);
            double z = double.Parse(parts[2]);
            return new Vector(x, y, z);
        }

        public static void Result(string fileName, string text)
        {
            File.WriteAllText(fileName, text);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            Vector v1 = fileWorker.ReadVector(lines[0]);
            Vector v2 = fileWorker.ReadVector(lines[1]);

            Vector suma = Vector.Add(v1, v2);
            Vector difference = Vector.Subtract(v1, v2);
            Vector multiplication = Vector.Multiply(v1,v2);
            Vector dividion = Vector.Divide(v1, v2);

            string result =
                $"{v1.toVector()}+{v2.toVector()}={suma.toVector()}\n" +
                $"{v1.toVector()}-{v2.toVector()}={difference.toVector()}\n" +
                $"{v1.toVector()}*{v2.toVector()}={multiplication.toVector()}\n" +
                $"{v1.toVector()}/{v2.toVector()}={dividion.toVector()}";

            Console.WriteLine(result);
            fileWorker.Result("result.txt", result);
        }
    }
}
