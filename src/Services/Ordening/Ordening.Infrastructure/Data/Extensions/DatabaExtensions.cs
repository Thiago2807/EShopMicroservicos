using Microsoft.AspNetCore.Builder;

namespace Ordening.Infrastructure.Data.Extensions;

public static class DatabaExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();
    }
}
