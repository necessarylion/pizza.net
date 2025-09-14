
namespace pizza.Validators;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

public class PizzaUpdateRequest {
  [Required]
  [DefaultValue("https://images.unsplash.com/photo-1540189549336-e6e10689e167?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80")]
  public string? Image { get; set; }

  [Required]
  [DefaultValue("Pepperoni")]
  public string? Name { get; set; }

  [Required]
  [DefaultValue(9.99)]
  public decimal Price { get; set; }

  [Required]
  [DefaultValue("A delicious pepperoni pizza")]
  public string? Description { get; set; }
}

public class PizzaUpdateValidator : AbstractValidator<PizzaUpdateRequest> {
  public PizzaUpdateValidator() {
    RuleFor(pizza => pizza.Image).NotNull();
    RuleFor(pizza => pizza.Name).NotNull();
    RuleFor(pizza => pizza.Description).NotNull();
    RuleFor(pizza => pizza.Price).NotNull();
  }
}