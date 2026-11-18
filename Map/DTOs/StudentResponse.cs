
namespace StudentAPI.DTOs;

public class StudentResponse
{
    public string? Id { get; set; }
    public DataDTO Data { get; set; } = new();
    public GroupDTO Group { get; set; } = new();

    public int Course { get; set; }

}