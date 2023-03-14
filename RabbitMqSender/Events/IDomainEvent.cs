namespace RabbitMqSender.Events
{
    public interface IDomainEvent
    {
        public DateTime OccuredAt { get; set; }
    }
}
