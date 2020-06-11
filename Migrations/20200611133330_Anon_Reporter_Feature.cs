using Microsoft.EntityFrameworkCore.Migrations;

namespace Nemesys.Migrations
{
    public partial class Anon_Reporter_Feature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_Reporter_ReporterId",
                table: "Report");

            migrationBuilder.AlterColumn<int>(
                name: "ReporterId",
                table: "Report",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Reporter_ReporterId",
                table: "Report",
                column: "ReporterId",
                principalTable: "Reporter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_Reporter_ReporterId",
                table: "Report");

            migrationBuilder.AlterColumn<int>(
                name: "ReporterId",
                table: "Report",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Reporter_ReporterId",
                table: "Report",
                column: "ReporterId",
                principalTable: "Reporter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
