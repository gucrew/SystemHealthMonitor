using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemHealthMonitorServer.Migrations
{
    public partial class _201812130910 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportInformation_Reports_ReportId",
                table: "ReportInformation");

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "ReportInformation",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportInformation_Reports_ReportId",
                table: "ReportInformation",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportInformation_Reports_ReportId",
                table: "ReportInformation");

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "ReportInformation",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ReportInformation_Reports_ReportId",
                table: "ReportInformation",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
