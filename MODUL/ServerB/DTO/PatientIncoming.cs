namespace ServerB.DTO;

public record PatientIncoming(
    string Id,
    NameDto Name,
    BloodDto Blood,
    DateTime BirthDate,
    List<AllergyDto> Allergies,
    List<VisitDto> Visits);

public record NameDto(string First, string Last);
public record BloodDto(string Group, string Rh);
public record AllergyDto(string Substance, string Severity);
public record VisitDto(DateTime Date, string Doctor, string Diagnosis);