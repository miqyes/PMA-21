using Microsoft.EntityFrameworkCore;
using ServerB.DTO;
using ServerB;
using ServerB.Mapping;
using ServerB.Result;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ClinicDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI(); 
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ClinicDbContext>();
    await db.Database.EnsureCreatedAsync();
}

app.MapPost("/patients", async (PatientIncoming incoming, ClinicDbContext db) =>
{
    var today = DateOnly.FromDateTime(DateTime.UtcNow);

    var xmlModel = PatientMapper.ToXmlModel(incoming, today);
    var xml = PatientMapper.Serialize(xmlModel);


    var existing = await db.Patients.FindAsync(incoming.Id);
    if (existing is not null) db.Patients.Remove(existing);

    db.Patients.Add(new PatientRecordEntity
    {
        Id = xmlModel.Id,
        FullName = xmlModel.FullName,
        Age = xmlModel.Age,
        Blood = xmlModel.Blood,
        XmlPayload = xml,
        UpdatedAtUtc = DateTime.UtcNow,
        Alerts = xmlModel.CriticalAlerts
            .Select(t => new AlertEntity { Text = t }).ToList(),
        Consultations = xmlModel.Consultations
            .Select(c => new ConsultationEntity
            {
                Date = DateOnly.Parse(c.Date),
                Physician = c.Physician,
                Issue = c.Issue
            }).ToList()
    });

    await db.SaveChangesAsync();
    return Results.Content(xml, "application/xml");
});

app.MapGet("/patients/{id}/xml", async (string id, ClinicDbContext db) =>
{
    var xml = await db.Patients
        .Where(p => p.Id == id)
        .Select(p => p.XmlPayload)
        .FirstOrDefaultAsync();

    return xml is null ? Results.NotFound() : Results.Content(xml, "application/xml/{id}");
});

app.MapGet("/patients/xml", async (ClinicDbContext db) =>
{
    var items = await db.Patients
        .OrderBy(p => p.Id)
        .Select(p => p.XmlPayload)
        .ToListAsync();

    return Results.Content(string.Concat(items), "application/xml; charset=utf-8");
});
app.MapDelete("/patients/{id}", async (string id, ClinicDbContext db) =>
{
    var existing = await db.Patients.FindAsync(id);
    if (existing is null) return Results.NotFound();

    db.Patients.Remove(existing);                   
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.Run();