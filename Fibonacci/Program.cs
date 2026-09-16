namespace fibonachi;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        List<int> beginList = new List<int>();
        if (File.Exists("list.txt"))
        {
            string listContent = File.ReadAllText("list.txt").Trim();
            string[] elements = listContent.Split(new char[] { ',', '\n', '\r', '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (elements.Length > 0) beginList.Add(int.Parse(elements[0]));
            if (elements.Length > 1) beginList.Add(int.Parse(elements[1]));
            else if (elements.Length == 1) beginList.Add(1);
        }
        if (beginList.Count == 0) beginList.AddRange(new[] { 0, 1 });

        int threshold = 100;
        if (File.Exists("limit.txt"))
        {
            string limitContent = File.ReadAllText("limit.txt").Trim();
            if (!string.IsNullOrEmpty(limitContent)) threshold = int.Parse(limitContent);
        }

        int stepsCount = 10;
        if (File.Exists("steps.txt"))
        {
            string countContent = File.ReadAllText("steps.txt").Trim();
            if (!string.IsNullOrEmpty(countContent)) stepsCount = int.Parse(countContent);
        }

        List<int> listForSteps = new List<int>(beginList);
        List<int> listForLimit = new List<int>(beginList);

        FibonachiTask.fibonachi(stepsCount, listForSteps);
        FibonachiTask.limit(threshold, listForLimit);

        string resultText = "Result by steps:\n" +
                            string.Join(", ", listForSteps) +
                            "\n\nResult by limit:\n" +
                            string.Join(", ", listForLimit);

        Console.WriteLine(resultText);

        File.WriteAllText("outut.txt", resultText);
    }
}