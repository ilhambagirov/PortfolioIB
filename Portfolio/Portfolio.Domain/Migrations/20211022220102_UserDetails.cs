using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Domain.Migrations
{
    public partial class UserDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PersonalDetails");

            migrationBuilder.AddColumn<int>(
                name: "PortfolioUserId",
                table: "PersonalDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_PortfolioUserId",
                table: "PersonalDetails",
                column: "PortfolioUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_Users_PortfolioUserId",
                table: "PersonalDetails",
                column: "PortfolioUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_Users_PortfolioUserId",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_PortfolioUserId",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "PortfolioUserId",
                table: "PersonalDetails");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
