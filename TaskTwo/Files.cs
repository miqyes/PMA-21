using System;
using System.IO;
namespace TaskTwo;

class FileWork {
    public const string VECTORS = "vectorsData.txt";
    public const string RESULT = "result.txt";

    public static Vector FileData(string line) {
        string[] parts = line.Split(",");

        if (parts.Length != 3) {
            return null;
        }

        double x = double.Parse(parts[0]);
        double y = double.Parse(parts[1]);
        double z = double.Parse(parts[2]);
        return new Vector(x, y, z);
    }

    public static Vector[] ReadFile(string fileName) {
        if (!File.Exists(fileName)) {
            Console.WriteLine($"File {fileName} does not exist.");
            return new Vector[0];
        }

        string[] lines = File.ReadAllLines(fileName);
        Vector[] vectors = new Vector[lines.Length];

        for (int i = 0; i < lines.Length; i++) {
            vectors[i] = FileData(lines[i]);
        }
        return vectors;
    }
}

class Files {
    static void Main(string[] args) {
        Vector[] vectors = FileWork.ReadFile(FileWork.VECTORS);

        if (vectors.Length < 2) {
            Console.WriteLine("Not enough vectors in the file to perform calculations.");
            return;
        }

        Vector v1 = vectors[0];
        Vector v2 = vectors[1];

        if (v1 == null || v2 == null) {
            Console.WriteLine("Vectors are diffrent sizes!");
            return;
        }

        Vector sum = Vector.Add(v1, v2);
        Vector difference = Vector.Subtract(v1, v2);
        Vector multiplication = Vector.Multiply(v1, v2);
        Vector division = Vector.Divide(v1, v2);

        string divisionText;
        if (division != null) {
            divisionText = division.ToString();
        } else {
            divisionText = "Error. Devided by zero.";
        }

        string result =
            $"{v1.ToString()} + {v2.ToString()} = {sum.ToString()}\n" +
            $"{v1.ToString()} - {v2.ToString()} = {difference.ToString()}\n" +
            $"{v1.ToString()} * {v2.ToString()} = {multiplication.ToString()}\n" +
            $"{v1.ToString()} / {v2.ToString()} = {divisionText}\n";

        Console.WriteLine(result);
        File.WriteAllText(FileWork.RESULT, result);

        Console.WriteLine("Your results was successfully saved to file!");
    }
}
