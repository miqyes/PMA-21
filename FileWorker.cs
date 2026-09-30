using System.IO;

namespace Фібоначчі
{
    public class FileWorker
    {
        public static int ReadNumber(string filename)
        {
            string text = File.ReadAllText(filename).Trim();
            return int.Parse(text);
        }
        public static int[] ReadNumbers(string filename)
        {
            string text = File.ReadAllText(filename).Trim();
            string[] parts = text.Split(',');

            int[] numbers = new int[2];
            numbers[0] = int.Parse(parts[0].Trim());
            numbers[1] = int.Parse(parts[1].Trim());
            return numbers;
        }
        public static void WriteResult(string fileName, string text)
        {
            File.WriteAllText(fileName, text);
        }
    }
}
