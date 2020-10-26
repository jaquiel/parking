using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking.Migrations
{
    public partial class NewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ExtraHourPrice",
                table: "PriceTable",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraHourPrice",
                table: "PriceTable");
        }
    }
}
