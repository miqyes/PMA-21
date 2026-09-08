using System;
using System.IO;

class Program

{
    static List<int> Recursion (List<int> list, int c) //рекурсивна функція(викликає сама себе) працює до моменту поки с не стане <=0
    {
        if (c <= 0) return list;
        //наші останні числа зі спсику беремо і додаємо, результат ставимо в кінець
        list.Add(list[list.Count - 1] + list[list.Count - 2]);

        return Recursion(list, c - 1);
    }

    static void Main()
    {
        if (!File.Exists("input.txt") || !File.Exists("steps.txt") )
        {
            Console.WriteLine("Error: files are not found!");
            return;
        } // Перевіряємо існування файлів
        string input = File.ReadAllText("input.txt");
        string steps = File.ReadAllText("steps.txt").Trim();


        string[]  numbers = input.Split(','); //split розділяє рядок комами(може бути інший розділовий)
        if (numbers.Length != 2)
        {
            Console.WriteLine("Error: in file 'input.txt' must be 2 numbers!");
            return;
        } //чи дійсно у файлі інпут лежить рівно два числа через кому, 
        // бо якщо там буде якась інша кількість, то програма впаде при спробі звернутися до індексів масиву
        int a = int.Parse(numbers[0]);
        int b = int.Parse(numbers[1]);
        int c = int.Parse(steps);
        if (a < 0 || b < 0 || c < 0)
        {
            Console.WriteLine ("Error: numbers can't be negative!");
            return;
        } //перевіряємо чи немає у файлах від'ємних чисел
        List<int> list = new List<int> { a, b }; //створення списку вже з двома числами
        Recursion(list, c - 2); //тому рекурсія викликається -2, щоб в результаті було 5 чисел

        string result =  string.Join(", ", list); //join навпаки від split з'єднує новий список комамин 
        File.WriteAllText("result.txt", result);

        Console.WriteLine("Result is in file 'result.txt' ");
    }
}