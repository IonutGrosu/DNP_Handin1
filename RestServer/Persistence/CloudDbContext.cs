using Microsoft.EntityFrameworkCore;
using Models;

namespace FileData
{
    public class CloudDbContext : DbContext 
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=hattie.db.elephantsql.com;Port=5432;Database=odmgkale;Username=odmgkale;Password=kgztOVHbt2JP9kbXqNkyqhq4atwZLYmT",
                options => options.UseAdminDatabase("odmgkale"));
        }
    }
}