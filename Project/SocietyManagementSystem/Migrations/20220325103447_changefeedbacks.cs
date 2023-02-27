using Microsoft.EntityFrameworkCore.Migrations;

namespace SocietyManagementSystem.Migrations
{
    public partial class changefeedbacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "owner_id",
                table: "Feedback");

            migrationBuilder.AddColumn<int>(
                name: "houseno",
                table: "Feedback",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "owner_email",
                table: "Feedback",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "houseno",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "owner_email",
                table: "Feedback");

            migrationBuilder.AddColumn<string>(
                name: "owner_id",
                table: "Feedback",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
