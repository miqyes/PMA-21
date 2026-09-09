using System;
using System.IO;
using System.Collections.Generic;

string text = File.ReadAllText("input.txt");
string[] parts = text.Split(',');

int a = int.Parse(parts[0].Trim());
int b = int.Parse(parts[1].Trim());

int steps = int.Parse(File.ReadAllText("steps.txt").Trim());

List<int> row = new List<int>();

if (steps >= 1)
    row.Add(a);
if (steps >= 2)
    row.Add(b);

for (int i = 2; i < steps; i++)
{
    row.Add(row[i - 1] + row[i - 2]);
}

string result = string.Join(",", row);

File.WriteAllText("output.txt", result);

Console.WriteLine("Результат: " + result);
