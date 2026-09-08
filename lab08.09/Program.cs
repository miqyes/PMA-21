using System;
using System.Collections.Generic;
using System.IO;

string stepsText = File.ReadAllText("steps.txt").Trim();
int count = Convert.ToInt32(stepsText);

string inputText = File.ReadAllText("input.txt").Trim();
string[] parts = inputText.Split(',');

int first = Convert.ToInt32(parts[0]);
int second = Convert.ToInt32(parts[1]);

int Fib(int n)
{
    if (n == 0) return first;
    if (n == 1) return second;
    return Fib(n - 1) + Fib(n - 2);
}

List<int> result = new List<int>();

for (int i = 0; i < count; i++)
{
    result.Add(Fib(i));
}

Console.WriteLine("Saved in output.txt");
File.WriteAllText("output.txt", string.Join(", ", result));