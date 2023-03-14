namespace RabbitMqSender.Entities
{
    public abstract class Customer
    {
        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        public string Cpf { get; set; }
    }
}
