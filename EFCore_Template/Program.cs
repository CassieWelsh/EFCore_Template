using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EFCore_Template
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p = new SampleContextFactory();

            using var context = p.CreateDbContext(args);
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