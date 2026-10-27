using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using StudentRestApi;
using StudentRestApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Реєструємо PostgreSQL як базу даних для EF Core.
string connectionString = builder.Configuration.GetConnectionString("StudentsDatabase")!;
builder.Services.AddDbContext<StudentsDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

// Створюємо таблицю Students при першому запуску, якщо її ще немає.
using (var scope = app.Services.CreateScope())
{
    var database = scope.ServiceProvider.GetRequiredService<StudentsDbContext>();
    database.Database.EnsureCreated();
}

// Перетворює значення на XML-відповідь HTTP.
IResult XmlResponse<T>(T value, int statusCode = StatusCodes.Status200OK)
{
    XmlSerializer serializer = new XmlSerializer(typeof(T));
    StringBuilder xml = new StringBuilder();

    using (XmlWriter writer = XmlWriter.Create(xml, new XmlWriterSettings
    {
        Indent = true,
        OmitXmlDeclaration = true
    }))
    {
        serializer.Serialize(writer, value);
    }

    return Results.Content(xml.ToString(), "application/xml; charset=utf-8", Encoding.UTF8, statusCode);
}

IResult NotFoundXml()
{
    return Results.Content("<Error>Student not found</Error>", "application/xml; charset=utf-8", Encoding.UTF8, StatusCodes.Status404NotFound);
}

// POST: зберігає студента в базі і повертає його у XML.
app.MapPost("/students", async (Student student, StudentsDbContext database) =>
{
    student.Id = Guid.NewGuid();
    database.Students.Add(student);
    await database.SaveChangesAsync();

    return XmlResponse(student, StatusCodes.Status201Created);
});

// GET: повертає список усіх студентів із бази у XML.
app.MapGet("/students", async (StudentsDbContext database) =>
{
    List<Student> students = await database.Students.OrderBy(s => s.LastName).ToListAsync();
    return XmlResponse(students);
});

// GET: шукає студента за ID і повертає його у XML.
app.MapGet("/students/{id:guid}", async (Guid id, StudentsDbContext database) =>
{
    Student? student = await database.Students.FindAsync(id);
    return student == null ? NotFoundXml() : XmlResponse(student);
});

// PATCH: змінює лише передані поля, зберігає їх у базі та повертає студента у XML.
app.MapPatch("/students/{id:guid}", async (Guid id, StudentPatch patch, StudentsDbContext database) =>
{
    Student? student = await database.Students.FindAsync(id);
    if (student == null)
        return NotFoundXml();

    if (patch.FirstName != null) student.FirstName = patch.FirstName;
    if (patch.LastName != null) student.LastName = patch.LastName;
    if (patch.BirthDate.HasValue) student.BirthDate = patch.BirthDate.Value;
    if (patch.Grades != null) student.Grades = patch.Grades;

    await database.SaveChangesAsync();
    return XmlResponse(student);
});

// DELETE: видаляє студента з бази. Успішна відповідь має статус 204 і не має тіла.
app.MapDelete("/students/{id:guid}", async (Guid id, StudentsDbContext database) =>
{
    Student? student = await database.Students.FindAsync(id);
    if (student == null)
        return NotFoundXml();

    database.Students.Remove(student);
    await database.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
