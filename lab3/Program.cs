namespace classVector;
class Program
{
    const string firstVectorFile = "firstVectorInput.txt";
    const string secondVectorFile = "secondVectorInput.txt";
    static Vector ReadVector(string filePath)
    {
        string[] parts = File.ReadAllText(filePath)
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        double[] numbers = new double[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            numbers[i] = double.Parse(parts[i]);
        }

        return new Vector(numbers);
    }
    static void Main()
    {
        try
        {
            Vector firstVector = ReadVector(firstVectorFile);
            Vector secondVector = ReadVector(secondVectorFile);


            string addResult = $"{firstVector} + {secondVector} = {firstVector.add(secondVector)}";
            string subtractResult = $"{firstVector} - {secondVector} = {firstVector.subtract(secondVector)}";
            string multiplyResult = $"{firstVector} * {secondVector} = {firstVector.multiply(secondVector)}";
            string divisionResult;

            try
            {
                divisionResult = $"{firstVector} / {secondVector} = {firstVector.divide(secondVector)}";
            }
            catch (DivideByZeroException exception)
            {
                divisionResult = $"{firstVector} / {secondVector} = Error: {exception.Message}";
            }

            string[] resultLines = { addResult, subtractResult, multiplyResult, divisionResult };
            File.WriteAllLines("result.txt", resultLines);

            Console.WriteLine("Result is successfully saved in file 'result.txt'");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"Data entry error: {exception.Message}");
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine($"Mistake in file: {exception.Message}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error: {exception.Message}");
        }
    }
}
