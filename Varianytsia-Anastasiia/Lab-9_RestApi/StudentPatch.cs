namespace StudentRestApi;

public class StudentPatch
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public List<int>? Grades { get; set; }
}
