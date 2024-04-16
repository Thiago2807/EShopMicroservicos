var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços de um container.

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// Configuração das requisições HTTP pipeline.
app.MapCarter();

app.Run();