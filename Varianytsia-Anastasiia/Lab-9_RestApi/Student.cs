namespace StudentRestApi;

// Дані одного студента
public class Student
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime BirthDate { get; set; }
    public List<int> Grades { get; set; } = [];

}
