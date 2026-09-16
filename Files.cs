using System;
using System.Collections.Generic;
using System.IO;

namespace TaskOne;

class Program {
    public static int[] ReadFile(string fileName) {
        if (!File.Exists(fileName)) {
            Console.WriteLine($"Файл {fileName} не існує. Перевірте вхідні дані.");
            return new int[0];
        }

        string text = File.ReadAllText(fileName);
        string[] parts = text.Split(' ', ',');

        int[] numbers = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++) {
            numbers[i] = int.Parse(parts[i]);
        }
        return numbers;
    }

    static void Main() {
        int[] input = ReadFile("input.txt");
        int[] steps = ReadFile("steps.txt");
        int[] limit = ReadFile("limit.txt");

        if (input.Length < 2 || steps.Length == 0 || limit.Length == 0) {
            Console.WriteLine("Недостатньо даних для обчислення ряду Фібоначчі. Оновіть дані, щоб розрахувати ряд.");
            return;
        }

        List<int> list = new List<int>(input);
        var resultList = Fibonachi.FibCalculate(list, steps[0]);

        File.WriteAllText("result.txt", "[" + string.Join(", ", resultList) + "]");
        Console.WriteLine($"Дані успішно записано у файл resuly.txt. Застосований ліміт: {limit[0]}");
    }
}
