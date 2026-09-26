using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public struct Date
{ 
    public int Day;
    public int Month;
    public int Year;

    public Date(int day, int month, int year)
    { 
        Day = day;
        Month = month;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Day:D2}.{Month:D2}.{Year}";
    }
}

public struct Student
{
    public string FirstName;
    public string LastName;
    public Date BirthDate;
    public Dictionary<string, int> Grades;

    public Student(string firstName, string lastName, Date birthdDate, Dictionary<string, int> grades)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthdDate;
        Grades = grades;
    }

    public override string ToString()
    {
        if (Grades == null || Grades.Count == 0)
            return $"{LastName} {FirstName} ({BirthDate}) | NO GRADES";

        string gradesStr = "";

        foreach (var item in Grades)
            gradesStr += $"{item.Key}: {item.Value}, ";

        gradesStr = gradesStr.TrimEnd(' ', ',') ;

        return $"{LastName} {FirstName} ({BirthDate}) | {gradesStr}";
    }
}

