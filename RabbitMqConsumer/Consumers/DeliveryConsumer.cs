using Newtonsoft.Json;
using RabbitMqConsumer.Handlers;

namespace RabbitMqConsumer.Consumers
{
    public class DeliveryConsumer : IMessageHandler<DeliveryConsumer>
    {
        [JsonProperty("Quantity")]
        public int Quantity { get; set; }

        public async Task HandleAsync(DeliveryConsumer message)
        {
            try
            {
                throw new Exception();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
