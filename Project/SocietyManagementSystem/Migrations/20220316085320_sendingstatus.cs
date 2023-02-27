using Microsoft.EntityFrameworkCore.Migrations;

namespace SocietyManagementSystem.Migrations
{
    public partial class sendingstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Member_mail",
                table: "Maintenance",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sending_status",
                table: "Maintenance",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Member_mail",
                table: "Maintenance");

            migrationBuilder.DropColumn(
                name: "sending_status",
                table: "Maintenance");
        }
    }
}
