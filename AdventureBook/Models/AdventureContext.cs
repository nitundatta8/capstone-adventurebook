using Microsoft.EntityFrameworkCore;

namespace AdventureBook.Models
{
  public class AdventureContext : DbContext
  {

    public AdventureContext()
    {
    }

    public AdventureContext(DbContextOptions<AdventureContext> options)
        : base(options)
    {
    }

    public DbSet<Comment> Comments { get; set; }
    public DbSet<AdventureImage> AdventureImages { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {

    }



  }
}