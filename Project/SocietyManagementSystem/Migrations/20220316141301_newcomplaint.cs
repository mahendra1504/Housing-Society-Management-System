using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocietyManagementSystem.Migrations
{
    public partial class newcomplaint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    complaint_subject = table.Column<string>(nullable: true),
                    complaint_detail = table.Column<string>(nullable: true),
                    Member_mail = table.Column<string>(nullable: true),
                    house_no = table.Column<int>(nullable: false),
                    complaint_date = table.Column<DateTime>(nullable: false),
                    complaint_status = table.Column<string>(nullable: true),
                    solution = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaint");
        }
    }
}
