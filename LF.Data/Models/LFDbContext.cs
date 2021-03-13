using Microsoft.EntityFrameworkCore;

namespace LF.Data.Models
{
    public class LFDbContext : DbContext
    {
        public LFDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
           
    }
}