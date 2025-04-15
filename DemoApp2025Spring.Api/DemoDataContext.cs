using Microsoft.EntityFrameworkCore;

namespace DemoApp2025Spring.Api
{
    public class DemoDataContext : DbContext
    {
        public DemoDataContext(DbContextOptions options) 
            :base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; }
    }
}
