using System.ComponentModel.DataAnnotations;

namespace ServerA.Models;

public class AllergyInfo
{
    [Required(ErrorMessage = "Назва речовини обов'язкова")]
    [StringLength(100, ErrorMessage = "Назва речовини не довша {1} символів")]
    public string Substance { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^(Low|Medium|High)$", ErrorMessage = "Severity: Low, Medium або High")]
    public string Severity { get; set; } = "";
}
