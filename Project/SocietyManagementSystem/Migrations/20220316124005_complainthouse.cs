using Microsoft.EntityFrameworkCore.Migrations;

namespace SocietyManagementSystem.Migrations
{
    public partial class complainthouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "House_no",
                table: "Complaint",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "House_no",
                table: "Complaint");
        }
    }
}
