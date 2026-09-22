namespace vectorClass;

public class FileWork
{
    public static Vector readFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException("Файла не знайдено");
        }
        string fileText = File.ReadAllText(fileName);
        string[] parts = fileText.Split("; ");
        double[] result = new double[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            result[i] = Convert.ToDouble(parts[i].Trim());
        }

        return new Vector(result);
    }

    public static void saveToFile(StreamWriter sw, string fileName, Vector vector)
    {
        sw.WriteLine(fileName);
        for (int i = 0; i < vector.Length; i++)
        {
            sw.Write($"{vector[i]} ");
        }
        sw.WriteLine(" ");
        
    }
}
