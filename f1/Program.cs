using System;

namespace fibonachi;

class Program
{
    static int count()
    {
       

        string text = File.ReadAllText("count.txt").Trim();
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine(
                "Файл порожній. Беруться значення за замовчуванням."
            );
            return 10;
        }

        return int.Parse(text);
    }


    static List<int> fillList()
    {
        List<int> begin = new List<int>();
     

        string text = File.ReadAllText("list.txt").Trim();
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine(
                "Файл порожній. Беруться значення за замовчуванням."
            );
            begin.Add(0);
            begin.Add(1);
            return begin;
        }

        string[] parts = text.Split(new char[] { ',', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        begin.Add(int.Parse(parts[0]));
        if (parts.Length >= 1)
            begin.Add(int.Parse(parts[1]));
        else
            begin.Add(1);
        return begin;
    }

    static int getLimit()
    {
  

        string text = File.ReadAllText("limit.txt").Trim();
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine(
                "Файл порожній. Беруться значення за замовчуванням."
            );
            return 100;
        }

        return int.Parse(text);
    }

    static void writeResult(List<int> numbers)
    {
        File.WriteAllText("result.txt", string.Join(',', numbers));
    }

    static void end(List<int> res)
    {

        writeResult( res);
        Console.WriteLine("Готово.Результат у файлі. \n Чи хочете побачити результат у консолі?\n 1-так\n 2-ні ");
        if (Int32.Parse(Console.ReadLine()) == 1)
            Console.Write(string.Join(',', res));
        else
            Console.Write("Гарного дня!");
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        

        int countOfEl = getLimit();
        Console.Write("Назва файлу,з якого береться початок:");
        List<int> beginList = fillList();
        FibonachiTask.limit(countOfEl, beginList);
        end(beginList);
    }
    
}