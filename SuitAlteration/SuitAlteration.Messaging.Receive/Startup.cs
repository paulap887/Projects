using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuitAlteration.Messaging.Receive;
using SuitAlteration.Messaging.Receive.DbContext;
using SuitAlteration.Messaging.Receive.Service;
using SuitAlteration.Messaging.Receive.Service.Interfaces;
using System;

[assembly: FunctionsStartup(typeof(Startup))]

namespace SuitAlteration.Messaging.Receive
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var connectionString = Environment.GetEnvironmentVariable("DatabaseConnectionString");
            builder.Services.AddDbContext<SuitApplicationDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddTransient<IAlterationService, AlterationService>();
        }
    }
}

