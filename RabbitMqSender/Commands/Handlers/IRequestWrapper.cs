using RabbitMqSender.Commands.Responses;

namespace RabbitMqSender.Commands.Handlers
{
    public interface IRequestWrapper<T> 
    {
        Task<CommandResponse<T>> HandleAsync(T command);
    }
}
