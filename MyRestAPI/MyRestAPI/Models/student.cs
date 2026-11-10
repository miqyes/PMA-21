namespace MyRestAPI.Models;

public class Date
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public Date()
    {
        Day = 1;
        Month = 1;
        Year = 2000;
    }
    
    public Date(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }
}

public class Student 
{
    public int Id { get; set; }
    
    public string? FirstName{ get; set; }
    public string? LastName{ get; set; }
    
    public string? Group { get; set; }
    public int GroupNumber { get; set; }

    public Date? BirthDate { get; set; }
}