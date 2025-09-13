using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizza.Data;
using pizza.Models;

namespace pizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzasController(AppDbContext db) : ControllerBase {
  private readonly AppDbContext _db = db;

  [HttpGet]
  public async Task<List<Pizza>> Listing() {
    var pizzas = await _db.Pizzas.ToListAsync();
    return pizzas;
  }

  [Route("{id}")]
  [HttpGet]
  public async Task<Pizza> Get(int id) {
    var pizza = await _db.Pizzas.FindAsync(id) ?? throw new Exception("Record Not found");
    return pizza;
  }

  [HttpPost]
  public async Task<Pizza> Create([FromBody] Pizza pizzaReq) {
    var pizza = new Pizza {
      Name = pizzaReq.Name,
      Description = pizzaReq.Description,
      Image = pizzaReq.Image,
      Price = pizzaReq.Price
    };
    await _db.Pizzas.AddAsync(pizza);
    await _db.SaveChangesAsync();
    return pizza;
  }

  [Route("{id}")]
  [HttpPut]
  public async Task<Pizza> Create([FromBody] Pizza pizzaReq, int id) {
    var pizza = await _db.Pizzas.FindAsync(id) ?? throw new Exception("Record Not found");
    pizza.Name = pizzaReq.Name;
    pizza.Description = pizzaReq.Description;
    pizza.Image = pizzaReq.Image;
    pizza.Price = pizzaReq.Price;
    await _db.SaveChangesAsync();
    return pizza;
  }

  [Route("{id}")]
  [HttpDelete]
  public async Task<Pizza> Delete(int id) {
    var pizza = await _db.Pizzas.FindAsync(id) ?? throw new Exception("Record Not found");
    _db.Pizzas.Remove(pizza);
    await _db.SaveChangesAsync();
    return pizza;
  }
}