using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LF.Data.Models
{
    public class LFDbContextFactory : IDesignTimeDbContextFactory<LFDbContext>
    {
        public LFDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LFDbContext>();

            // TODO: Settings from appsettings
            builder.UseSqlite("Data Source=LF.db;");

            return new LFDbContext(builder.Options);
        }
    }
}