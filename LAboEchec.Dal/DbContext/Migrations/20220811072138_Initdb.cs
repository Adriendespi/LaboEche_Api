using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboEchec.DL.Migrations
{
    public partial class Initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_tournaments_TournamentId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_TournamentId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "Round",
                table: "tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Members",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Members",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "MembersTournament",
                columns: table => new
                {
                    PlayersID = table.Column<int>(type: "int", nullable: false),
                    TournamentsId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.DropIndex(
                name: "IX_Members_Email",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_Name",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "Round",
                table: "tournaments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_TournamentId",
                table: "Members",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_tournaments_TournamentId",
                table: "Members",
                column: "TournamentId",
                principalTable: "tournaments",
                principalColumn: "Id");
        }
    }
}
