using System;
using System.IO;

namespace project;

public class Program
{
    public const string DataFile = "data.txt";

    public static void Main(string[] args)
    {
        if (!File.Exists(DataFile))
        {
            Console.WriteLine($"File '{DataFile}' not found!");
            return;
        }

        string[] lines = File.ReadAllLines(DataFile);
        Console.WriteLine("Shapes from file:\n");

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            if (line.Trim() == "")
            {
                continue;
            }

            string[] parts = line.Split(' ');
            string shapeType = parts[0];

            Shape currentShape = null;

            if (shapeType == "Circle")
            {
                double radius = Convert.ToDouble(parts[1]);
                Color shapeColor = CreateColor(parts[2]);
                currentShape = new Circle(radius, shapeColor);
            }
            else if (shapeType == "Square")
            {
                double side = Convert.ToDouble(parts[1]);
                Color shapeColor = CreateColor(parts[2]);
                currentShape = new Square(side, shapeColor);
            }
            else if (shapeType == "Rectangle")
            {
                double width = Convert.ToDouble(parts[1]);
                Color height = null;
                double h = Convert.ToDouble(parts[2]);
                Color shapeColor = CreateColor(parts[3]);
                currentShape = new Rectangle(width, h, shapeColor);
            }
            else
            {
                currentShape = new NonExistent(new Red());
            }

            if (currentShape != null)
            {
                Console.WriteLine(currentShape.GetInfo());

                if (currentShape is IRun nonExistentShape)
                {
                    Console.WriteLine(nonExistentShape.GetAreaMessage());
                    Console.WriteLine(nonExistentShape.GetPerimeterMessage());
                }
                else
                {
                    if (currentShape is IArea areaShape)
                    {
                        Console.Write($"Area: {areaShape.GetArea():F2}, ");
                    }

                    if (currentShape is IPerimeter perimShape)
                    {
                        Console.Write($"Perimeter: {perimShape.GetPerimeter():F2}");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }

    public static Color CreateColor(string colorName)
    {
        if (colorName == "Red")
        {
            return new Red();
        }
        else if (colorName == "Blue")
        {
            return new Blue();
        }
        else if (colorName == "Green")
        {
            return new Green();
        }
        else
        {
            return new Red();
        }
    }
}