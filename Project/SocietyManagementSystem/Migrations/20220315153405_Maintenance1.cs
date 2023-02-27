using Microsoft.EntityFrameworkCore.Migrations;

namespace SocietyManagementSystem.Migrations
{
    public partial class Maintenance1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Maintenance",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Maintenance");
        }
    }
}
