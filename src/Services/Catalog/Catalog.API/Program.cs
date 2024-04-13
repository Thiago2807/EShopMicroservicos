var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços de um container.

var app = builder.Build();

// Configuração das requisições HTTP pipeline.

app.Run();