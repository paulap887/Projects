 
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SuitAlteration.Infrastructure;

namespace Testings.Application.IntegrationTests; 

using static Testing;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(configurationBuilder =>
        {
            var integrationConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            configurationBuilder.AddConfiguration(integrationConfig);
        });

        builder.ConfigureServices((builder, services) =>
        { 
            services
                .Remove<DbContextOptions<SuitApplicationDbContext>>()
                .AddDbContext<SuitApplicationDbContext>((sp, options) =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                        builder => builder.MigrationsAssembly(typeof(SuitApplicationDbContext).Assembly.FullName)));
        });
    }
}
