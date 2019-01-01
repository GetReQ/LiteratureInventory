using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using literature.inventory.Models;
using literature.inventory.Models.Publications;
using literature.inventory.Services;
using System;
using System.Linq;

namespace literature.inventory.Controllers
{
  [Route("api/publcations")]
  [ApiController]
  public class PublicationController : ControllerBase
  {
    private readonly PublicationService _publicationService;

    public PublicationController(PublicationService publicationService)
    {
      _publicationService = publicationService;
    }

    [HttpGet]
    public ActionResult<List<IPublication>> Get()
    {
      return _publicationService.Get();
    }

    [HttpGet("{id:length(24)}", Name = "GetPublication")]
    public ActionResult<List<IPublication>> Get([FromQuery]string name)
    {
      if (name.Length < 3)
        return BadRequest();

      var publication = _publicationService.Get();

      if (string.IsNullOrEmpty(name))
        return Ok(publication);

      //find publication based on title
      var searchResults = publication.FindAll(i => 
        i.Title.Contains(name, StringComparison.InvariantCultureIgnoreCase));

      if (searchResults == null || searchResults.Count() == 0)
        return NotFound();

      return Ok(searchResults);
    }

    [HttpPost]
    public ActionResult<IPublication> Create(IPublication publication)
    {
      _publicationService.Create(publication);

      return CreatedAtRoute("GetPublication", new { id = publication.Id.ToString() }, publication); //return URI generated from this new publication
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, IPublication pubIn)
    {
      var pub = _publicationService.Get(id);

      if (pub == null)
      {
        return NotFound();
      }

      pubIn.Id = pub.Id;  //ensure the publication passed in has the correct ID

      _publicationService.Update(id, pubIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var pub = _publicationService.Get(id);

      if (pub == null)
      {
        return NotFound();
      }

      _publicationService.Remove(pub.Id);

      return NoContent();
    }
  }
}

