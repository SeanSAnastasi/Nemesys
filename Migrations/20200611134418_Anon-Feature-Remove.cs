using Microsoft.EntityFrameworkCore.Migrations;

namespace Nemesys.Migrations
{
    public partial class AnonFeatureRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_Reporter_ReporterId",
                table: "Report");

            migrationBuilder.AlterColumn<int>(
                name: "ReporterId",
                table: "Report",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Reporter_ReporterId",
                table: "Report",
                column: "ReporterId",
                principalTable: "Reporter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Reporter_ReporterId",
                table: "Report",
                column: "ReporterId",
                principalTable: "Reporter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
