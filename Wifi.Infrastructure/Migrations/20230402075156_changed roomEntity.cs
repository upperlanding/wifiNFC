using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wifi.Infrastructure.Migrations
{
    public partial class changedroomEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nfc_Id",
                table: "Cleaning");

            migrationBuilder.AddColumn<string>(
                name: "Nfc_Id",
                table: "Room",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nfc_Id",
                table: "Room");

            migrationBuilder.AddColumn<string>(
                name: "Nfc_Id",
                table: "Cleaning",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
