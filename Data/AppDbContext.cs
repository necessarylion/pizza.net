using Microsoft.EntityFrameworkCore;
using pizza.Models;

namespace pizza.Data;

public class AppDbContext : DbContext {
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  // Example table
  public DbSet<Pizza> Pizzas { get; set; }
}


