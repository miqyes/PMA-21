static List<int> Fibonacci(List<int> list, int count, int index = 2)
{
    if (index >= count) return list;
    list.Add(list[index - 1] + list[index - 2]);
    return Fibonacci(list, count, index+1);
}
List<int> list1 = new List<int> { 7,12 };
Console.Write("Ряд фiбоначчi: "+ string.Join(',', Fibonacci(list1,5)));
string input = "input.txt";
string steps = "steps.txt";
try
{
    if (File.Exists(input) && File.Exists(steps))
    {

        string inputText = File.ReadAllText(input);
        string[] text1 = inputText.Split(',');
        int a = int.Parse(text1[0].Trim());
        int b = Convert.ToInt32(text1[1].Trim());
        string[] stepText = File.ReadAllLines(steps);
        int text2 = Convert.ToInt32(stepText[0].Trim());
        if (text2 < 0)
        {
            Console.WriteLine("\nЧисло у файлi steps не повинно бути вiд'ємним");
            return;
        }
        List<int> list2 = new List<int> { a, b };
        Fibonacci(list2, text2);
        string result = string.Join(',', list2);
        File.WriteAllText("result.txt", result);
        Console.WriteLine("\nВсе записано у файл");
    }
    else
    {
        Console.WriteLine("Файiв не знайдено...");
    }
}
catch (FormatException)
{
    Console.WriteLine("Неправильний тип даних");
}