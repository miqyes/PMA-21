using System;
using System.IO;
using System.Collections.Generic;
namespace Task1;

class Task1 {
    static void Main() {
        string input = File.ReadAllText("input.txt");
        int steps = int.Parse(File.ReadAllText("steps.txt"));

        string[] parts = input.Split(' ');
        int first = int.Parse(parts[0]);
        int second = int.Parse(parts[1]);

        List<int> list = new List<int>();
        if (steps >= 1) list.Add(first);
        if (steps >= 2) list.Add(second);

        for (int i = 2; i < steps; i++){
            list.Add(list[i-1] + list[i-2]);
        }

        string result = string.Join(",", list);
        File.WriteAllText("result.txt", result);
        Console.WriteLine(result);
    }
}
