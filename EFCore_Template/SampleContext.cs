using Microsoft.EntityFrameworkCore;

namespace EFCore_Template
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>(e =>
            {
                e.HasKey(e => e.CustomerId);
                e.Property(e => e.CustomerId).UseIdentityColumn();

                e.HasMany(c => c.Orders)
                 .WithOne(o => o.Customer)
                 .HasForeignKey(c => c.CustomerId);
            });

            builder.Entity<Product>(e =>
            {
                e.HasKey(e => e.ProductId);
                e.Property(e => e.ProductId).UseIdentityColumn();

                e.HasMany(c => c.Orders)
                 .WithOne(o => o.Product)
                 .HasForeignKey(o => o.ProductId);
            });

            builder.Entity<Order>(e =>
            {
                e.HasKey(o => o.OrderId);
                e.Property(e => e.OrderId).UseIdentityColumn();
                e.Property(e => e.CreatedTime).HasDefaultValueSql(@"(now() at time zone 'utc')");

                e.Navigation(e => e.Customer).AutoInclude();
                e.Navigation(e => e.Product).AutoInclude();
            });
        }
    }

    public class Product
    {
        public long ProductId { get; set; }
        public required string Name { get; set; }
        public decimal Cost { get; set; }

        public ICollection<Order> Orders { get; set; }
    }

    public class Order
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public long CustomerId { get; set; }
        public DateTime CreatedTime { get; set; }

        public required Product Product { get; set; }
        public required Customer Customer { get; set; }
    }

    public class Customer
    {
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
