using System;
using System.IO;
 
class Program
{
    static void Main()
    {
        string text = File.ReadAllText("input.txt");
        string[] parts = text.Split(',');
 
        int a = int.Parse(parts[0].Trim());
        int b = int.Parse(parts[1].Trim());
        
        int steps = int.Parse(File.ReadAllText("steps.txt").Trim());

        int[] row = new int[steps];
 
        if (steps >= 1)
            row[0] = a;
        if (steps >= 2)
            row[1] = b;
        
        for (int i = 2; i < steps; i++)
        {
            row[i] = row[i - 1] + row[i - 2];
        }
 
        string result = "";
        for (int i = 0; i < steps; i++)
        {
            result = result + row[i];
            if (i < steps - 1)
                result = result + ",";
        }
 
        File.WriteAllText("output.txt", result);
 
        Console.WriteLine("Результат: " + result);
    }
}