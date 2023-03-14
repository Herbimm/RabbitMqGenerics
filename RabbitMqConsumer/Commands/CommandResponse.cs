namespace RabbitMqConsumer.Commands
{
    public class CommandResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Erros { get; set; }
    }
}
