var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os de um container.

var app = builder.Build();

// Configura��o das requisi��es HTTP pipeline.

app.Run();