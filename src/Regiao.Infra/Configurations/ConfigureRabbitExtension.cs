using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.DependencyInjection;
using Regiao.Worker.Consumer;

namespace Regiao.Infra.Configurations;

public static class ConfigureRabbitExtension
{
    public static void ConfigureRabbit(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMassTransit(busConfigurator =>
        {
            var rabbitMqHost = Environment.GetEnvironmentVariable("RabbitMq");

            busConfigurator.SetSnakeCaseEndpointNameFormatter();
            busConfigurator.AddConsumer<ContatoCriadoConsumer>();

            busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
            {
                busFactoryConfigurator.Host(rabbitMqHost ?? "rabbitmq", hostConfigurator =>
                {
                    hostConfigurator.Username("guest");
                    hostConfigurator.Password("guest");
                });
                busFactoryConfigurator.UseJsonDeserializer();
                busFactoryConfigurator.ConfigureEndpoints(context);
            });
        });
    }
}