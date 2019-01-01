using System.Collections.Generic;
using System.Linq;
using literature.inventory.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace literature.inventory.Services
{
  public class OrderService
  {
    private readonly IMongoCollection<Order> _orders;
    public OrderService(IConfiguration config)
    {
      var client = new MongoClient(config.GetConnectionString("LiteratureDb"));
      var database = client.GetDatabase("LiteratureDb");
      _orders = database.GetCollection<Order>("Orders");
    }

    public List<Order> Get()
    {
      return _orders.Find(order => true).ToList();
    }

    public Order Get(string id)
    {
      var orderId = new ObjectId(id);

      return _orders.Find<Order>(order => order.Id == orderId).FirstOrDefault();
    }

    public Order Create(Order order)
    {
      _orders.InsertOne(order);
      return order;
    }

    public void Update(string id, Order orderIn)
    {
      var orderId = new ObjectId(id);

      _orders.ReplaceOne(order => order.Id == orderId, orderIn);
    }

    public void Remove(Order orderIn)
    {
      _orders.DeleteOne(order => order.Id == orderIn.Id);
    }

    public void Remove(ObjectId id)
    {
      _orders.DeleteOne(order => order.Id == id);
    }
  }
}