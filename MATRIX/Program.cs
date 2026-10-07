using System;
using System.IO;

namespace matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("matrix.txt");
            string[] lines = text.Split('\n');
            int[,] a = new int[2, 2];
            int[,] b = new int[2, 2];
            for (int i = 0; i < 2; i++)
            {
                string[] numbersA = lines[i].Split(' ');
                string[] numbersB = lines[i + 3].Split(' ');
                
                for (int j = 0; j < 2; j++)
                {
                  a[i, j] = int.Parse(numbersA[j]);  
                  b[i,j]=int.Parse(numbersB[j]);
                }
            }
            string result = $"Sum (A+B):\n{Matrix.Print<double>(Matrix.SumMatrix(a, b))}\n" + $"Sub (A-B):\n{Matrix.Print<double>(Matrix.SubMatrix(a, b))}\n" + $"Mult (A*B):\n{Matrix.Print<double>(Matrix.MultMatrix(a, b))}\n" + $"Div (A/B):\n{Matrix.Print<double>(Matrix.DivMatrix(a, b))}";
            File.WriteAllText("resultM.txt", result);      
           
            
        }
    }
}