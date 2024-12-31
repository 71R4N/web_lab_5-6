using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace WebApplication1.Services
{
    public class RabbitMQService
    {
        private readonly string _exchangeName = "cars_events_exchange";
        private readonly string _queueName = "cars_events_queue";
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Объявляем Exchange и Queue
            _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Fanout);
            _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: _queueName, exchange: _exchangeName, routingKey: "");
        }

        public void PublishEvent(object message)
        {
            var jsonMessage = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            _channel.BasicPublish(exchange: _exchangeName, routingKey: "", basicProperties: null, body: body);
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
