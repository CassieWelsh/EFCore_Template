namespace EFCore_Template
{
    public class Customer
    {
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
