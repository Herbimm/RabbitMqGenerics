using RabbitMqConsumer.Consumers;
using RabbitMqConsumer.Infrastructure.RabbitConsumer;

namespace RabbitMqConsumer.HostedServices
{
    public class DeliveryHostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var consumer = new RabbitMQConsumer<DeliveryConsumer>("PlaceDelivery", HandleMessages);
            consumer.Start();
        }

        private static bool HandleMessages(DeliveryConsumer message)
        {
            // Lógica para processar a mensagem aqui
            Console.WriteLine($"Received message: {message}");

            // Retorna true se a mensagem foi processada com sucesso, false caso contrário
            return true;
        } 
        

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
