using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdVentureBook.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductUrl = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Commission = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdventureImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CurrentDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventureImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdventureImages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    AdventureImageId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AdventureImages_AdventureImageId",
                        column: x => x.AdventureImageId,
                        principalTable: "AdventureImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    XPos = table.Column<int>(nullable: false),
                    YPos = table.Column<int>(nullable: false),
                    CampaignId = table.Column<int>(nullable: false),
                    AdventureImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagProducts_AdventureImages_AdventureImageId",
                        column: x => x.AdventureImageId,
                        principalTable: "AdventureImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagProducts_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "Brand", "Category", "Commission", "EndDate", "ProductName", "ProductUrl", "StartDate" },
                values: new object[,]
                {
                    { 1, "REI", "Sport", 0.69999999999999996, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test", "test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Nike", "Sport", 0.5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shoes", "abc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Token", "Username" },
                values: new object[,]
                {
                    { 1, "Nitun", "Datta", "test", null, "test" },
                    { 2, "Purba", "Devi", "test1", null, "test1" },
                    { 3, "Jon", "Devi", "demo", null, "demo" }
                });

            migrationBuilder.InsertData(
                table: "AdventureImages",
                columns: new[] { "Id", "CurrentDate", "Description", "ImageUrl", "Location", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " Cool !!", "http://localhost:3000/img/image4.jpg", "Seattle", 1 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " Nice beach", "http://localhost:3000/img/image8.jpg", "Tulom", 1 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " Splendid ", "http://localhost:3000/img/image1.jpg", "Mt Rainer", 1 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice Place", "http://localhost:3000/img/image5.jpg", "Japan", 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " Great place", "http://localhost:3000/img/image6.jpg", "Bellevue", 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AdventureImageId", "Comments", "Rating", "UserId" },
                values: new object[] { 2, 2, "Wonderfull", 4.0, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AdventureImageId", "Comments", "Rating", "UserId" },
                values: new object[] { 1, 1, "Great!", 3.0, 1 });

            migrationBuilder.InsertData(
                table: "TagProducts",
                columns: new[] { "Id", "AdventureImageId", "CampaignId", "XPos", "YPos" },
                values: new object[] { 1, 1, 1, 281, 39 });

            migrationBuilder.CreateIndex(
                name: "IX_AdventureImages_UserId",
                table: "AdventureImages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AdventureImageId",
                table: "Comments",
                column: "AdventureImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TagProducts_AdventureImageId",
                table: "TagProducts",
                column: "AdventureImageId");

            migrationBuilder.CreateIndex(
                name: "IX_TagProducts_CampaignId",
                table: "TagProducts",
                column: "CampaignId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "TagProducts");

            migrationBuilder.DropTable(
                name: "AdventureImages");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
