using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
namespace ServerA.Models;

public class PatientDocument
{
    [Required(ErrorMessage = "Id обов'язковий")]
    [StringLength(50, ErrorMessage = "Id не довше {1} символів")]
    public string Id { get; set; } = default!;
    [Required]
    public NameInfo Name { get; set; } = new();
    [Required]
    public BloodInfo Blood { get; set; } = new();

    [BsonDateTimeOptions(DateOnly = true)]
    [NotInFuture]
    public DateTime BirthDate { get; set; }

    public List<AllergyInfo> Allergies { get; set; } = new();
    public List<VisitInfo> Visits { get; set; } = new();
}