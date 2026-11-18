using System.ComponentModel.DataAnnotations;
namespace StudentAPI.DTOs;

public class GroupDTO
{
    public string Curator { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^\p{L}{3}-[1-4][1-6]$")]
    public string Name { get; set; }= string.Empty;
}