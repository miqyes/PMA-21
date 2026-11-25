using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServerB.Result;

[Table("consultations")]
public class ConsultationEntity
{
    public int Id { get; set; }
    public string PatientRecordId { get; set; } = "";
    public DateOnly Date { get; set; }
    public string Physician { get; set; } = "";
    public string Issue { get; set; } = "";
}