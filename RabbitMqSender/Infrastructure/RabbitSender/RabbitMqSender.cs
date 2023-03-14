namespace RabbitMqSender.Infrastructure.RabbitSender
{
    using RabbitMQ.Client;
    using System;
    using System.Text.Json;

    public class RabbitMQSender<T>
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;
        private readonly int _maxRetries;
        private readonly TimeSpan _retryInterval;

        public RabbitMQSender(string hostname, string queueName, int maxRetries = 3, TimeSpan? retryInterval = null)
        {
            var factory = new ConnectionFactory() { Uri = new Uri("") };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            _queueName = queueName;
            _maxRetries = maxRetries;
            _retryInterval = retryInterval ?? TimeSpan.FromSeconds(1);
        }

        public void Send(T message)
        {
            string json = JsonSerializer.Serialize(message);
            var body = System.Text.Encoding.UTF8.GetBytes(json);
            var retryCount = 0;
            var sent = false;

            while (!sent && retryCount <= _maxRetries)
            {
                try
                {
                    _channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
                    sent = true;
                }
                catch (Exception ex)
                {
                    if (retryCount >= _maxRetries)
                    {
                        throw new Exception($"Failed to send message after {_maxRetries} retries", ex);
                    }

                    retryCount++;
                    System.Threading.Thread.Sleep(_retryInterval);
                }
            }
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}