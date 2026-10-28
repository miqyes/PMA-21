using System.Runtime.CompilerServices;

namespace vector
{
    class Program
    {
        static void Main()
        { 
            const string RESULT_FILE = "result.txt";
            List<float> firstVector = new List<float>();
            List<float> secondVector = new List<float>();
            
            
            
        string vectorNumbersFirst = File.ReadAllText("firstVector.txt");
        List<string> vectorNumbersFirstList = vectorNumbersFirst.Split(',').ToList();
        try
        {
            
            firstVector = vectorNumbersFirstList.Select(float.Parse).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
        
        string vectorNumbersSecond = File.ReadAllText("secondVector.txt");
        List<string> vectorNumbersSecondList = vectorNumbersSecond.Split(',').ToList();
        try
        {
            secondVector=vectorNumbersSecondList.Select(float.Parse).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        Vector first = new Vector(firstVector);
        Vector second = new Vector(secondVector);
        Vector thirdVector;
        try
        { 
            thirdVector = Vector.productVector(first, second);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        string  resultVector = Vector.GetStringFromVector(thirdVector);
        File.WriteAllText(RESULT_FILE, "Product Vector: (" + resultVector + ")\n");

        try
        {
            thirdVector = first.sumVector( second);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        resultVector = Vector.GetStringFromVector(thirdVector);
        File.AppendAllText(RESULT_FILE, "Sum Vector:("+resultVector+")\n");

        try
        {
            thirdVector = Vector.differenceVector(first, second);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        resultVector = Vector.GetStringFromVector(thirdVector);
        File.AppendAllText(RESULT_FILE, "Difference Vector:("+resultVector+")\n");

        try
        {
            thirdVector = Vector.divisionVector(first, second);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        resultVector = Vector.GetStringFromVector(thirdVector);
        File.AppendAllText(RESULT_FILE, "Division Vector:("+resultVector+")\n");


        

    }
        
}
}