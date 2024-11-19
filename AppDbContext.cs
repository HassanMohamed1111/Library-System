using Microsoft.EntityFrameworkCore;
using Quiz_2.Models;

namespace Quiz_2
{
    public class AppDbContext : DbContext
    {
       public DbSet<Book> books {  get; set; }
       public DbSet<Author>Authors { get; set; }
       public DbSet<Genre> genres { get; set; } 
       public DbSet<IdentityCard>IdentityCards { get; set; }
       public DbSet<CrediteCard>CrediteCards { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
