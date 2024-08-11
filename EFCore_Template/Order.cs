namespace EFCore_Template
{
    public class Order
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public long CustomerId { get; set; }
        public DateTime CreatedTime { get; set; }

        public required Product Product { get; set; }
        public required Customer Customer { get; set; }
    }
}
