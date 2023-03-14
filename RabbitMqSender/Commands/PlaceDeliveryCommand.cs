using RabbitMqSender.Commands.Handlers;
using RabbitMqSender.Commands.Responses;
using RabbitMqSender.Entities;
using RabbitMqSender.Handlers;
using RabbitMqSender.Infrastructure.RabbitSender;
using System.ComponentModel.DataAnnotations;

namespace RabbitMqSender.Commands
{
    public class PlaceDeliveryCommand : IRequestWrapper<PlaceDeliveryCommand>
    {
        /// <summary>
        /// Quantidade do produto
        /// </summary>
        
        public int Quantity { get; set; }

        /// <summary>
        /// Peso do produto
        /// </summary>
        
        public decimal Weight { get; set; }

       

        public async Task<CommandResponse<PlaceDeliveryCommand>> HandleAsync(PlaceDeliveryCommand command)
        {
            var client = new RabbitMQSender<PlaceDeliveryCommand>("jackal.rmq.cloudamqp.com","PlaceDelivery");
            client.Send(command);
            return new CommandResponse<PlaceDeliveryCommand>() {Success = true };
        }
    }
}
