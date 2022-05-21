using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BjjAppApi.Models;

public class Name
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("move")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Move { get; set; } = null!;

    [BsonElement("name")]
    public string MoveName { get; set; } = null!;
}