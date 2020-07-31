using Microsoft.EntityFrameworkCore.Migrations;

namespace AdVentureBook.Migrations
{
    public partial class clickcm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Commission",
                table: "ClickCommisions",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "ClickCommisions",
                keyColumn: "ClickCommisionId",
                keyValue: 1,
                column: "Commission",
                value: 0.01);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Commission",
                table: "ClickCommisions");
        }
    }
}
