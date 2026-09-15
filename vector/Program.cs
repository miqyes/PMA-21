using System;
using System.IO;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string inputFile = "input.txt";
            string outputFile = "output.txt";

            double[][] vectors;

            try
            {
                vectors = FileManager.ReadVectors(inputFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при читанні: " + ex.Message);
                return;
            }

            if (vectors.Length < 2)
            {
                Console.WriteLine("Файл повинен містити хоча б 2 вектори!");
                return;
            }

            int pairsCount = vectors.Length - 1;
            string[] report = new string[pairsCount * 6];
            int reportIndex = 0;

            for (int i = 0; i < pairsCount; i++)
            {
                double[] v1 = vectors[i];
                double[] v2 = vectors[i + 1];

                report[reportIndex++] = $"--- Пара {i + 1} та {i + 2} ---";

                try
                {
                    double[] sum = VectorOperations.Add(v1, v2);
                    report[reportIndex++] = $"{VectorOperations.Format(v1)} + {VectorOperations.Format(v2)} = {VectorOperations.Format(sum)}";

                    double[] sub = VectorOperations.Subtract(v1, v2);
                    report[reportIndex++] = $"{VectorOperations.Format(v1)} - {VectorOperations.Format(v2)} = {VectorOperations.Format(sub)}";

                    double[] mul = VectorOperations.Multiply(v1, v2);
                    report[reportIndex++] = $"{VectorOperations.Format(v1)} * {VectorOperations.Format(v2)} = {VectorOperations.Format(mul)}";

                    try
                    {
                        double[] div = VectorOperations.Divide(v1, v2);
                        report[reportIndex++] = $"{VectorOperations.Format(v1)} / {VectorOperations.Format(v2)} = {VectorOperations.Format(div)}";
                    }
                    catch (DivideByZeroException ex)
                    {
                        report[reportIndex++] = $"{VectorOperations.Format(v1)} / {VectorOperations.Format(v2)} = Помилка ({ex.Message})";
                    }
                }
                catch (InvalidOperationException ex)
                {
                    report[reportIndex++] = $"Помилка розмірності: {ex.Message}";
                }

                report[reportIndex++] = "";
            }

            FileManager.WriteLines(outputFile, report);
            Console.WriteLine("Готово! Результати збережено в " + outputFile);
        }
    }
}