using System.Collections.Generic;
using System.Linq;
using literature.inventory.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace literature.inventory.Services
{
  public class PublisherService
  {
    private readonly IMongoCollection<Publisher> _publishers;
    public PublisherService(IConfiguration config)
    {
      var client = new MongoClient(config.GetConnectionString("LiteratureDb"));
      var database = client.GetDatabase("LiteratureDb");
      _publishers = database.GetCollection<Publisher>("Publisher");
    }

    public List<Publisher> Get()
    {
      return _publishers.Find(publisher => true).ToList();
    }

    public Publisher Get(string id)
    {
      var pubId = new ObjectId(id);

      return _publishers.Find<Publisher>(publisher => publisher.Id == pubId).FirstOrDefault();
    }

    public Publisher Create(Publisher publisher)
    {
      _publishers.InsertOne(publisher);
      return publisher;
    }

    public void Update(string id, Publisher pubIn)
    {
      var pubId = new ObjectId(id);

      _publishers.ReplaceOne(publisher => publisher.Id == pubId, pubIn);
    }

    public void Remove(Publisher pubIn)
    {
      _publishers.DeleteOne(publisher => publisher.Id == pubIn.Id);
    }

    public void Remove(ObjectId id)
    {
      _publishers.DeleteOne(publisher => publisher.Id == id);
    }
  }
}