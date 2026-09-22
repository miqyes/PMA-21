namespace fibonachi;

class Program
{
    const string list_file = "list.txt";
    const string limit_file = "limit.txt";
    const string steps_file = "steps.txt";
    const string output_file = "output.txt";

    static void Main()
    {
        List<int> beginList = new List<int>();
        if (File.Exists(list_file))
        {
            string listContent = File.ReadAllText(list_file).Trim();
            string[] elements = listContent.Split(new char[] { ',', '\n', '\r', '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (elements.Length > 0) beginList.Add(int.Parse(elements[0]));
            if (elements.Length > 1) beginList.Add(int.Parse(elements[1]));
            else if (elements.Length == 1) beginList.Add(1);
        }
        if (beginList.Count == 0) beginList.AddRange(new[] { 0, 1 });

        int threshold = 100;
        if (File.Exists(limit_file))
        {
            string limitContent = File.ReadAllText(limit_file).Trim();
            if (!string.IsNullOrEmpty(limitContent)) threshold = int.Parse(limitContent);
        }

        int stepsCount = 10;
        if (File.Exists(steps_file))
        {
            string countContent = File.ReadAllText(steps_file).Trim();
            if (!string.IsNullOrEmpty(countContent)) stepsCount = int.Parse(countContent);
        }

        List<int> listForSteps = new List<int>(beginList);
        List<int> listForLimit = new List<int>(beginList);

        FibonachiTask.fibonachi(stepsCount, listForSteps);
        FibonachiTask.limit(threshold, listForLimit);

        string resultText = "Result by steps:\n" + string.Join(", ", listForSteps) + "\n\nResult by limit:\n" + string.Join(", ", listForLimit);

        Console.WriteLine("Done. Check the output file.");

        File.WriteAllText(output_file, resultText);
    }
}