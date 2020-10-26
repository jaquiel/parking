using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    HourPrice = table.Column<double>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingDrive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LicensePlate = table.Column<string>(nullable: true),
                    ParkedAt = table.Column<DateTime>(nullable: false),
                    DisplacedAt = table.Column<DateTime>(nullable: false),
                    PriceTableID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingDrive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingDrive_PriceTable_PriceTableID",
                        column: x => x.PriceTableID,
                        principalTable: "PriceTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingDrive_PriceTableID",
                table: "ParkingDrive",
                column: "PriceTableID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingDrive");

            migrationBuilder.DropTable(
                name: "PriceTable");
        }
    }
}
