using System;
namespace TaskFour;

public class Vector {
    public int[] Elements;
    public int Length;

    public Vector(int[] elements) {
        Elements = elements;
        Length = elements.Length;
    }

    public int GetLength() {
        return Elements.Length;
    }

    public static Vector Parse(string line) {
        string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int[] elements = new int[parts.Length];
        
        for (int i = 0; i < parts.Length; i++) {
            elements[i] = int.Parse(parts[i]);
        }
        return new Vector(elements);
    }

    public bool ContainsZero() {
        for (int i = 0; i < Elements.Length; i++) {
            if (Elements[i] == 0) {
                return true;
            }
        }
        return false;
    }

    public override string ToString() {
        return string.Join(", ", Elements);
    }
}
