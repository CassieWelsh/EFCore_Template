using Microsoft.EntityFrameworkCore;

namespace EFCore_Template
{
    internal class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions options) : base(options)
        {
        }
    }
}
