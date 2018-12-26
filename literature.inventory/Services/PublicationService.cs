using System.Collections.Generic;
using System.Linq;
using literature.inventory.Models.Publications;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace literature.inventory.Services
{
  public class PublicationService
  {
    private readonly IMongoCollection<IPublication> _publications;
    public PublicationService(IConfiguration config)
    {
      var client = new MongoClient(config.GetConnectionString("LiteratureDb"));
      var database = client.GetDatabase("LiteratureDb");
      _publications = database.GetCollection<IPublication>("Publications");
    }

    public List<IPublication> Get()
    {
      return _publications.Find(publication => true).ToList();
    }

    public IPublication Get(string id)
    {
      var pubId = new ObjectId(id);

      return _publications.Find<IPublication>(publication => publication.Id == pubId).FirstOrDefault();
    }

    public IPublication Create(IPublication publication)
    {
      _publications.InsertOne(publication);
      return publication;
    }

    public void Update(string id, IPublication pubIn)
    {
      var pubId = new ObjectId(id);

      _publications.ReplaceOne(publication => publication.Id == pubId, pubIn);
    }

    public void Remove(IPublication pubIn)
    {
      _publications.DeleteOne(publication => publication.Id == pubIn.Id);
    }

    public void Remove(ObjectId id)
    {
      _publications.DeleteOne(publication => publication.Id == id);
    }
  }
}