class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        var processor = new VectorFileProcessor();
        processor.ProcessFile(inputFile, outputFile);

        Console.WriteLine("Processing completed. Check the output file.");
    }
}