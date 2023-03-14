namespace RabbitMqSender.Entities
{
    public class Delivery : BaseEntity
    {
        public Delivery(int quantity, decimal weight, Customer customer, Address address, List<Product> products)
        {         
            Products = products;
            Quantity = quantity;
            Weight = weight;
            Customer = customer;
            Address = address;
        }
       

        /// <summary>
        /// Quantidade do produto
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Peso do produto
        /// </summary>
        public decimal Weight { get; private set; }

        /// <summary>
        /// Cliente
        /// </summary>
        public Customer Customer{ get; private set; }

        /// <summary>
        /// Endereço do cliente
        /// </summary>
        public Address  Address{ get; private set; }

        /// <summary>
        /// Produtos a serem enviados
        /// </summary>
        public List<Product> Products { get; private set; }
    }
}
