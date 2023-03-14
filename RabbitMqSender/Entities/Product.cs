namespace RabbitMqSender.Entities
{
    public class Product : BaseEntity
    {

        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Quantidade do produto
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Peso do produto unitário
        /// </summary>
        public int Weight { get; set; }
    }
}
