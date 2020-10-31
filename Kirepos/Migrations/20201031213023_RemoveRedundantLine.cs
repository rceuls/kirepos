using Microsoft.EntityFrameworkCore.Migrations;

namespace Kirepos.Migrations
{
    public partial class RemoveRedundantLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Reports");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Reports",
                type: "longtext",
                nullable: false,
                defaultValue: "");
        }
    }
}
