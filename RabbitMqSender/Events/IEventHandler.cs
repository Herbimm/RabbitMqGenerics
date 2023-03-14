namespace RabbitMqSender.Events
{
    public interface IEventHandler<in T> where T : IDomainEvent
    {
        void Handle(T command);
    }
}
