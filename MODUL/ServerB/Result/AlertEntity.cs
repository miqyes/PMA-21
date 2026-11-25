using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServerB.Result;

[Table("critical_alerts")]
public class AlertEntity
{
    public int Id { get; set; }
    public string PatientRecordId { get; set; } = "";
    public string Text { get; set; } = "";
}