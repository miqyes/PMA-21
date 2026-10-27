namespace StudentRestApi;

// Дані одного студента, які API читає з JSON і повертає у відповідях.
public class Student
{
    // Унікальний номер: сервер призначає його під час POST.
    public Guid Id { get; set; }

    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime BirthDate { get; set; }
    public List<int> Grades { get; set; } = [];

}
