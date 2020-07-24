using Microsoft.EntityFrameworkCore;

namespace AdventureBook.Models
{
  public class AdventureContext : DbContext
  {
    public AdventureContext(DbContextOptions<AdventureContext> options)
        : base(options)
    {
    }

    public DbSet<AdventureImage> AdventureImages { get; set; }
    public DbSet<Comment> Comments { get; set; }
  }
}