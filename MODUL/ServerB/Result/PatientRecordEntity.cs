using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServerB.Result;
[Table("patient_records")]
public class PatientRecordEntity
{
    [Key, MaxLength(50)]
    public string Id { get; set; } = "";

    [MaxLength(200)]
    public string FullName { get; set; } = "";

    public int Age { get; set; }

    [MaxLength(5)]
    public string Blood { get; set; } = "";

   
    [Column(TypeName = "xml")]
    public string XmlPayload { get; set; } = "";

    public DateTime UpdatedAtUtc { get; set; }

    public List<AlertEntity> Alerts { get; set; } = new();
    public List<ConsultationEntity> Consultations { get; set; } = new();
}