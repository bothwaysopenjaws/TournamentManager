using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentManager.DbLib.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pseudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiotId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamIdentifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamIdentifier",
                        column: x => x.TeamIdentifier,
                        principalTable: "Teams",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Encounters",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamAdentifier = table.Column<int>(type: "int", nullable: false),
                    TeamBIdentifier = table.Column<int>(type: "int", nullable: false),
                    Phase = table.Column<int>(type: "int", nullable: false),
                    TournamentIdentifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encounters", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Encounters_Teams_TeamAdentifier",
                        column: x => x.TeamAdentifier,
                        principalTable: "Teams",
                        principalColumn: "Identifier");
                    table.ForeignKey(
                        name: "FK_Encounters_Teams_TeamBIdentifier",
                        column: x => x.TeamBIdentifier,
                        principalTable: "Teams",
                        principalColumn: "Identifier");
                    table.ForeignKey(
                        name: "FK_Encounters_Tournaments_TournamentIdentifier",
                        column: x => x.TournamentIdentifier,
                        principalTable: "Tournaments",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinningTeamIdentifier = table.Column<int>(type: "int", nullable: false),
                    WinningScore = table.Column<int>(type: "int", nullable: false),
                    LoosingScore = table.Column<int>(type: "int", nullable: false),
                    EncounterIdentifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Matches_Encounters_EncounterIdentifier",
                        column: x => x.EncounterIdentifier,
                        principalTable: "Encounters",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_WinningTeamIdentifier",
                        column: x => x.WinningTeamIdentifier,
                        principalTable: "Teams",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Encounters_TeamAdentifier",
                table: "Encounters",
                column: "TeamAdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Encounters_TeamBIdentifier",
                table: "Encounters",
                column: "TeamBIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Encounters_TournamentIdentifier",
                table: "Encounters",
                column: "TournamentIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_EncounterIdentifier",
                table: "Matches",
                column: "EncounterIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinningTeamIdentifier",
                table: "Matches",
                column: "WinningTeamIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamIdentifier",
                table: "Players",
                column: "TeamIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Encounters");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
