using System.ComponentModel;

namespace pizza.Models;

public class Pizza {
  [DefaultValue(1)]
  public int Id { get; set; }

  [DefaultValue("https://images.unsplash.com/photo-1540189549336-e6e10689e167?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80")]
  public string? Image { get; set; }

  [DefaultValue("Pepperoni")]
  public string? Name { get; set; }

  [DefaultValue(9.99)]
  public decimal Price { get; set; }

  [DefaultValue("A delicious pepperoni pizza")]
  public string? Description { get; set; }
}