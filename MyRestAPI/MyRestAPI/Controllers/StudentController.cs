using Microsoft.AspNetCore.Mvc;
using MyRestAPI.Data;
using MyRestAPI.Models;

namespace MyRestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    // Додавання
    [HttpPost]
    public async Task<ActionResult<Student>> Post(Student student)
    {
        // Додаємо студента до контексту
        _context.Students.Add(student);
        // Зберігаємо зміни в SQL 
        await _context.SaveChangesAsync();
        // Повертаємо 201 Created
        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }
    
    // Видалення
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // Пошук студента
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            return NotFound();  // 404
        
        // Маркуємо об'єкт на видалення з контексту
        _context.Students.Remove(student);
        
        // Відправляємо запит DELETE у БД
        await _context.SaveChangesAsync();
        
        // Повертаємо 204 NoContent
        return NoContent();
    }

    // Отримати
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> Get(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            return NotFound();  // 404

        return student;
    }

    // Оновлення
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, Student studentUpdate)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            return NotFound(); // 404
        
        if (!string.IsNullOrEmpty(studentUpdate.FirstName)) // імя
            student.FirstName = studentUpdate.FirstName;
        if (!string.IsNullOrEmpty(studentUpdate.LastName))  // прізвище
            student.LastName = studentUpdate.LastName;
        if (!string.IsNullOrEmpty(studentUpdate.Group))     // група
            student.Group = studentUpdate.Group;
        if (studentUpdate.GroupNumber != 0)                 // номер групи
            student.GroupNumber = studentUpdate.GroupNumber;
        
        if (studentUpdate.BirthDate != null)                // дата народження
        {
            if (student.BirthDate == null)
                student.BirthDate = new Date();

            if (studentUpdate.BirthDate.Day != 0)
                student.BirthDate.Day = studentUpdate.BirthDate.Day;
            if (studentUpdate.BirthDate.Month != 0)
                student.BirthDate.Month = studentUpdate.BirthDate.Month;
            if (studentUpdate.BirthDate.Year != 0)
                student.BirthDate.Year = studentUpdate.BirthDate.Year;
        }
       
        await _context.SaveChangesAsync();

        return NoContent();
    }
}