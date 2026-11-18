using Mapster;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.DTOs;
using StudentAPI.Models;
using StudentAPI.Services;
using MongoDB.Bson;

namespace StudentApi.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    private readonly StudentServices _studentService;

    public StudentsController(StudentServices studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/xml")]
    public async Task<IActionResult> CreateStudent(
        [FromBody] CreateStudent dto)
    {
        Student student = dto.Adapt<Student>();

        var created=await _studentService.CreateAsync(student);
       

        StudentResponse response =
            created.Adapt<StudentResponse>();
        

        return new ObjectResult(response)
        {
            StatusCode = StatusCodes.Status201Created,
            ContentTypes = { "application/xml" }
        };
    }

    [HttpGet]
    [Produces("application/xml")]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _studentService.GetAllAsync();
        var response = students.Adapt<List<StudentResponse>>();

        return new ObjectResult(response)
        {
            ContentTypes = { "application/xml" }
        };
    }

    [HttpGet("{id}")]
    [Produces("application/xml")]
    public async Task<IActionResult> GetStudentById(string id)
    {
        if (!ObjectId.TryParse(id, out _))
        {
            return BadRequest("Invalid student ID");
        }

        var student = await _studentService.GetByIdAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        var response = student.Adapt<StudentResponse>();

        return new ObjectResult(response)
        {
            ContentTypes = { "application/xml" }
        };
    }

    [HttpPatch("{id}")]
    [Consumes("application/json")]
    [Produces("application/xml")]
    public async Task<IActionResult> UpdateStudent(string id, [FromBody] UpdateStudent dto)
    {
        if (!ObjectId.TryParse(id, out _)) return BadRequest("Invalid student ID");
        var student = await _studentService.UpdateAsync(id, dto);

        if (student == null)
            return NotFound("Student not found");

        var response = student.Adapt<StudentResponse>();



        return new ObjectResult(response)
        {
            ContentTypes = { "application/xml" }
        };
    }

    [HttpPut("{id}")]
    [Consumes("application/json")]
    [Produces("application/xml")]
    public async Task<IActionResult> ReplaceStudent(string id, [FromBody] ReplaceStudent dto)
    {
        if (!ObjectId.TryParse(id, out _)) return BadRequest("Invalid student ID");
        var student = await _studentService.ReplaceAsync(id,dto);

        if (student == null)
            return NotFound("Student not found");

        var response = student.Adapt<StudentResponse>();



        return new ObjectResult(response)
        {
            ContentTypes = { "application/xml" }
        };
    }
    
    [HttpDelete("{id}")]
    [Produces("application/xml")]
    public async Task<IActionResult> DeleteStudent(string id)
    {
        if (!ObjectId.TryParse(id, out _)) return BadRequest("Invalid student ID");
        bool deleted = await _studentService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}