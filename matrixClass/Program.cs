namespace matrixClass;

class Program
{
    private const string firstFile = "firstMatrix.txt";
    private const string secondFile = "secondMatrix.txt";

    static void Main()
    {
        Matrix firstMatrix = FileWork.readFromFile(firstFile);
        Matrix secondMatrix = FileWork.readFromFile(secondFile);
        try
        {
            using (StreamWriter sw = new StreamWriter("result.txt"))
            {
                FileWork.saveToFile(sw, "Перша матриця ", firstMatrix);
                FileWork.saveToFile(sw, "Друга матриця ", secondMatrix);
                try
                {
                    Matrix add = firstMatrix + secondMatrix;
                    FileWork.saveToFile(sw, "Додавання матриць ", add);
                    Matrix sub = firstMatrix - secondMatrix;
                    FileWork.saveToFile(sw, "Віднімання матриць", sub);
                }
                catch (Exception ex)
                {
                    sw.WriteLine($"Помилка {ex.Message}");
                }

                try
                {
                    Matrix multiply = firstMatrix * secondMatrix;
                    FileWork.saveToFile(sw, "Множення матриць", multiply);
                }
                catch (Exception ex)
                {
                    sw.WriteLine($"Помилка {ex.Message}");
                }

                try
                {
                    Matrix division = firstMatrix * secondMatrix;
                    FileWork.saveToFile(sw, "Множення матриць", division);
                }
                catch (Exception ex)
                {
                    sw.WriteLine($"Помилка {ex.Message}");
                }

            }

            Console.WriteLine("Все записано у файл");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка {ex.Message}");
        }
    }
}
