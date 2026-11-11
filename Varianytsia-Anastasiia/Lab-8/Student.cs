using System;
using System.Collections.Generic;

public struct Student(string firstName, string lastName, DateTime birthDate, List<int> grades)
{
    public string FirstName = firstName;
    public string LastName = lastName;
    public DateTime BirthDate = birthDate;
    public List<int> Grades = grades ?? [];


    public readonly bool HasFailedSession()
    {
        foreach (int grade in Grades)
        {
            if (grade < 51) 
            {
                return true;
            }
        }
        return false;
    }

    public override readonly string ToString()
    {
        string gradesStr = string.Join(", ", Grades);
        return $"{LastName} {FirstName} | Дата нар.: {BirthDate:dd.MM.yyyy} | Оцінки: [{gradesStr}]";
    }
}