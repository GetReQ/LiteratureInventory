using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using literature.inventory.Models;
using literature.inventory.Services;

namespace literature.inventory.Controllers
{
  [Route("api/publishers")]
  [ApiController]
  public class PublisherController : ControllerBase
  {
    private readonly PublisherService _publisherService;

    public PublisherController(PublisherService publisherService)
    {
      _publisherService = publisherService;
    }

    [HttpGet]
    public ActionResult<List<Publisher>> Get()
    {
      return _publisherService.Get();
    }

    [HttpGet("{id:length(24)}", Name = "GetPublisher")]
    public ActionResult<Publisher> Get(string id)
    {
      var pub = _publisherService.Get(id);

      if (pub == null)
      {
        return NotFound();
      }

      return pub;
    }

    [HttpPost]
    public ActionResult<Publisher> Create(Publisher publisher)
    {
      _publisherService.Create(publisher);

      return CreatedAtRoute("GetPublisher", new { id = publisher.Id.ToString() }, publisher);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Publisher pubIn)
    {
      var pub = _publisherService.Get(id);

      if (pub == null)
      {
        return NotFound();
      }

      _publisherService.Update(id, pubIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var pub = _publisherService.Get(id);

      if (pub == null)
      {
        return NotFound();
      }

      _publisherService.Remove(pub.Id);

      return NoContent();
    }
  }
}

//   [HttpGet()]
//   public IActionResult GetPublishers([FromQuery]string name)
//   {
//     var publishers = MockDataStore.Current.Publishers;

//     if (string.IsNullOrEmpty(name))
//       return Ok(publishers);

//     if (name.Length < 3)
//       return BadRequest();

//     //find publisher based on names
//     var searchResults = publishers.FindAll(i => 
//       i.FirstName.Contains(name, StringComparison.InvariantCultureIgnoreCase) || 
//       i.LastName.Contains(name, StringComparison.InvariantCultureIgnoreCase));
//     if (searchResults == null || searchResults.Count() == 0)
//       return NotFound();

//     return Ok(searchResults);
//   }

//   [HttpGet("{id:length(24)}", Name = "GetPublisher")]
//   public IActionResult GetPublisher(int id)
//   {
//     var publisher = MockDataStore.Current.Publishers.FirstOrDefault(i => i.Id == id);

//     if (publisher == null)
//       return NotFound();

//     return Ok(publisher);
//   }


// }
//}
