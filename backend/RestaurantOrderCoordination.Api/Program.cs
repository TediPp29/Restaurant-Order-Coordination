using RestaurantOrderCoordination.Application.Interfaces;
using RestaurantOrderCoordination.Infrastructure.Integrations.TheMealDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient("MealDbClient", client =>
{
    client.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
    client.Timeout = TimeSpan.FromSeconds(10);
});
builder.Services.AddScoped<IMealDbService, MealDbService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
