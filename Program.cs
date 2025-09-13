using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using pizza.Data;

var builder = WebApplication.CreateBuilder(args);


// Add DbContext with MySQL
builder.Services.AddDbContext<AppDbContext>(options => {
  options.UseMySql(
      builder.Configuration.GetConnectionString("MysqlConnection"),
      ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MysqlConnection"))
  );
}
);

// Add services to the container.

builder.Services.AddControllers(options => {
  options.Conventions.Add(new RouteTokenTransformerConvention(
      new SnakeCaseParameterTransformer()
  ));
}).AddJsonOptions(options => {
  options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
  c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
    Title = "Pizza API",
    Version = "v1",
  });
  var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
