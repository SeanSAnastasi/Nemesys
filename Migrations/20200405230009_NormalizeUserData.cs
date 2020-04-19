using Microsoft.EntityFrameworkCore.Migrations;

namespace Nemesys.Migrations
{
    public partial class NormalizeUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reporter");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Reporter");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Reporter");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Investigator");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Investigator");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Investigator");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reporter",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Investigator",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reporter_UserId",
                table: "Reporter",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigator_UserId",
                table: "Investigator",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investigator_User_UserId",
                table: "Investigator",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reporter_User_UserId",
                table: "Reporter",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigator_User_UserId",
                table: "Investigator");

            migrationBuilder.DropForeignKey(
                name: "FK_Reporter_User_UserId",
                table: "Reporter");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Reporter_UserId",
                table: "Reporter");

            migrationBuilder.DropIndex(
                name: "IX_Investigator_UserId",
                table: "Investigator");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reporter");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Investigator");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reporter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Reporter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Reporter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Investigator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Investigator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Investigator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
