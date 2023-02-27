using Microsoft.EntityFrameworkCore.Migrations;

namespace SocietyManagementSystem.Migrations
{
    public partial class Maintenance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_name = table.Column<string>(nullable: true),
                    house_no = table.Column<int>(nullable: false),
                    water_charge = table.Column<int>(nullable: false),
                    electricity_charge = table.Column<int>(nullable: false),
                    Parking_charge = table.Column<int>(nullable: false),
                    service_charge = table.Column<int>(nullable: false),
                    housetype_charge = table.Column<int>(nullable: false),
                    Total_Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maintenance");
        }
    }
}
