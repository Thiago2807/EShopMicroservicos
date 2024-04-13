var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os de um container.

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// Configura��o das requisi��es HTTP pipeline.
app.MapCarter();

app.Run();