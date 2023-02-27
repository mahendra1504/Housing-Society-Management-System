using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocietyManagementSystem.Migrations
{
    public partial class transaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "house_type",
                table: "Houses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maintenance_id = table.Column<int>(nullable: false),
                    Charge_id = table.Column<int>(nullable: false),
                    transaction_name = table.Column<string>(nullable: true),
                    house_no = table.Column<int>(nullable: false),
                    member_name = table.Column<string>(nullable: true),
                    member_email = table.Column<string>(nullable: true),
                    transaction_amount = table.Column<int>(nullable: false),
                    transaction_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.AlterColumn<int>(
                name: "house_type",
                table: "Houses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
