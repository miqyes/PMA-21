class Program
{
    static double[] addVector(double[] firstVector, double[] secondVector)
    {
        double[] result = new double[firstVector.Length];
        for (int i = 0; i < firstVector.Length; i++)
        {
            result[i] = firstVector[i] + secondVector[i];
        }
        return result;
    }
    static double[] subtractVector(double[] firstVector, double[] secondVector)
    {
        double[] result = new double [firstVector.Length];
        for (int i = 0; i < firstVector.Length; i++)
        {
            result[i] = firstVector[i] - secondVector[i];
        }
        return result;
    }
    static double[] multiplyVector(double[] firstVector, double[] secondVector)
    {
        double[] result = new double[firstVector.Length];
        for (int i = 0; i < firstVector.Length; i++)
        {
            result[i] = firstVector[i] + secondVector[i];
        }
        return result;
    }
    static double[] divisionVector(double[] firstVector, double[] secondVector)
    {
        double[] result = new double[firstVector.Length];
        for (int i = 0; i < firstVector.Length; i++)
        {
            if (secondVector[i] == 0)
            {
                Console.WriteLine("Дiлення на нуль неможливе ");
                return null;
            }
            result[i] = firstVector[i] / secondVector[i];
        }
        return result;
    }
    static double[] readFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Файла не існує ");
            return null;
        }
        string fileText = File.ReadAllText(fileName);
        string[] parts = fileText.Split(';');
        double[] number = new double[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            number[i] = Convert.ToDouble(parts[i]);
        }

        return number;
    }
    static void Main()
    {
        string firstVectorFile = "firstVector.txt";
        string secondVectorFile = "secondVector.txt";
        double[] firstVector = readFromFile(firstVectorFile);
        double[] secondVector =readFromFile(secondVectorFile);
        using (StreamWriter sw = new StreamWriter("result.txt"))
        {
                string vectorOne = string.Join("; ", firstVector);
                string vectorTwo= string.Join("; ", secondVector);
                string add = string.Join("; ", addVector(firstVector, secondVector));
                string subtract = string.Join(";", subtractVector(firstVector, secondVector));
                string multiply = string.Join(";", multiplyVector(firstVector, secondVector));
                string division = string.Join(";", divisionVector(firstVector, secondVector));
                sw.WriteLine("(" + vectorOne + ") + (" + vectorTwo + ") =  (" + add+")");
                sw.WriteLine("(" + vectorOne + ") - (" + vectorTwo + ") =  (" + subtract+")");
                sw.WriteLine("(" + vectorOne + ") * (" + vectorTwo + ") =  (" + multiply+")");
                sw.WriteLine("(" + vectorOne + ") / (" + vectorTwo + ") =  (" + division+")");
        }
        Console.WriteLine(" Записано у файл");
    }
}
