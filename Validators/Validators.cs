using FluentValidation;

namespace pizza.Validators;

public class Validators {
  public static void Setup(WebApplicationBuilder builder) {
    builder.Services.AddValidatorsFromAssemblyContaining<PizzaCreateValidator>();
  }
}