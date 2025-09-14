using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using pizza.Data;

namespace pizza;

public class Startup {
  public static void SetupDatabase(WebApplicationBuilder builder) {
    builder.Services.AddDbContext<AppDbContext>(options => {
      options.UseMySql(
          builder.Configuration.GetConnectionString("MysqlConnection"),
          ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MysqlConnection"))
      );
    }
);
  }

  public static void SetupController(WebApplicationBuilder builder) {
    builder.Services.AddControllers(options => {
      options.Conventions.Add(new RouteTokenTransformerConvention(
          new SnakeCaseParameterTransformer()
      ));
    }).AddJsonOptions(options => {
      options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
    });
  }

  public static void SetupSwagger(WebApplicationBuilder builder) {
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
  }

  public static void RunMigration(WebApplication app) {
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
  }
}