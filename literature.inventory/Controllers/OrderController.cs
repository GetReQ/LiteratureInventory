using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using literature.inventory.Models;
using literature.inventory.Services;
using System;
using System.Linq;

namespace literature.inventory.Controllers
{
  [Route("api/orders")]
  [ApiController]
  public class OrderController : ControllerBase
  {
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
      _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<List<Order>> Get()
    {
      return _orderService.Get();
    }

    [HttpGet("{id:length(24)}", Name = "GetOrder")]
    public ActionResult<Order> Get([FromQuery]string id)
    {
      if (id.Length < 24)
        return BadRequest();

      var order = _orderService.Get(id);

      if (order == null)
      {
          return NotFound();
      }

      return Ok(order);
    }

    [HttpPost]
    public ActionResult<Order> Create(Order order)
    {
      _orderService.Create(order);

      return CreatedAtRoute("GetOrder", new { id = order.Id.ToString() }, order); //return URI generated from this new order
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Order orderIn)
    {
      var order = _orderService.Get(id);

      if (order == null)
      {
        return NotFound();
      }

      orderIn.Id = order.Id;  //ensure the publication passed in has the correct ID

      _orderService.Update(id, orderIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var pub = _orderService.Get(id);

      if (pub == null)
      {
        return NotFound();
      }

      _orderService.Remove(pub.Id);

      return NoContent();
    }
  }
}

