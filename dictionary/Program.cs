using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string filePath = "output.txt";

        if (File.Exists(filePath))
            File.Delete(filePath);

        Wordhord<string, int> scores = new Wordhord<string, int>();

        // Додавання елементів
        Console.WriteLine("1. Додавання елементів:");
        scores.Add("Математика", 90);
        scores.Add("Програмування", 98);
        scores.Add("Фізика", 75);
        
        scores.PrintAll();
        File.AppendAllText(filePath, "=== 1. ДОДАВАННЯ ЕЛЕМЕНТІВ ===\n");
        scores.PrintAll(filePath, append: true);

        // Читання елемента
        Console.WriteLine("2. Читання елемента:");
        string mathGrade = $"Оцінка з Математики: {scores["Математика"]}\n";
        Console.WriteLine(mathGrade);
        File.AppendAllText(filePath, $"\n=== 2. ЧИТАННЯ ЕЛЕМЕНТА ===\n{mathGrade}\n");

        // Редагування елемента
        Console.WriteLine("3. Редагування (зміна оцінки з Фізики на 85):");
        scores["Фізика"] = 85;
        
        scores.PrintAll();
        File.AppendAllText(filePath, "=== 3. ПІСЛЯ РЕДАГУВАННЯ ФІЗИКИ (85) ===\n");
        scores.PrintAll(filePath, append: true);

        // Видалення елемента
        Console.WriteLine("4. Видалення Фізики:");
        bool removed = scores.Remove("Фізика");
        Console.WriteLine($"Видалено успішно: {removed}\n");
        
        scores.PrintAll();
        File.AppendAllText(filePath, $"=== 4. ПІСЛЯ ВИДАЛЕННЯ ФІЗИКИ (успішно: {removed}) ===\n");
        scores.PrintAll(filePath, append: true);

        // Перевірка спроби додати дублікат
        Console.WriteLine("5. Перевірка додавання дубліката:");
        try
        {
            scores.Add("Програмування", 100);
        }
        catch (ArgumentException ex)
        {
            string err = $"Перехоплено помилку: {ex.Message}";
            Console.WriteLine(err);
            File.AppendAllText(filePath, $"\n=== 5. ПЕРЕВІРКА ДУБЛІКАТА ===\n{err}\n");
        }
    }
}