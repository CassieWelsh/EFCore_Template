using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_Template
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                                .AddJsonFile("appsetting.json")
                                .Build();

            var optBuilder = new DbContextOptionsBuilder<SampleContext>();
            optBuilder.UseNpgsql(config.GetConnectionString("Postgresql"));

            using var context = new SampleContext(optBuilder.Options);
        }
    }
}