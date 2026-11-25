namespace ServerA.Models;

public class PatientPatch
{
    public NameInfo? Name { get; set; }              
    public BloodInfo? Blood { get; set; }

    [NotInFuture]                                 
    public DateTime? BirthDate { get; set; }

    public List<AllergyInfo>? Allergies { get; set; }
    public List<VisitInfo>? Visits { get; set; }
}