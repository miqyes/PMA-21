using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string INPUT_PATH = "input.txt";
        string OUTPUT_PATH = "output.txt";

        List<Shape> shapes = FileManager.LoadShapesFromFile(INPUT_PATH);

        List<string> results = [];

        foreach (Shape shape in shapes)
        {
            results.Add(shape.ToString());
        }

        FileManager.SaveResultToFile(OUTPUT_PATH, results);
    }
}