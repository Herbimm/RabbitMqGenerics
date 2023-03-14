using RabbitMqConsumer.Handlers;

namespace RabbitMqConsumer.Commands.PlaceDelivery
{
    public class PlaceDeliveryCommand : IMessageHandler<PlaceDeliveryCommand>
    {
        public async Task HandleAsync(PlaceDeliveryCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
