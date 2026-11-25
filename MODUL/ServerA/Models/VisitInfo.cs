using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace ServerA.Models;

public class VisitInfo
{
    [BsonDateTimeOptions(DateOnly = true)]
    [NotInFuture]
    public DateTime Date { get; set; }

[Required(ErrorMessage = "Лікар обов'язковий")]
[StringLength(100, ErrorMessage = "Ім'я лікаря не довше {1} символів")]
public string Doctor { get; set; } = string.Empty;

[Required(ErrorMessage = "Діагноз обов'язковий")]
[StringLength(200, ErrorMessage = "Діагноз не довший {1} символів")]
public string Diagnosis { get; set; } = string.Empty;
}