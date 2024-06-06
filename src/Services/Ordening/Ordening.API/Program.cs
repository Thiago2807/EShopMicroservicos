using Ordening.API;
using Ordening.Application;
using Ordening.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add Services Container
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();


var app = builder.Build();

// Configure the HTTP request pipeline
app.UseApiServices();

app.Run();