namespace RabbitMqSender.Entities
{
    public abstract class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Cep { get; set; }
    }
}
