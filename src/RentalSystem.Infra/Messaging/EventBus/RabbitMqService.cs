using RabbitMQ.Client;
using RentalSystem.Application.Services.Messaging;
using RentalSystem.Domain.Dtos;
using System.Text;
using System.Text.Json;
using IModel = RabbitMQ.Client.IModel;

namespace RentalSystem.Infra.Messaging.EventBus
{
    public class RabbitMqService : IMessageBusService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string QueueName = "motorcycle_registered_events";

        public RabbitMqService()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "adminrentalsystem"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                      queue: QueueName,
                      durable: false,
                      exclusive: false,
                      autoDelete: false,
                      arguments: null
                  );
        }

        public void PublishMotorcycleRegisteredEvent(MotorcycleCreatedEvent motorcycleRegisteredEvent)
        {
            var message = JsonSerializer.Serialize(motorcycleRegisteredEvent);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "",
                                routingKey: QueueName,
                                basicProperties: null,
                                body: body);
        }
    }
}
