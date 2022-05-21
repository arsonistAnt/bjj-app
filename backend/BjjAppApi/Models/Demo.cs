using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BjjAppApi.Models;

public class Demo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("move")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Move { get; set; } = null!;

    [BsonElement("url")]
    public string Url { get; set; } = null!;

    [BsonElement("author")]
    public string Author { get; set; } = null!;
}