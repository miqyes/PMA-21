using System;
using System.Collections.Generic;
using System.IO;

string stepsText = File.ReadAllText("steps.txt").Trim();
int count = Convert.ToInt32(stepsText);

string inputText = File.ReadAllText("input.txt").Trim();
string[] parts = inputText.Split(',');

int first = Convert.ToInt32(parts[0]);
int second = Convert.ToInt32(parts[1]);

List<int> result = new List<int>();

if (count >= 1)
{
    result.Add(first);
}

if (count >= 2)
{
    result.Add(second);
}

for (int i = 2; i < count; i++)
{
    result.Add(result[i - 1] + result[i - 2]);
}

string outputText = string.Join(",", result);
File.WriteAllText("output.txt", outputText);

Console.WriteLine("Saved in output.txt");