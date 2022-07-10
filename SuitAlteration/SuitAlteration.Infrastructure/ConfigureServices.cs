using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuitAlteration.Application.Interfaces;
using SuitAlteration.Infrastructure.Persistence.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>(); 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            bool.TryParse(configuration["BaseServiceSettings:UseInMemoryDatabase"], out var useInMemory);

            if (useInMemory)
                services.AddDbContext<SuitApplicationDbContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            else
                services.AddDbContext<SuitApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("SuitAlteration.Infrastructure")));

            return services;
        }
    }
}
