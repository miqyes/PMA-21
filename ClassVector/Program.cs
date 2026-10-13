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

            FileWorker.output(outputFile, vecFirst, vecSecond, vecFirst + vecSecond, '+');
            FileWorker.output(outputFile, vecFirst, vecSecond, vecFirst - vecSecond, '-');
            FileWorker.output(outputFile, vecFirst, vecSecond, vecFirst * vecSecond, '*');

            try
            {
                FileWorker.output(outputFile, vecFirst, vecSecond, vecFirst / vecSecond, '/');

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Problem with division: {ex.Message}");
            }

            Console.WriteLine("Done. Check the output file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Global error: {ex.Message}");
        }

    }
}
