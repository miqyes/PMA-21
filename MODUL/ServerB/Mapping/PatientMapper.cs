using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ServerB.DTO;
using ServerB.Model;
namespace ServerB.Mapping;

public static class PatientMapper
{
    public static PatientXml ToXmlModel(PatientIncoming src, DateOnly today)
    {
        return new PatientXml
        {
            Id = src.Id,


            FullName = $"{src.Name.First} {src.Name.Last}".Trim(),


            Age = CalculateAge(DateOnly.FromDateTime(src.BirthDate), today),


            Blood = $"{src.Blood.Group}{src.Blood.Rh}",

         
            CriticalAlerts = src.Allergies
                .Select(a => $"{a.Substance} ({a.Severity})")
                .ToList(),
            
            Consultations = src.Visits
                .OrderBy(v => v.Date)
                .Select(v => new ConsultationXml
                {
                    Date = v.Date.ToString("yyyy-MM-dd"),
                    Physician = v.Doctor,
                    Issue = v.Diagnosis
                })
                .ToList()
        };
    }

    public static int CalculateAge(DateOnly birth, DateOnly today)
    {
        var age = today.Year - birth.Year;
        if (birth > today.AddYears(-age)) age--; 
        return age;
    }

    public static string Serialize(PatientXml model)
    {
        var serializer = new XmlSerializer(typeof(PatientXml));
        var ns = new XmlSerializerNamespaces();
        ns.Add("", "");

        var settings = new XmlWriterSettings
        {
            Indent = true,
            Encoding = new UTF8Encoding(false),
            OmitXmlDeclaration = true
        };

        using var sw = new StringWriter();
        using (var xw = XmlWriter.Create(sw, settings))
            serializer.Serialize(xw, model, ns);
        return sw.ToString();
    }
}