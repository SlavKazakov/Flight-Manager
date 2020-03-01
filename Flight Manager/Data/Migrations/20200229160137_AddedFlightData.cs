using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManager.Data.Migrations
{
    public partial class AddedFlightData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationFrom = table.Column<string>(nullable: true),
                    LocationTo = table.Column<string>(nullable: true),
                    DateOfTakeOf = table.Column<DateTime>(nullable: false),
                    DateOfLanding = table.Column<DateTime>(nullable: false),
                    UniqueNumber = table.Column<int>(nullable: false),
                    PilotName = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    CapacityBusinessClass = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
