using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Cosmetic
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Brand is required")]
    public string Brand { get; set; } = "";

    [Range(0.01, 100000, ErrorMessage = "Price must be between 0.01 and 100000")]
    public decimal Price { get; set; }
}

public class CosmeticPatch
{
    public string? Name { get; set; }
    public string? Brand { get; set; }
    public decimal? Price { get; set; }
}
