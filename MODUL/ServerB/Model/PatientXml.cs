using System.Xml.Serialization;

namespace ServerB.Model;

[XmlRoot("PatientRecord")]
public class PatientXml
{
    [XmlAttribute("Id")]
    public string Id { get; set; } = string.Empty;

    public string FullName { get; set; }= string.Empty;
    public int Age { get; set; }
    public string Blood { get; set; } = string.Empty;

    [XmlArray("CriticalAlerts")]
    [XmlArrayItem("Alert")]
    public List<string> CriticalAlerts { get; set; } = new();

    [XmlArray("Consultations")]
    [XmlArrayItem("Consultation")]
    public List<ConsultationXml> Consultations { get; set; } = new();
}

