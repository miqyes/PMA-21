using System;
using System.IO;

namespace LabVector;

public class Program
{
    
    public static void Main(string[] args)
    {
        
        string input = File.ReadAllText("vectors.txt");
        string[] lines = input.Split('\n');
        string[] vector = lines[0].Split(" ");   
        string[] Vector = lines[1].Split(" ");

        if (Vectors.Check(vector, Vector) == false)
        {
            return;
        }

        for (int j = 0; j < 3; j++)
        {
            Vectors.masVector[0,j] = double.Parse(vector[j]);
            Vectors.masVector[1,j] = double.Parse(Vector[j]);
        }
        
        File.WriteAllText("rezult.txt", "");
        string[] operations = { "+", "-", "*", "/" };
        foreach (string operation in operations)
        {
            double[]result=new double[3];

            switch (operation)
            {
                case "+":
                    for (int j = 0; j < 3; j++)
                    {
                        result[j] = Vectors.Add(Vectors.masVector[0, j], Vectors.masVector[1, j]);
                    }

                    File.AppendAllText("rezult.txt", $"Add+: {result[0]}; {result[1]}; {result[2]}\n");
                    break;

                case "-":
                    for (int j = 0; j < 3; j++)
                    {
                        result[j] = Vectors.Subtract(Vectors.masVector[0, j], Vectors.masVector[1, j]);
                    }

                    File.AppendAllText("rezult.txt", $"Subtract-: {result[0]}; {result[1]}; {result[2]}\n");
                    break;

                case "*":
                    for (int j = 0; j < 3; j++)
                    {
                        result[j] = Vectors.Multiply(Vectors.masVector[0, j], Vectors.masVector[1, j]);
                    }

                    File.AppendAllText("rezult.txt", $"Multiply*: {result[0]}; {result[1]}; {result[2]}\n");
                    break;

                case "/":
                    for (int j = 0; j < 3; j++)
                    {
                        result[j] = Vectors.CheckDivide(Vectors.masVector[0, j], Vectors.masVector[1, j]);
                    }

                    File.AppendAllText("rezult.txt", $"Divide/: {result[0]}; {result[1]}; {result[2]}\n");
                    break;
            }
        }
           
    }
}
