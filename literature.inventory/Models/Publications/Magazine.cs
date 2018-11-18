using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace literature.inventory.Models.Publications
{
  public class Magazine : IPublication
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Language { get; set; }
    public string Edition { get; set; }

  }
}
