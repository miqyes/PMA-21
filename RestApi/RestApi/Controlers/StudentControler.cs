using Microsoft.AspNetCore.Mvc;
using RestApi.Data;
using RestApi.Models;

namespace RestApi.Controlers;

[ApiController]
[Route("api/[controller]")]

public class StudentControler : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentControler(AppDbContext context)
    {
        _context= context;
    }

    [HttpPost]
    public async Task<ActionResult<Student>> Post(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        _context.Students.Remove(student);
        
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> Get(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }
        return student;
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, Student studentUpdate)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        if (!string.IsNullOrEmpty(studentUpdate.Name))
            student.Name=studentUpdate.Name;
        if (studentUpdate.Age != null)
            student.Age=studentUpdate.Age;
        if (!string.IsNullOrEmpty(studentUpdate.Group))
            student.Group=studentUpdate.Group;
        if (!string.IsNullOrEmpty(studentUpdate.Email))
            student.Email=studentUpdate.Email;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    /*[HttpGet("{Age}")]
    public async Task<ActionResult<Student>> GetAge(int Age)
    {
        var student = await _context.Students.FindAsync(Age);
        if (student == null)
        {
            return NotFound();
        }
        return student;
    }*/
}