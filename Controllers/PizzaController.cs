using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizza.Data;
using pizza.Models;

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
  public async Task<ActionResult<Pizza>> Get(int id) {
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza == null) return NotFound();
    return Ok(pizza);
  }

  [HttpPost]
  public async Task<ActionResult<Pizza>> Create([FromBody] Pizza pizzaReq) {
    var pizza = new Pizza {
      Name = pizzaReq.Name,
      Description = pizzaReq.Description,
      Image = pizzaReq.Image,
      Price = pizzaReq.Price
    };
    await db.Pizzas.AddAsync(pizza);
    await db.SaveChangesAsync();
    return Ok(pizza);
  }

  [Route("{id}")]
  [HttpPut]
  public async Task<ActionResult<Pizza>> Update([FromBody] Pizza pizzaReq, int id) {
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza == null) return NotFound();
    pizza.Name = pizzaReq.Name;
    pizza.Description = pizzaReq.Description;
    pizza.Image = pizzaReq.Image;
    pizza.Price = pizzaReq.Price;
    await db.SaveChangesAsync();
    return Ok(pizza);
  }

  [Route("{id}")]
  [HttpDelete]
  public async Task<ActionResult<Pizza>> Delete(int id) {
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza == null) return NotFound();
    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Ok(pizza);
  }
}