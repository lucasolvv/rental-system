using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using RentalSystem.Domain.Dtos;
using RentalSystem.Domain.Entities;
using RentalSystem.Infra.DataAccess;
using System.Text;
using System.Text.Json;

namespace RentalSystem.Infra.Messaging.Consumers
{
    public class MotorcycleRegisteredConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public MotorcycleRegisteredConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory()
            {
                //HostName = "localhost",
                HostName = "rabbitmq",
                UserName = "admin",
                Password = "adminrentalsystem"
            };

            IConnection connection = null;

            // Retry para tentar se conectar com o RabbitMQ
            var policy = Policy
                .Handle<BrokerUnreachableException>()
                .WaitAndRetry(5, retryAttempt =>
                {
                    Console.WriteLine($"[RabbitMQ Retry] Tentativa {retryAttempt} falhou. Tentando novamente em 5 segundos...");
                    return TimeSpan.FromSeconds(5);
                });

            policy.Execute(() =>
            {
                connection = factory.CreateConnection();
                Console.WriteLine("[RabbitMQ] Conexão estabelecida com sucesso.");
            });

            var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "motorcycle_registered_events",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var creationEvent = JsonSerializer.Deserialize<MotorcycleCreatedEvent>(message);

                if (creationEvent?.Year == 2024)
                {
                    using var scope = _serviceProvider.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<RentalSystemDbContext>();

                    var registration = new MotorcycleRegisteredEvent
                    {
                        Id = Guid.NewGuid(),
                        MotorcycleId = creationEvent.MotorcycleId,
                        EventDate = DateTime.Now,
                        MessageContent = $"Nova moto cadastrada em nossa base: {message}"
                    };

                    db.MotorcycleRegisteredEvent.Add(registration);
                    await db.SaveChangesAsync();
                }
            };

            channel.BasicConsume(
                queue: "motorcycle_registered_events",
                autoAck: true,
                consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
