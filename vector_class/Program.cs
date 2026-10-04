using System;

namespace program
{
    class Program
    {
        static void Main()
        {
            Vector[] vectors = VectorFileManager.ReadVectors("input.txt");

            string[] results = new string[(vectors.Length / 2) * 4];
            int k = 0;

            for (int i = 0; i < vectors.Length - 1; i += 2)
            {
                results[k++] = $"{vectors[i]} + {vectors[i + 1]} = {vectors[i] + vectors[i + 1]}";
                results[k++] = $"{vectors[i]} - {vectors[i + 1]} = {vectors[i] - vectors[i + 1]}";
                results[k++] = $"{vectors[i]} * {vectors[i + 1]} = {vectors[i] * vectors[i + 1]}";
                results[k++] = $"{vectors[i]} / {vectors[i + 1]} = {vectors[i] / vectors[i + 1]}";
            }

            VectorFileManager.WriteResults("output.txt", results);
        }
    }
}