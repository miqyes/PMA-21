using System;
using System.Text;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.WriteLine("=== ТЕСТУВАННЯ ARRAYLIST ===");

        var list = new ArrayList<int>(10);
        Console.WriteLine($"Створено список: Count = {list.Count}, Capacity = {list.Capacity}");

        Console.WriteLine("\n--- 1. Заповнення 10 елементами (Add) ---");
        for (int i = 1; i <= 10; i++)
        {
            list.Add(i * 10);
        }
        PrintList(list);

        Console.WriteLine("\n--- 2. Додавання 11-го елемента (перевірка розширення) ---");
        Console.WriteLine("Очікуємо: зміна Capacity з 10 на 16");
        list.Add(110);
        PrintList(list);

        Console.WriteLine("\n--- 3. Вставка по індексу (Insert) ---");
        Console.WriteLine("Вставляємо 999 на позицію 2:");
        list.Insert(2, 999);
        PrintList(list);

        Console.WriteLine("\n--- 4. Пошук індексу (IndexOf) ---");
        int index = list.IndexOf(999);
        Console.WriteLine($"Індекс елемента 999: {index}");
        Console.WriteLine($"Індекс неіснуючого елемента 500: {list.IndexOf(500)}");

        Console.WriteLine("\n--- 5. Видалення по індексу (RemoveAt) ---");
        Console.WriteLine($"Видаляємо елемент за індексом {index} (число 999):");
        list.RemoveAt(index);
        PrintList(list);

        Console.WriteLine("Видаляємо нульовий елемент (число 10):");
        list.RemoveAt(0);
        PrintList(list);

        Console.WriteLine("\n--- 6. Повне очищення (Clear) ---");
        list.Clear();
        Console.WriteLine($"Після Clear: Count = {list.Count}, Capacity = {list.Capacity}");
        PrintList(list);
    }

    static void PrintList(ArrayList<int> list)
    {
        Console.Write("Вміст списку: [ ");
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write($"{list[i]} ");
        }
        Console.WriteLine($"] | Count = {list.Count}, Capacity = {list.Capacity}");
    }
}