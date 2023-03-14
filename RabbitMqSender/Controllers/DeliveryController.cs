using Microsoft.AspNetCore.Mvc;
using RabbitMqSender.Commands;
using RabbitMqSender.Commands.Handlers;
using RabbitMqSender.Commands.Responses;

namespace RabbitMqSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        [HttpPost("send")]
        public async Task<IActionResult> SendDeliveryProducs([FromBody]PlaceDeliveryCommand command)
        {
            var placeDelivery = await new PlaceDeliveryCommand().HandleAsync(command);
            return Ok();
        }
    }
}
