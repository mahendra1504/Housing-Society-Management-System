using Microsoft.EntityFrameworkCore.Migrations;

namespace SocietyManagementSystem.Migrations
{
    public partial class house_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "house_type",
                table: "Registration",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "house_type",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "house_type",
                table: "Registration");

            migrationBuilder.DropColumn(
                name: "house_type",
                table: "AspNetUsers");
        }
    }
}
