namespace StudentRestApi;

// Поля, які можна змінити через PATCH. Nullable означає, що поле можна не надсилати.
public class StudentPatch
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public List<int>? Grades { get; set; }
}
