using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdVentureBook.Migrations
{
    public partial class clickcomm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClickCommisions",
                columns: table => new
                {
                    ClickCommisionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdventureImageId = table.Column<int>(nullable: false),
                    CampaignId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ClickDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClickCommisions", x => x.ClickCommisionId);
                    table.ForeignKey(
                        name: "FK_ClickCommisions_AdventureImages_AdventureImageId",
                        column: x => x.AdventureImageId,
                        principalTable: "AdventureImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClickCommisions_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClickCommisions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClickCommisions",
                columns: new[] { "ClickCommisionId", "AdventureImageId", "CampaignId", "ClickDate", "UserId" },
                values: new object[] { 1, 23, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ClickCommisions_AdventureImageId",
                table: "ClickCommisions",
                column: "AdventureImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ClickCommisions_CampaignId",
                table: "ClickCommisions",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_ClickCommisions_UserId",
                table: "ClickCommisions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClickCommisions");
        }
    }
}
