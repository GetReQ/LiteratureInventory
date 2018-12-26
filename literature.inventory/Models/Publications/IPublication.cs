using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace literature.inventory.Models.Publications
{
  public interface IPublication
  {
    ObjectId Id { get; set; }

    [BsonElement("Title")]
    string Title { get; set; }

    [BsonElement("Language")]
    string Language { get; set;  }
  }
}
