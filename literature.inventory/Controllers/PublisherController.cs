using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace literature.inventory.Controllers
{
  [Route("api/publishers")]
  public class PublisherController : Controller
  {
    [HttpGet()]
    public IActionResult GetPublishers([FromQuery]string name)
    {
      var publishers = MockDataStore.Current.Publishers;

      if (string.IsNullOrEmpty(name))
        return Ok(publishers);

      if (name.Length < 3)
        return BadRequest();

      //find publisher based on names
      var searchResults = publishers.FindAll(i => 
        i.FirstName.Contains(name, StringComparison.InvariantCultureIgnoreCase) || 
        i.LastName.Contains(name, StringComparison.InvariantCultureIgnoreCase));
      if (searchResults == null || searchResults.Count() == 0)
        return NotFound();

      return Ok(searchResults);
    }

    [HttpGet("{id}")]
    public IActionResult GetPublisher(int id)
    {
      var publisher = MockDataStore.Current.Publishers.FirstOrDefault(i => i.Id == id);

      if (publisher == null)
        return NotFound();

      return Ok(publisher);
    }


  }
}
