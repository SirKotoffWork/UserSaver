using Microsoft.EntityFrameworkCore;
using UserSaver.DAL.Model;

namespace UserSaver.DAL.Context
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext()
        {

            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UserSaver");
        }
    }
}
