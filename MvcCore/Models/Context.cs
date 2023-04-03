using Microsoft.EntityFrameworkCore;


namespace MvcCore.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<CategoryTask> CategoryTask { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
