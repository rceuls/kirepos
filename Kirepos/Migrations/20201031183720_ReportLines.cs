using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kirepos.Migrations
{
    public partial class ReportLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Reports",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Reports",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "ReportLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 1024, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 1024, nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true),
                    ReportId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Responsible = table.Column<string>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportLine_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportLine_ReportId",
                table: "ReportLine",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportLine");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Reports");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Reports",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
