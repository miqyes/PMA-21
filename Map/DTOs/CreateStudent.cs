namespace StudentAPI.DTOs;

public class CreateStudent
{
    public DataDTO Data { get; set; } = new();
    public GroupDTO Group { get; set; } = new();
}
