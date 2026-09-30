using System;
namespace TaskTwo;

public class Vector {
    public double X;
    public double Y;
    public double Z;

    public Vector(double x, double y, double z) {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vector Add(Vector v1, Vector v2) {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    public static Vector Subtract(Vector v1, Vector v2) {
        return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    public static Vector Multiply(Vector v1, Vector v2) {
        return new Vector(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
    }

    public static Vector Divide(Vector v1, Vector v2) {
        if (v2.X == 0 || v2.Y == 0 || v2.Z == 0) {
            Console.WriteLine("You can NOT divide by zero. Please change your coordinate then try again.");
            return null;
        }
        return new Vector(v1.X / v2.X, v1.Y / v2.Y, v1.Z / v2.Z);
    }

    public override string ToString() {
        return $"({X}, {Y}, {Z})";
    }
}
