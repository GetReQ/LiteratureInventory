using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace literature.inventory.Models.Publications
{
  public class Magazine : IPublication
  {
    public ObjectId Id { get; set; }
    public string Title { get; set; }
    public string Language { get; set; }
    public string Edition { get; set; }

  }
}
