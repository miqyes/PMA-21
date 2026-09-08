using System;
using System.IO; 
using System.Collections.Generic;

namespace UNI{
class Program
{
    static void Main()
    {
        string inpath="input.txt";
        string steppath="steps.txt";
        
        if (File.Exists(inpath))
        {
            Console.WriteLine("Input file exists");
        }
        else { Console.WriteLine("Input file does not exist"); }

        if (File.Exists(steppath))
        {
            Console.WriteLine("Step file exists");
        }
        else { Console.WriteLine("Step file does not exist"); }
        
        string[] values = File.ReadAllText("input.txt").Trim().Split(',');
        int first=int.Parse(values[0]);
        int second=int.Parse(values[1]);
        int step = int.Parse(File.ReadAllText("steps.txt").Trim());

        
        var el = new List<int>();
        if(step>=1) el.Add(first);
        if(step>=2) el.Add(second);
        for (int i = 2; i < step; i++)
        {
            int nextel = el[i - 1] + el[i - 2];
            el.Add(nextel);
        }

        string result = string.Join(",", el);
        File.WriteAllText("output.txt", result);
        
        Console.WriteLine(result);
    }
}
}