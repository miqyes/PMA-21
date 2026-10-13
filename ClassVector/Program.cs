using ClassVector;

class Program
{
    const string inputFile = "input.txt";
    const string outputFile = "output";

    static void Main()
    {
        try
        {
            Vector[] vectors = FileWorker.input(inputFile);
            Vector vecFirst = vectors[0];
            Vector vecSecond = vectors[1];

            string addStr = $"{vecFirst} + {vecSecond} = {vecFirst + vecSecond}";
            string subStr = $"{vecFirst} - {vecSecond} = {vecFirst - vecSecond}";
            string mulStr = $"{vecFirst} * {vecSecond} = {vecFirst * vecSecond}";
            string divStr = "";

            try
            {
                divStr = $"{vecFirst} / {vecSecond} = {vecFirst / vecSecond}";

            }
            catch (DivideByZeroException ex)
            {
                divStr = $"{vecFirst} / {vecSecond} = Error: Division by zero ({ex.Message})";
                Console.WriteLine($"Problem with division: {ex.Message}");
            }

            File.WriteAllLines(outputFile, new string[] { addStr, subStr, mulStr, divStr });
            Console.WriteLine("Done. Check the output file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Global error: {ex.Message}");
        }

    }
}