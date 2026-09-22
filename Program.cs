namespace vectorClass;

class Program
{
     const string firstVectorText = "firstVector.txt";
     const string secondVectorText = "secondFile.txt";
    static void Main()
    {
        try
        {
            Vector firstVector = FileWork.readFromFile(firstVectorText);
            Vector secondVector = FileWork.readFromFile(secondVectorText);
            using (StreamWriter sw = new StreamWriter("result.txt"))
            {
                FileWork.saveToFile(sw, "Перший вектор", firstVector);
                FileWork.saveToFile(sw, "Другий вектор", secondVector);
                try
                {
                    Vector add = firstVector + secondVector;
                    Vector sub = firstVector - secondVector;
                    Vector mulyiply = firstVector * secondVector;
                    FileWork.saveToFile(sw, "Додавання", add);
                    FileWork.saveToFile(sw, "Віднімання", sub);
                    FileWork.saveToFile(sw, "Множення", mulyiply);
                }
                catch (Exception ex)
                {
                    sw.WriteLine($"Помика {ex.Message}");
                }

                try
                {
                    Vector divizion = firstVector / secondVector;
                    FileWork.saveToFile(sw, "Ділення", divizion);
                }
                catch (Exception ex)
                {
                    sw.WriteLine($"Помилка: {ex.Message}");
                }
            }
        }
        
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Помилка {ex.Message} ");
        }

        Console.WriteLine("Записано у файл");
    }
}