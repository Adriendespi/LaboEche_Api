using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboEchec.Dal.Migrations
{
    public partial class intitdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pwd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    ELO = table.Column<int>(type: "int", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tournaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number_Player_Max = table.Column<int>(type: "int", nullable: false),
                    Number_Player_Min = table.Column<int>(type: "int", nullable: false),
                    Elo_Player_Max = table.Column<int>(type: "int", nullable: false),
                    Elo_Player_Min = table.Column<int>(type: "int", nullable: false),
                    Category_Tournament = table.Column<int>(type: "int", nullable: false),
                    Status_Tournament = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    WomenOnly = table.Column<bool>(type: "bit", nullable: false),
                    Last_Inscription_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembersTournament",
                columns: table => new
                {
                    PlayersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersTournament", x => new { x.PlayersID, x.TournamentsId });
                    table.ForeignKey(
                        name: "FK_MembersTournament_Members_PlayersID",
                        column: x => x.PlayersID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersTournament_tournaments_TournamentsId",
                        column: x => x.TournamentsId,
                        principalTable: "tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_Email",
                table: "Members",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_Name",
                table: "Members",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MembersTournament_TournamentsId",
                table: "MembersTournament",
                column: "TournamentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembersTournament");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "tournaments");
        }
    }
}
