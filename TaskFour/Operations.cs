using System;
namespace TaskFour;

public class VectorOperations {
    public Vector Add(Vector a, Vector b) {
        int[] c = new int[a.Length];
        for (int i = 0; i < c.Length; i++) {
            if (i == a.Length - 1) {
                c[i] = a.Elements[i] + b.Elements[0];
            }
            else {
                c[i] = a.Elements[i] + b.Elements[i + 1];
            }
        }
        return new Vector(c);
    }

    public Vector Subtract(Vector a, Vector b) {
        int[] c = new int[a.Length];
        for (int i = 0; i < c.Length; i++) {
            c[i] = a.Elements[i] - b.Elements[i];
        }
        return new Vector(c);
    }

    public Vector Multiply(Vector a, Vector b) {
        int[] c = new int[a.Length];
        for (int i = 0; i < c.Length; i++) {
            c[i] = a.Elements[i] * b.Elements[i];
        }
        return new Vector(c);
    }

    public double[] Divide(Vector a, Vector b) {
        double[] c = new double[a.Length];
        for (int i = 0; i < c.Length; i++) {
            c[i] = (double)a.Elements[i] / b.Elements[i];
        }
        return c;
    }

    public string FormatResults(Vector a, Vector b, Vector sum, Vector sub, Vector mult, double[] div) {
        string divString = string.Join(", ", div);
        return "Results:\n" +
               $"({a}) + ({b}) = ({sum})\n" +
               $"({a}) - ({b}) = ({sub})\n" +
               $"({a}) * ({b}) = ({mult})\n" +
               $"({a}) / ({b}) = ({divString})\n";
    }
}
