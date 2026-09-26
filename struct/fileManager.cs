using System;
using System.Collections.Generic;
using System.Text;

public class FileManager
{
    private string _filePath;

    public FileManager(string filePath)
    {
        _filePath = filePath;
    }

    public List<Student> ReadAll()
    {
        List<Student> students = new List<Student>();

        if (!File.Exists(_filePath))
            return students; 

        string[] lines = File.ReadAllLines(_filePath);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(';');

            string firstName = parts[0].Trim();
            string lastName = parts[1].Trim();

            string[] dateParts = parts[2].Split('.');
            int day = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int year = int.Parse(dateParts[2]);
            Date birthDate = new Date(day, month, year);
            
            Dictionary<string, int> grades = new Dictionary<string, int>();
            string[] subjects = parts[3].Split(",");

            foreach(string subj in subjects)
            {
                string[] subjData = subj.Split(":");
                string subjectName = subjData[0].Trim();
                int score = int.Parse(subjData[1].Trim());

                grades.Add(subjectName, score);
            }

            students.Add(new Student(firstName, lastName, birthDate, grades));
        }
        return students;
    }
}

public class StudentReport
{
    public static void PrintFailedStudents(List<Student> students, int passingScore = 51)
    {
        Console.WriteLine($"\n--- Студенти, які не склали сесію (оцінка < {passingScore}) ---");

        bool foundAny = false;

        foreach (var student in students)
        {
            List<string> failedSubjects = new List<string>();

            foreach (var item in student.Grades)
            {
                if (item.Value < passingScore)
                    failedSubjects.Add($"{item.Key}: {item.Value}");

            }

            if (failedSubjects.Count > 0)
            {
                foundAny = true;
                string debtInfo = string.Join(", ", failedSubjects);

                Console.WriteLine($"{student.LastName,-12} | {student.FirstName,-14} | {student.BirthDate,-12} | {debtInfo}");
            }
        }

        if (!foundAny)
            Console.WriteLine("Усі студенти успішно склали сесію!");
    }
}