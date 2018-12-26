using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace literature.inventory.Models
{
  public class Publisher
  {
    public ObjectId Id { get; set; }
    
    [BsonElement("FirstName")]
    public string FirstName { get; set; }

    [BsonElement("LastName")]
    public string LastName { get; set; }


  }
}
