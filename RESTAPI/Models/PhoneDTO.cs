using System.Text.Json.Serialization;

namespace TRY.Models;

public class PhoneDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Battery { get; set; }
    public int Price { get; set; }
    public bool Iphone { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AppleID { get; set; }

    public PhoneDTO()
    {
    }

    public PhoneDTO(Phone item) =>
        (Id, Name, Battery, Price, Iphone) = (item.Id, item.Name, item.Battery, item.Price, item.Iphone);
}