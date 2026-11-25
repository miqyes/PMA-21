using System.ComponentModel.DataAnnotations;

namespace ServerA.Models;

public class NameInfo
{

    [Required(ErrorMessage = "Ім'я обов'язкове")]
    [StringLength(100, ErrorMessage = "Ім'я не довше {1} символів")]
    public string First { get; set; } = string.Empty;

    [Required(ErrorMessage = "Прізвище обов'язкове")]
    [StringLength(100, ErrorMessage = "Прізвище не довше {1} символів")]
    public string Last { get; set; } = string.Empty;
}