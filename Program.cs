using pizza;
using pizza.Validators;

var builder = WebApplication.CreateBuilder(args);
Validators.Setup(builder);
Startup.SetupDatabase(builder);
Startup.SetupController(builder);
Startup.SetupSwagger(builder);

var app = builder.Build();
Startup.RunMigration(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.MapGet("/", () => "Pizza");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
