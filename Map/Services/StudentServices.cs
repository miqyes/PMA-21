using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentAPI.DTOs;
using StudentAPI.Models;
using StudentAPI.Settings;

namespace StudentAPI.Services;

public class StudentServices
{
    private readonly IMongoCollection<Student> _students;

    public StudentServices(IOptions<MongoDb> options)
    {
        var settings = options.Value;
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _students = database.GetCollection<Student>(
            settings.CollectionName
        );
    }

    public async Task<Student> CreateAsync(Student student)
    {
        await _students.InsertOneAsync(student);
        return student;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _students.Find(_ => true).ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(string id)
    {
        return await _students.Find(s => s.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Student?> UpdateAsync(string id, UpdateStudent dto)
    {
        var student = await GetByIdAsync(id);

        if (student == null)
        {
            return null;
        }

        if (dto.Data?.Name != null)
            student.Data.Name = dto.Data.Name;

        if (dto.Data?.Age != null)
            student.Data.Age = dto.Data.Age.Value;

        if (dto.Group?.Name != null)
            student.Group.Name = dto.Group.Name;

        if (dto.Group?.Curator != null)
            student.Group.Curator = dto.Group.Curator;

        await _students.ReplaceOneAsync(s => s.Id == id, student);

        return student;
    }

    public async Task<Student?> ReplaceAsync(string id, ReplaceStudent dto)
    {
        var student = await GetByIdAsync(id);

        if (student == null)
        {
            return null;
        }

        student.Data = new Data
        {
            Name = dto.Data.Name,
            Age = dto.Data.Age
        };

        student.Group = new Group
        {
            Name = dto.Group.Name,
            Curator = dto.Group.Curator
        };

        await _students.ReplaceOneAsync(s => s.Id == id, student);

        return student;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var result = await _students.DeleteOneAsync(s => s.Id == id);
        return result.DeletedCount > 0;
    }
}