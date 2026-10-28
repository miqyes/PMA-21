using System;
using System.IO;
namespace TaskFour;

class Program {
    static void Main(string[] args) {
        string inputFile = "Vectors.txt";
        string outputFile = "Results.txt";

        if (!File.Exists(inputFile)) {
            Console.WriteLine($"File {inputFile} is NOT found!");
            return;
        }

        string[] lines = File.ReadAllLines(inputFile);
        if (lines.Length < 2) {
            Console.WriteLine($"File {inputFile} has to have at least 2 lines!");
            return;
        }

        Vector a = Vector.Parse(lines[0]);
        Vector b = Vector.Parse(lines[1]);

        if (a.Length != b.Length) {
            Console.WriteLine("Vectors are NOT equal in length.");
            return;
        }

        if (b.ContainsZero()) {
            Console.WriteLine("Second vector can not contain zero! Error: division by zero.");
            return;
        }

        VectorOperations operations = new VectorOperations();

        Vector sum = operations.Add(a, b);
        Vector sub = operations.Subtract(a, b);
        Vector mult = operations.Multiply(a, b);
        double[] div = operations.Divide(a, b);

        string outputContent = operations.FormatResults(a, b, sum, sub, mult, div);
        File.WriteAllText(outputFile, outputContent);

        Console.WriteLine($"Results are successfully saved to {outputFile}.");
    }
}
