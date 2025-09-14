using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizza.Data;
using pizza.Models;
using pizza.Validators;

namespace pizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzasController(AppDbContext db) : ControllerBase {
  [HttpGet]
  public async Task<ActionResult<List<Pizza>>> Listing() {
    var pizzas = await db.Pizzas.ToListAsync();
    return Ok(pizzas);
  }

  [Route("{id}")]
  [HttpGet]
  public async Task<ActionResult<Pizza>> Get([FromRoute] int id) {
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza == null) return NotFound();
    return Ok(pizza);
  }

  [HttpPost]
  public async Task<ActionResult<Pizza>> Create([FromBody] PizzaCreateRequest req, [FromServices] PizzaCreateValidator validator) {
    ValidationResult data = await validator.ValidateAsync(req);
    if (!data.IsValid) return BadRequest(data.Errors);
    var pizza = new Pizza {
      Name = req.Name,
      Description = req.Description,
      Image = req.Image,
      Price = req.Price
    };
    await db.Pizzas.AddAsync(pizza);
    await db.SaveChangesAsync();
    return Ok(pizza);
  }

  [Route("{id}")]
  [HttpPut]
  public async Task<ActionResult<Pizza>> Update([FromBody] PizzaUpdateRequest req, [FromServices] PizzaUpdateValidator validator, [FromRoute] int id) {
    ValidationResult data = await validator.ValidateAsync(req);
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza == null) return NotFound();
    pizza.Name = req.Name;
    pizza.Description = req.Description;
    pizza.Image = req.Image;
    pizza.Price = req.Price;
    await db.SaveChangesAsync();
    return Ok(pizza);
  }

  [Route("{id}")]
  [HttpDelete]
  public async Task<ActionResult<Pizza>> Delete([FromRoute] int id) {
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza == null) return NotFound();
    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Ok(pizza);
  }
}