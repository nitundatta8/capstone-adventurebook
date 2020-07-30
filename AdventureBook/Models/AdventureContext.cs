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
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<TagProduct> TagProducts { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AdventureImage>()
          .HasData(
            new AdventureImage
            {
              Id = 1,
              ImageUrl = "http://localhost:3000/img/image5.jpg",
              Location = "Japan",
              Description = "Nice Place",
              CurrentDate = new DateTime(),
              UserId = 2
            },

            new AdventureImage
            {
              Id = 2,
              ImageUrl = "http://localhost:3000/img/image4.jpg",
              Location = "Seattle",
              Description = " Cool !!",
              CurrentDate = new DateTime(),
              UserId = 1
            },
            new AdventureImage
            {
              Id = 3,
              ImageUrl = "http://localhost:3000/img/image6.jpg",
              Location = "Bellevue",
              Description = " Great place",
              CurrentDate = new DateTime(),
              UserId = 2
            },
            new AdventureImage
            {
              Id = 4,
              ImageUrl = "http://localhost:3000/img/image8.jpg",
              Location = "Tulom",
              Description = " Nice beach",
              CurrentDate = new DateTime(),
              UserId = 1
            },
            new AdventureImage
            {
              Id = 5,
              ImageUrl = "http://localhost:3000/img/image1.jpg",
              Location = "Mt Rainer",
              Description = " Splendid ",
              CurrentDate = new DateTime(),
              UserId = 1
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

      builder.Entity<Campaign>()
      .HasData(

        new Campaign
        {
          Id = 1,
          Brand = "REI",
          Category = "Sport",
          ProductName = "test",
          ProductUrl = "test",
          StartDate = new DateTime(),
          EndDate = new DateTime(),
          Commission = 0.70
        },
        new Campaign
        {
          Id = 2,
          Brand = "Nike",
          Category = "Sport",
          ProductName = "Shoes",
          ProductUrl = "abc",
          StartDate = new DateTime(),
          EndDate = new DateTime(),
          Commission = 0.50
        }
      );

      builder.Entity<TagProduct>()
     .HasData(

       new TagProduct { Id = 1, XPos = 281, YPos = 39, CampaignId = 1, AdventureImageId = 1 }
     );
    }
  }

}