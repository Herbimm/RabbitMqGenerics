namespace RabbitMqSender.Commands.Handlers
{
    public class RequestWrapper<T> : IRequestWrapper<T>
    {
        public Task<Responses.CommandResponse<T>> HandleAsync(T command)
        {
            throw new NotImplementedException();
        }
    }
}
