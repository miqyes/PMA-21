using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentAPI.Models;

public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public Data Data { get; set; } = new();
    public Group Group { get; set; } = new();

}