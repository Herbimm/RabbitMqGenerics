using RabbitMqConsumer.Commands;

namespace RabbitMqConsumer.Handlers
{
    public interface IMessageHandler<T>
    {
        Task HandleAsync(T message);
    }
}
