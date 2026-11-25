using System.ComponentModel.DataAnnotations;

namespace ServerA.Models;

public class BloodInfo
{
    [Required]
    [RegularExpression("^(A|B|AB|O)$", ErrorMessage = "Група крові: A, B, AB або O")]
    public string Group { get; set; } = "";

    [Required]
    [RegularExpression(@"^[+-]$", ErrorMessage = "Резус: + або -")]
    public string Rh { get; set; } = "";
}