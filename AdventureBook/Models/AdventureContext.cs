using Microsoft.EntityFrameworkCore;

namespace AdventureBook.Models
{
  public class AdventureContext : DbContext
  {
    public AdventureContext(DbContextOptions<AdventureContext> options)
        : base(options)
    {
    }


  }
}