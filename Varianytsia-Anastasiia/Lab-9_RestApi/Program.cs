using Microsoft.EntityFrameworkCore;
using StudentRestApi;
using StudentRestApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Реєструємо PostgreSQL як базу даних для Entity Framework Core.
string connectionString = builder.Configuration.GetConnectionString("StudentsDatabase")!;
builder.Services.AddDbContext<StudentsDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var database = scope.ServiceProvider.GetRequiredService<StudentsDbContext>();
    database.Database.EnsureCreated();
}

app.MapPost("/students", async (Student student, StudentsDbContext database) =>
{
    student.Id = Guid.NewGuid();
    database.Students.Add(student);
    await database.SaveChangesAsync();

    return Results.Created($"/students/{student.Id}", student);
});

// GET: усіх студентів із бд.
app.MapGet("/students", async (StudentsDbContext database) =>
{
    List<Student> students = await database.Students.OrderBy(s => s.LastName).ToListAsync();
    return Results.Ok(students);
});

// GET: за ID
app.MapGet("/students/{id:guid}", async (Guid id, StudentsDbContext database) =>
{
    Student? student = await database.Students.FindAsync(id);
    return student == null ? Results.NotFound() : Results.Ok(student);
});

// PATCH: змінює лише передані поля.
app.MapPatch("/students/{id:guid}", async (Guid id, StudentPatch patch, StudentsDbContext database) =>
{
    Student? student = await database.Students.FindAsync(id);
    if (student == null)
        return Results.NotFound();

    if (patch.FirstName != null) student.FirstName = patch.FirstName;
    if (patch.LastName != null) student.LastName = patch.LastName;
    if (patch.BirthDate.HasValue) student.BirthDate = patch.BirthDate.Value;
    if (patch.Grades != null) student.Grades = patch.Grades;

    await database.SaveChangesAsync();
    return Results.Ok(student);
});

app.MapDelete("/students/{id:guid}", async (Guid id, StudentsDbContext database) =>
{
    Student? student = await database.Students.FindAsync(id);
    if (student == null)
        return Results.NotFound();

    database.Students.Remove(student);
    await database.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
