using Microsoft.EntityFrameworkCore.Migrations;

namespace AdVentureBook.Migrations
{
    public partial class AdventureContextda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Commission",
                value: 0.69999999999999996);

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Commission",
                value: 0.5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Commission",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Commission",
                value: 0.0);
        }
    }
}
