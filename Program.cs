namespace vectorClass;

class Program
{
    const string InputFile = "vector.txt";
    const string ResultFile = "result.txt";
    const string Separator = " ";
    
    static void Main()
    {
        try
        {
            Vector[] vectors = FileWorker.readFromFile(InputFile, Separator);
            Vector vectorFirst = vectors[0];
            Vector vectorSecond = vectors[1];
            Vector add = vectorFirst + vectorSecond;
            Vector subtract = vectorFirst - vectorSecond;
            Vector multiply = vectorFirst * vectorSecond;
            bool divisionZero = Vector.divisionByZero(vectorSecond);
            Vector? division;
            if (divisionZero)
            {
                division = null;
            }
            else
            {
                division = vectorFirst / vectorSecond;
            }

            FileWorker.writeToFile(ResultFile, vectorFirst, vectorSecond, add, subtract, multiply, division);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Check file with vectors");
        }
        
    }
}