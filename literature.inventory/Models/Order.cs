using literature.inventory.Models.Publications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace literature.inventory.Models
{
  public class Order
  {
    public int Id { get; set; }
    public IPublication Publication { get; set; }
    public int Quantity { get; set; }
    public Publisher Publisher { get; set; }
    public DateTime Date { get; set; }

  }
}
