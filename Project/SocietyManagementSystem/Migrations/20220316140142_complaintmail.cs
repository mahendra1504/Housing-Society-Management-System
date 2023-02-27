using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocietyManagementSystem.Migrations
{
    public partial class complaintmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    House_no = table.Column<int>(type: "int", nullable: false),
                    compalint_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    compalint_detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    compalint_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    compalint_subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owner_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    solution = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.Id);
                });
        }
    }
}
