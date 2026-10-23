using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string INPUT_PATH = "input.txt";
        string OUTPUT_PATH = "output.txt";

        int FIRST_ADDED_VALUE = 100;
        int LAST_ADDED_VALUE = 105;
        int INSERT_INDEX = 2;
        int INSERTED_VALUE = 999;
        int REMOVE_INDEX = 0;

        ArrayList list = FileManager.LoadListFromFile(INPUT_PATH);

        List<string> results = [];

        results.Add("Початковий список: " + list.ToString());
        results.Add("Елементів: " + list.Count + ", розмір масиву: " + list.Capacity);

        for (int value = FIRST_ADDED_VALUE; value <= LAST_ADDED_VALUE; value++)
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

        if (list.Insert(INSERT_INDEX, INSERTED_VALUE))
        {
            results.Add("Вставка " + INSERTED_VALUE + " на індекс " + INSERT_INDEX + ": " + list.ToString());
        }
        else
        {
            results.Add("Помилка: неправильний індекс для вставки.");
        }

        if (list.RemoveByIndex(REMOVE_INDEX))
        {
            results.Add("Видалено елемент з індексом " + REMOVE_INDEX + ": " + list.ToString());
        }

        if (list.RemoveByValue(INSERTED_VALUE))
        {
            results.Add("Видалено значення " + INSERTED_VALUE + ": " + list.ToString());
        }

        list.Clear();
        results.Add("Після очищення: " + list.ToString() + ", елементів: " + list.Count);

        FileManager.SaveResultToFile(OUTPUT_PATH, results);
    }
}