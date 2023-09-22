using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuvLane.Data.Migrations
{
    /// <inheritdoc />
    public partial class Match : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MatchUserOneId",
                table: "Profile",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profile_MatchUserOneId",
                table: "Profile",
                column: "MatchUserOneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Match_MatchUserOneId",
                table: "Profile",
                column: "MatchUserOneId",
                principalTable: "Match",
                principalColumn: "UserOneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Match_MatchUserOneId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_MatchUserOneId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "MatchUserOneId",
                table: "Profile");
        }
    }
}
