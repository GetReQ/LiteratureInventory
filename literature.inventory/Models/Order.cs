using System;
using literature.inventory.Models.Publications;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace literature.inventory.Models
{
  public class Order
  {
    public ObjectId Id { get; set; }

    [BsonElement("Publication")]
    public IPublication Publication { get; set; }

    [BsonElement("Quantity")]
    public int Quantity { get; set; }

    [BsonElement("Publisher")]
    public Publisher Publisher { get; set; }

    [BsonElement("DateOrdered")]
    public DateTime Date { get; set; }

  }
}
