﻿// <auto-generated />
using System;
using AdventureBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdVentureBook.Migrations
{
    [DbContext(typeof(AdventureContext))]
    [Migration("20200728020045_Campaign.cs")]
    partial class Campaigncs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AdventureBook.Models.AdventureImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CurrentDate");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Location");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AdventureImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Nice Place",
                            ImageUrl = "http://localhost:3000/img/image5.jpg",
                            Location = "Japan",
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            CurrentDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = " Cool !!",
                            ImageUrl = "http://localhost:3000/img/image4.jpg",
                            Location = "Seattle",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            CurrentDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = " Great place",
                            ImageUrl = "http://localhost:3000/img/image6.jpg",
                            Location = "Bellevue",
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            CurrentDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = " Nice beach",
                            ImageUrl = "http://localhost:3000/img/image8.jpg",
                            Location = "Tulom",
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            CurrentDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = " Splendid ",
                            ImageUrl = "http://localhost:3000/img/image1.jpg",
                            Location = "Mt Rainer",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("AdventureBook.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdventureImageId");

                    b.Property<string>("Comments");

                    b.Property<double>("Rating");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AdventureImageId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdventureImageId = 1,
                            Comments = "Great!",
                            Rating = 3.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            AdventureImageId = 2,
                            Comments = "Wonderfull",
                            Rating = 4.0,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("AdventureBook.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Token");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Nitun",
                            LastName = "Datta",
                            Password = "test",
                            Username = "test"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Purba",
                            LastName = "Devi",
                            Password = "test1",
                            Username = "test1"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Jon",
                            LastName = "Devi",
                            Password = "demo",
                            Username = "demo"
                        });
                });

            modelBuilder.Entity("AdventureBook.Models.AdventureImage", b =>
                {
                    b.HasOne("AdventureBook.Models.User", "User")
                        .WithMany("AdventureImages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdventureBook.Models.Comment", b =>
                {
                    b.HasOne("AdventureBook.Models.AdventureImage", "AdventureImage")
                        .WithMany("Comments")
                        .HasForeignKey("AdventureImageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AdventureBook.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
