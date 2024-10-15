using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Simulator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "levels",
                columns: table => new
                {
                    Level_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScorePerLevel = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_levels", x => x.Level_ID);
                });

            migrationBuilder.CreateTable(
                name: "matches",
                columns: table => new
                {
                    Match_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    PositionX = table.Column<float>(type: "real", nullable: false),
                    PositionY = table.Column<float>(type: "real", nullable: false),
                    PositionZ = table.Column<float>(type: "real", nullable: false),
                    CurrentScore = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matches", x => x.Match_ID);
                    table.ForeignKey(
                        name: "FK_matches_users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchesLevel",
                columns: table => new
                {
                    MatchLevel_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Match_ID = table.Column<int>(type: "int", nullable: false),
                    Level_ID = table.Column<int>(type: "int", nullable: false),
                    PointsEarned = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchesLevel", x => x.MatchLevel_ID);
                    table.ForeignKey(
                        name: "FK_MatchesLevel_levels_Level_ID",
                        column: x => x.Level_ID,
                        principalTable: "levels",
                        principalColumn: "Level_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchesLevel_matches_Match_ID",
                        column: x => x.Match_ID,
                        principalTable: "matches",
                        principalColumn: "Match_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_matches_User_ID",
                table: "matches",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesLevel_Level_ID",
                table: "MatchesLevel",
                column: "Level_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesLevel_Match_ID",
                table: "MatchesLevel",
                column: "Match_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchesLevel");

            migrationBuilder.DropTable(
                name: "levels");

            migrationBuilder.DropTable(
                name: "matches");
        }
    }
}
