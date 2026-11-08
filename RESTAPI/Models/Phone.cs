namespace TRY.Models;

public class Phone
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Battery { get; set; }
    public int Price { get; set; }
    public bool Iphone { get; set; }
    public string? AppleID { get; set; }
}