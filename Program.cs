using System;
using System.IO;
using System.Linq;

namespace vector
{
    class Program
    {
        static double[] readFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Файла не існує");
            }
            string fileText = File.ReadAllText(fileName);
            string[] parts = fileText.Split(';');
            double[] number = new double[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                number[i] = Convert.ToDouble(parts[i].Trim());
            }
            return number;
        }

        const string firstVectorFile = "firstVector.txt";
        const string secondVectorFile = "secondVector.txt";

        static void Main()
        {
            try
            {
                double[] firstVector = readFromFile(firstVectorFile);
                double[] secondVector = readFromFile(secondVectorFile);
                using (StreamWriter sw = new StreamWriter("result.txt"))
                {
                    string vectorOne = string.Join("; ", firstVector);
                    string vectorTwo = string.Join("; ", secondVector);
                    string add = string.Join("; ", VectorCalculate.addVector(firstVector, secondVector));
                    string subtract = string.Join(";", VectorCalculate.subtractVector(firstVector, secondVector));
                    string multiply = string.Join(";", VectorCalculate.multiplyVector(firstVector, secondVector));
                    sw.WriteLine("(" + vectorOne + ") + (" + vectorTwo + ") =  (" + add + ")");
                    sw.WriteLine("(" + vectorOne + ") - (" + vectorTwo + ") =  (" + subtract + ")");
                    sw.WriteLine("(" + vectorOne + ") * (" + vectorTwo + ") =  (" + multiply + ")");
                    try
                    {
                        string division = string.Join(";", VectorCalculate.divisionVector(firstVector, secondVector));
                        sw.WriteLine("(" + vectorOne + ") / (" + vectorTwo + ") =  (" + division + ")");
                    }
                    catch(DivideByZeroException exception)
                    {
                        sw.WriteLine($" Помилка : {exception.Message}");
                    }
                    Console.WriteLine(" Записано у файл");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine($"Помилка введення даних: {exception.Message}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Помилка у файлі: {ex.Message}");
            }
        }
    }
}
