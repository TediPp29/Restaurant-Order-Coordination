using RestaurantOrderCoordination.Api.Hubs;
using RestaurantOrderCoordination.Application.Interfaces;
using RestaurantOrderCoordination.Application.Notifications;
using RestaurantOrderCoordination.Infrastructure.Notifications;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var clientOrigins = builder.Configuration.GetSection("ClientOrigins").Get<string[]>() ?? []; // Retrieve client origins or default to an empty array
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactClient", policy =>
    {
        if (clientOrigins.Length > 0)
            policy.WithOrigins(clientOrigins).AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddSignalR();
builder.Services.AddScoped<IOrderAccessChecker, OrderAccessChecker>();
builder.Services.AddScoped<INotificationService, NotificationService>();

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

app.UseCors("ReactClient");
app.UseAuthorization();

app.MapControllers();
app.MapHub<OrdersHub>("/hubs/orders").RequireAuthorization();

app.Run();
