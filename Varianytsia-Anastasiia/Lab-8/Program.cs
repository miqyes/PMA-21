using System;
using System.Collections.Generic;

class Program
{
    static void SaveFailedStudents(string outputPath, List<Student> students)
    {
        List<string> outputLines = ["=== Студенти, які не склали сесію ==="];

        bool found = false;
        foreach (Student student in students)
        {
            if (student.HasFailedSession())
            {
                outputLines.Add(student.ToString());
                found = true;
            }
        }

        if (!found)
        {
            outputLines.Add("Усі студенти успішно склали сесію!");
        }

        FileManager.SaveResultsToFile(outputPath, outputLines);
    }

    static void Main(string[] args)
    {
        string inputPath = "input.txt";
        string outputPath = "output.txt";

        List<Student> students = FileManager.ReadStudentsFromFile(inputPath);

        SaveFailedStudents(outputPath, students);

        Console.WriteLine("Результат збережено у output.txt");
    }
}
