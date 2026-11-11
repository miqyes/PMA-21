using System;
using System.IO;
using System.Collections.Generic;

class FileManager
{
    const char SEPARATOR = ' ';

    public static List<Shape> LoadShapesFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        List<Shape> shapes = [];

        foreach (string line in lines)
        {
            string[] parts = line.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                continue;
            }

            Color color = CreateColor(parts[^1]);

            if (color == null)
            {
                Console.WriteLine("Помилка: невідомий колір у рядку \"" + line + "\"");
                continue;
            }

            if (parts[0] == "Circle" && parts.Length == 3)
            {
                shapes.Add(new Circle(double.Parse(parts[1]), color));
            }
            else if (parts[0] == "Rectangle" && parts.Length == 4)
            {
                shapes.Add(new Rectangle(double.Parse(parts[1]), double.Parse(parts[2]), color));
            }
            else if (parts[0] == "Square" && parts.Length == 3)
            {
                shapes.Add(new Square(double.Parse(parts[1]), color));
            }
            else
            {
                Console.WriteLine("Помилка: неправильний рядок \"" + line + "\"");
            }
        }

        return shapes;
    }

    private static Color CreateColor(string name)
    {
        if (name == "Red")
        {
            return new Red();
        }

        if (name == "Blue")
        {
            return new Blue();
        }

        if (name == "Green")
        {
            return new Green();
        }

        return null;
    }

    public static void SaveResultToFile(string filePath, List<string> results)
    {
        File.WriteAllLines(filePath, results);

        Console.WriteLine("Результат збережено у " + filePath);
    }
}