using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      // We want to apply migrations if there is any and create our database when application starts, so we are doing some logic here for that;
      var host = CreateHostBuilder(args).Build();
      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        try
        {
          var context = services.GetRequiredService<StoreContext>();
          await context.Database.MigrateAsync();
          // Seed Data;
          await StoreContextSeed.SeedAsync(context, loggerFactory);
        }
        catch (System.Exception ex)
        {

          var logger = loggerFactory.CreateLogger<Program>();
          logger.LogError(ex, "An error occured during migration.");
        }
      }
      host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
