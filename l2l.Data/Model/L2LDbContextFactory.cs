using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace l2l.Data.Model
{
    public class L2LDbContextFactory : IDesignTimeDbContextFactory<L2LDbContext>
    {
        public L2LDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<L2LDbContext>();
            builder.UseSqlite("Data Source=l2l.db");
            return new L2LDbContext(builder.Options);
        }
    }
}