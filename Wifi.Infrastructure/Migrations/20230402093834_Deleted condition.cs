using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wifi.Infrastructure.Migrations
{
    public partial class Deletedcondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Cleaning");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Condition",
                table: "Cleaning",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
