namespace RabbitMqConsumer.Infrastructure.RabbitConsumer
{
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    using RabbitMqConsumer.Commands.Handlers;
    using RabbitMqConsumer.Commands.PlaceDelivery;
    using RabbitMqConsumer.Consumers;
    using RabbitMqConsumer.Handlers;
    using System;
    using System.Text;

    public class RabbitMQConsumer<T> : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;
        private readonly Func<T, bool> _messageHandler;

        public RabbitMQConsumer(string queueName, Func<T, bool> messageHandler)
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqps://ipdtkeay:tUL2vsfcjAOvPeFBdT6XGahZrKl-58Pz@jackal.rmq.cloudamqp.com/ipdtkeay") };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            _queueName = queueName;
            _messageHandler = messageHandler;
        }

        public void Start()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var messageObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(message);

                if (_messageHandler(messageObject))
                {
                    try
                    {
                        var handlerType = typeof(T);
                        var handlerInstance = Activator.CreateInstance(handlerType);
                        var handleMethod = handlerType.GetMethod("HandleAsync");
                        var task = (Task)handleMethod.Invoke(handlerInstance, new object[] { messageObject });
                        if (task.Exception.InnerExceptions.Count != 0)
                        {
                            _channel.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true);                            
                        }
                        else
                        {
                            _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                        }                                           
                                                
                    }
                    catch (Exception ex)
                    {
                        _channel.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true);
                        // Log or handle the exception here
                    }

                }
                else
                {
                    _channel.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true);
                }
            };

            _channel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}