using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EFCore_Template
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new SampleContextFactory();

            using var context = factory.CreateDbContext(args);

            //var c = new Customer { Name = "Customer1", BirthDate = DateTime.UtcNow };
            //var p = new Product { Name = "Product1", Cost = 123m };
            //var o = new Order { Customer = c, Product = p };

            //context.Customers.Add(c);
            //context.Products.Add(p);
            //context.Orders.Add(o);
            //context.SaveChanges();

            var o = context.Orders.Where(o => o.CustomerId == 1).ToQueryString();
        }
    }

    public class SampleContextFactory : IDesignTimeDbContextFactory<SampleContext>
    {
        public SampleContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsetting.json")
                                .Build();

            var optBuilder = new DbContextOptionsBuilder<SampleContext>();
            optBuilder.UseNpgsql(config.GetConnectionString("Postgresql"));

            return new SampleContext(optBuilder.Options);
        }
    }
}