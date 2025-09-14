using Microsoft.EntityFrameworkCore;
using pizza.Models;

namespace pizza.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {

  // Example table
  public DbSet<Pizza> Pizzas { get; set; }
}
