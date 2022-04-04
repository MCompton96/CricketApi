using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CricketAPI.Migrations
{
    public partial class wicketsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OutMethod",
                table: "Battings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FieldingStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Catches = table.Column<int>(type: "int", nullable: false),
                    RunOuts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldingStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldingStats_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BowlingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wickets_Bowlings_BowlingId",
                        column: x => x.BowlingId,
                        principalTable: "Bowlings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldingStats_GameId",
                table: "FieldingStats",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wickets_BowlingId",
                table: "Wickets",
                column: "BowlingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldingStats");

            migrationBuilder.DropTable(
                name: "Wickets");

            migrationBuilder.DropColumn(
                name: "OutMethod",
                table: "Battings");
        }
    }
}
