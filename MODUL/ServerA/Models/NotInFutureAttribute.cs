using System.ComponentModel.DataAnnotations;

namespace ServerA.Models;

public class NotInFutureAttribute : ValidationAttribute
{
    public NotInFutureAttribute() => ErrorMessage = "Дата має бути від 1900 року і не в майбутньому";

    public override bool IsValid(object? value) =>
        value is not DateTime d || (d.Year >= 1900 && d.Date <= DateTime.UtcNow.Date);
}