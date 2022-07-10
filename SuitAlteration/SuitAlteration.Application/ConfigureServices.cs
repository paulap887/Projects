using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuitAlteration.Application.Common.Behaviours;
using SuitAlteration.Application.Messaging.Configuration;
using SuitAlteration.Application.Messaging.Sender;
using SuitAlteration.Application.Messaging.Sender.AlterationFinished;
using SuitAlteration.Application.Messaging.Sender.OrderPaid;
using System.Reflection;

namespace SuitAlteration.Application
{
    public static class ConfigureServices
    {   
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            var serviceClientSettingsConfig = configuration.GetSection("AzureServiceBus");
            services.Configure<AzureServiceBusConfiguration>(serviceClientSettingsConfig);

            services.AddSingleton<IAlterationPaidServiceBusSender, AlterationPaidServiceBusSender>();
            services.AddSingleton<IAlterationFinishedServiceBusSender, AlterationFinishedServiceBusSender>();
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddApplicationInsightsTelemetry(); 
            return services;
        }
    }
}
