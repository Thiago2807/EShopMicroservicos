var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços de um container.

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// Configuração das requisições HTTP pipeline.
app.MapCarter();

app.Run();