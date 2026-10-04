using System;

namespace Fibonachi;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Меню");
        Console.WriteLine("1. Обчислити за кількістю кроків (steps.txt)");
        Console.WriteLine("2. Обчислити до ліміту числа");
        Console.WriteLine("0. Вихід");
        Console.Write("Оберіть пункт: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                FibonacciTasks.TaskBySteps();
                break;
            case "2":
                FibonacciTasks.TaskByLimit();
                break;
            case "0":
                Console.WriteLine("Завершення програми.");
                break;
            default:
                Console.WriteLine("Невірний вибір!");
                break;
        }
    }
}