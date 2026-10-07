using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";

       /* if (!File.Exists(inputFile))
        {
            File.WriteAllLines(inputFile, new string[] { "(1, 2, 3)", "(4, 5, 6)" });
            Console.WriteLine($"Створено файл {inputFile}.");
        }
       */
        Vector firstVector = null;
        Vector secondVector = null;

        try
        {
            string[] lines = File.ReadAllLines(inputFile);
            if (lines.Length < 2)
            {
                Console.WriteLine("Error: you need 2 vectors.");
                return;
            }

            Vector[] vectors = new Vector[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                double[] data = lines[i].Replace("(", "").Replace(")", "")
                                        .Split(',')
                                        .Select(double.Parse).ToArray();
                vectors[i] = new Vector(data);
            }

            firstVector = vectors[0];
            secondVector = vectors[1];

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("--- operations with vectors ---");

                Vector sum = firstVector + secondVector;
                writer.WriteLine($"{firstVector} + {secondVector} = {sum}");
                Console.WriteLine($"{firstVector} + {secondVector} = {sum}");

                Vector diff = firstVector - secondVector;
                writer.WriteLine($"{firstVector} - {secondVector} = {diff}");
                Console.WriteLine($"{firstVector} - {secondVector} = {diff}");

                Vector mult = firstVector * secondVector;
                writer.WriteLine($"{firstVector} * {secondVector} = {mult}");
                Console.WriteLine($"{firstVector} * {secondVector} = {mult}");

                Vector div = firstVector / secondVector;
                writer.WriteLine($"{firstVector} / {secondVector} = {div}");
                Console.WriteLine($"{firstVector} / {secondVector} = {div}");
            }

            Console.WriteLine($"result saved in {outputFile}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Error: {firstVector} / {secondVector} {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
