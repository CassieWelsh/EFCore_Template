namespace EFCore_Template
{
    public class Product
    {
        public long ProductId { get; set; }
        public required string Name { get; set; }
        public decimal Cost { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
