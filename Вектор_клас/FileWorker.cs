using System;
using System.IO;

namespace Вектор_клас
{
    public class FileWorker
    {
        public static Vector InputVector(string name, int size)
        {
            Console.WriteLine($"\nEnter vector{name}:");
            Vector ResultVector = new Vector(size);

            for (int Index = 0; Index < size; Index++)
            {
                Console.Write($"{name}[{Index + 1}] = ");
                ResultVector.Data[Index] = double.Parse(Console.ReadLine());
            }
            return ResultVector;
        }
        public static Vector ReadVector(string FilePath, int VectorSize)
        {
            string FileContent = File.ReadAllText(FilePath).Trim();
            FileContent = FileContent.Replace("(", "").Replace(")", "");

            string[] Elements = FileContent.Split(',');

            Vector LoadedVector = new Vector(VectorSize);
            for (int Index = 0; Index < VectorSize; Index++)
            {
                LoadedVector.Data[Index] = double.Parse(Elements[Index]);
            }
            return LoadedVector;
        }
        public static void WriteResult(string FilePath, string Content)
        {
            File.WriteAllText(FilePath, Content);
        }
    }
}
