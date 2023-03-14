using RabbitMqConsumer.Commands.PlaceDelivery;
using RabbitMqConsumer.Handlers;

namespace RabbitMqConsumer.Commands.Handlers
{
    public class MessageHandler<T> : IMessageHandler<T>
    {   
        public Task HandleAsync(T message)
        {
            throw new NotImplementedException();
        }
    }   
}
