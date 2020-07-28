using Microsoft.EntityFrameworkCore;

namespace l2l.Data.Model
{
    public class L2LDbContext : DbContext
    {
        public L2LDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}