using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdVentureBook.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Token", "Username" },
                values: new object[] { 1, "Nitun", "Datta", "test", null, "test" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Token", "Username" },
                values: new object[] { 2, "Purba", "Devi", "test1", null, "test1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Token", "Username" },
                values: new object[] { 3, "Jon", "Devi", "demo", null, "demo" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdventureImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AdventureImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AdventureImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AdventureImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AdventureImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
