using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Mongo_Docker;

internal class People
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.Int32)]
    public int Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }
}
