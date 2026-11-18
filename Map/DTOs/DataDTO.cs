using System.ComponentModel.DataAnnotations;
namespace StudentAPI.DTOs;

public class DataDTO
{
    [Required] 
    public string Name { get; set; } = string.Empty;
    [Range(1,100)]
    public int Age { get; set; }
}