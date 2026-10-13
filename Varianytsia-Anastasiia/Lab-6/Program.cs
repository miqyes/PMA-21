using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string INPUT_PATH = "input.txt";
        string OUTPUT_PATH = "output.txt";

        ArrayList list = FileManager.LoadListFromFile(INPUT_PATH);

        List<string> results = [];

        results.Add("Початковий список: " + list.ToString());
        results.Add("Елементів: " + list.Count + ", розмір масиву: " + list.Capacity);

        for (int value = 1; value <= 7; value++)
        {
            int oldCapacity = list.Capacity;

            list.Add(value);

            string line = "Додано " + value + ": " + list.ToString();

            if (list.Capacity != oldCapacity)
            {
                line += " (масив розширився з " + oldCapacity + " до " + list.Capacity + ")";
            }

            results.Add(line);
        }

        if (list.Insert(2, 999))
        {
            results.Add("Вставка 999 на індекс 2: " + list.ToString());
        }
        else
        {
            results.Add("Помилка: неправильний індекс для вставки.");
        }

        if (!list.Insert(50, 111))
        {
            results.Add("Вставка 111 на індекс 50 неможлива: такого індексу немає.");
        }
        

        if (list.RemoveByIndex(0))
        {
            results.Add("Видалено елемент з індексом 0: " + list.ToString());
        }

        if (!list.RemoveByIndex(50))
        {
            results.Add("Видалення за індексом 50 неможливе: такого індексу немає.");
        }

        if (list.RemoveByValue(999))
        {
            results.Add("Видалено значення 999: " + list.ToString());
        }

        if (!list.RemoveByValue(12345))
        {
            results.Add("Значення 12345 у списку не знайдено.");
        }

        list.Clear();
        results.Add("Після очищення: " + list.ToString() + ", елементів: " + list.Count);

        FileManager.SaveResultToFile(OUTPUT_PATH, results);
    }
}