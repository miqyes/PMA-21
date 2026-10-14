using System;
using System.Collections.Generic;
using System.IO;

public static class FileManager
{

    private static readonly char[]  SEPARATORS = [' ', ',', ';', '\t'];
    public static List<Student> ReadStudentsFromFile(string filePath)
    {
        List<Student> students = [];

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Помилка: файл {filePath} не знайдено!");
            return students;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            // Приклад: ['Іваненко', 'Іван', '2004-05-12', '75', '82', '80', '65']
            string[] parts = line.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 4)
            {
                string lastName = parts[0].Trim();
                string firstName = parts[1].Trim();
                DateTime birthDate = DateTime.Parse(parts[2].Trim());

                List<int> grades = [];
                for (int i = 3; i < parts.Length; i++)
                {
                    if (int.TryParse(parts[i], out int grade))
                    {
                        grades.Add(grade);
                    }
                }

                students.Add(new Student(firstName, lastName, birthDate, grades));
            }
        }

        return students;
        
    }

    public static void SaveResultsToFile(string filePath, List<string> lines)
    {
        File.WriteAllLines(filePath, lines);
    }
}
