using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace literature.inventory.Models.Publications
{
  public interface IPublication
  {
    int Id { get; set; }
    string Title { get; set; }
    string Language { get; set;  }
  }
}
