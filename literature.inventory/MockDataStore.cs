using literature.inventory.Models;
using literature.inventory.Models.Publications;
using System;
using System.Collections.Generic;

namespace literature.inventory
{
  public class MockDataStore
  {
    public static MockDataStore Current => new MockDataStore();
    public List<Publisher> Publishers { get; set; }
    public List<Order> Orders { get; set; }

    public MockDataStore()
    {
      Publishers = new List<Publisher>()
        {
          new Publisher()
          {
            Id = 1,
            FirstName = "Fred",
            LastName = "Bloggs"
          },
          new Publisher()
          {
            Id = 2,
            FirstName = "Bill",
            LastName = "Sykes"
          },
          new Publisher()
          {
            Id = 3,
            FirstName = "Bobby",
            LastName = "Thornton"
          },
          new Publisher()
          {
            Id = 4,
            FirstName = "Sam",
            LastName = "Gamgee"
          }
        };

      var r = new Random();
      Orders = new List<Order>()
      {
        new Order()
        {
          Id = 1,
          Date = DateTime.UtcNow.AddDays(-5),
          Publisher = Publishers[r.Next(0,3)],
          Publication = new Magazine()
          {
            Id = 1,
            Edition = "1",
            Language = "English",
            Title = "Watchtower"
          }
        },
        new Order()
        {
          Id = 2,
          Date = DateTime.UtcNow.AddDays(-15),
          Publisher = Publishers[r.Next(0,3)],
          Publication = new Magazine()
          {
            Id = 2,
            Edition = "2",
            Language = "Mandarin Simplified",
            Title = "Watchtower"
          }
        },
        new Order()
        {
          Id = 3,
          Date = DateTime.UtcNow.AddDays(-20),
          Publisher = Publishers[r.Next(0,3)],
          Publication = new Magazine()
          {
            Id = 3,
            Edition = "1",
            Language = "Thai",
            Title = "Awake"
          }
        }
      };
    }
  }
}