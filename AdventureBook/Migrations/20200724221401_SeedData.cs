using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdVentureBook.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDate",
                table: "AdventureImages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AdventureImages",
                columns: new[] { "Id", "CurrentDate", "Description", "ImageUrl", "Location" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice Place", "abc", "Japan" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " Cool !!", "xyz", "Seattle" }
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
                table: "Comments",
                columns: new[] { "Id", "AdventureImageId", "Comments", "Rating", "UserId" },
                values: new object[] { 1, 1, "Great!", 3.0, 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AdventureImageId", "Comments", "Rating", "UserId" },
                values: new object[] { 2, 2, "Wonderfull", 4.0, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "CurrentDate",
                table: "AdventureImages");
        }
    }
}
