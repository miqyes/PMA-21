using System;
using System.Collections.Generic;
using System.IO;

namespace StructStudentApp
{
    public struct SubjectGrade
    {
        public string Subject;
        public int Grade;

        public SubjectGrade(string subject, int grade)
        {
            Subject = subject;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{Subject}: {Grade}";
        }
    }

    public struct DateOfBirth
    {
        public int Day;
        public int Month;
        public int Year;

        public DateOfBirth(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }

    public struct Student
    {
        public string FirstName;
        public string LastName;
        public DateOfBirth Date;
        public List<SubjectGrade> Grades; // Простий список замість Dictionary

        public Student(string firstName, string lastName, DateOfBirth dateOfBirth, List<SubjectGrade> grades)
        {
            FirstName = firstName;
            LastName = lastName;
            Date = dateOfBirth;
            Grades = grades;
        }

        public override string ToString()
        {
            if (Grades == null || Grades.Count == 0)
            {
                return $"Студент: {FirstName} {LastName}, Д/Н: {Date}, Оцінки: немає";
            }

            string gradesString = string.Join(", ", Grades);
            return $"Студент: {FirstName} {LastName}, Д/Н: {Date}, Оцінки: {gradesString}";
        }
       
        public static void PrintFailedStudents(List<Student> students)
        {
            Console.WriteLine("--- Студенти, які не склали сесію ---");

            foreach (Student s in students)
            {
                bool hasDebt = false;

                if (s.Grades != null)
                {
                    foreach (SubjectGrade item in s.Grades)
                    {
                        if (item.Grade < 51)
                        {
                            hasDebt = true;
                            break;
                        }
                    }
                }

                if (hasDebt)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
    