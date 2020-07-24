using Microsoft.EntityFrameworkCore;
using System;

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
      builder.Entity<AdventureImage>()
          .HasData(
            new AdventureImage
            {
              Id = 1,
              ImageUrl = "abc",
              Location = "Japan",
              Description = "Nice Place",
              CurrentDate = new DateTime()
            },

            new AdventureImage
            {
              Id = 2,
              ImageUrl = "xyz",
              Location = "Seattle",
              Description = " Cool !!",
              CurrentDate = new DateTime()
            });

      builder.Entity<Comment>()
          .HasData(
            new Comment { Id = 1, Comments = "Great!", Rating = 3, AdventureImageId = 1, UserId = 1 },
            new Comment { Id = 2, Comments = "Wonderfull", Rating = 4, AdventureImageId = 2, UserId = 2 }

          );
      builder.Entity<User>()
      .HasData(
        new User { Id = 1, FirstName = "Nitun", LastName = "Datta", Username = "test", Password = "test" },
        new User { Id = 2, FirstName = "Purba", LastName = "Devi", Username = "test1", Password = "test1" },
          new User { Id = 3, FirstName = "Jon", LastName = "Devi", Username = "demo", Password = "demo" }


      );
    }


  }
}