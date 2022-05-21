using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BjjAppApi.Models;

public class Move
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("names")]
    public string[] Names { get; set; } = null!;

    [BsonElement("type")]
    public string Type { get; set; } = null!;

    [BsonElement("difficulty")]
    public string Difficulty { get; set; } = null!;

    [BsonElement("description")]
    public string Description { get; set; } = null!;

    [BsonElement("counters")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string?[] Counters { get; set; } = null!;

    [BsonElement("demos")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string?[] Demos { get; set; } = null!;
}