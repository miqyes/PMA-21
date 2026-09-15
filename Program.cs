using System;
using System.Collections.Generic;
using System.IO;

namespace fibonacci; 

class Program {
    static void Main(string[] args) { 

        if (!File.Exists("fib1.txt")) {
            Console.WriteLine("Error: file fib1.txt not found");
            return;
        }

        if (!File.Exists("fib2.txt")) {
            Console.WriteLine("Error: file fib2.txt not found");
            return;
        }
        
        string text = File.ReadAllText("fib1.txt");

        if (text == "") {
            Console.WriteLine("Error: file fib1.txt is empty");
            return;
        }

        string[] numbers = text.Split(' ');

        if (text.Split(' ').Length != 2) {
            Console.WriteLine("Error: file fib1.txt must contain exactly 2 numbers");
            return;
        }

        int first = int.Parse(numbers[0]); 
        int second = int.Parse(numbers[1]);

        if (first < 0 || second < 0) {
            Console.WriteLine("Error: numbers in fib1.txt must be positive");
            return;
        }

        List<int> fibonacciNumbers = new List<int>();
        fibonacciNumbers.Add(first); 
        fibonacciNumbers.Add(second); 

        string stepsText = File.ReadAllText("fib2.txt"); 

        if (stepsText == "") {
            Console.WriteLine("Error: file fib2.txt is empty");
            return;
        }
        string[] stepsNumber = stepsText.Split(' ');
        if (stepsNumber.Length != 2) {
            Console.WriteLine("Error: file fib2.txt must contain exactly 2 numbers");
            return;
        }
        int steps = int.Parse(stepsNumber[0]);
        int limit = int.Parse(stepsNumber[1]);

        if (steps <= 0 || limit <= 0)
        {
            Console.WriteLine("Count and limit must be positive");
            return;
        }

        Fibonacci.GenerateCount(fibonacciNumbers, steps - fibonacciNumbers.Count, limit); 
        string result = string.Join(" ", fibonacciNumbers); 

        Console.WriteLine(result);

        File.WriteAllText("fib.txt", result);
    }

}
