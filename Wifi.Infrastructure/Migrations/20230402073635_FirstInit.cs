using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wifi.Infrastructure.Migrations
{
    public partial class FirstInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cleaning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nfc_Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TimeOfCleaning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cleaning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cleaning_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cleaning_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "peter@mighty-putztrupp.at", "test1234" },
                    { 2, "martina@mighty-putztrupp.at", "test1234" },
                    { 3, "orhan@mighty-putztrupp.at", "test1234" },
                    { 4, "benjamin@mighty-putztrupp.at", "test1234" },
                    { 5, "milos@mighty-putztrupp.at", "test1234" },
                    { 6, "martind@mighty-putztrupp.at", "test1234" },
                    { 7, "jan@mighty-putztrupp.at", "test1234" },
                    { 8, "romana@mighty-putztrupp.at", "test1234" },
                    { 9, "frederik@mighty-putztrupp.at", "test1234" },
                    { 10, "romed@mighty-putztrupp.at", "test1234" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cleaning_EmployeeId",
                table: "Cleaning",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cleaning_RoomId",
                table: "Cleaning",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cleaning");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
