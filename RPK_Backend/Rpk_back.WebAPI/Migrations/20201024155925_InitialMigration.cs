using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rpk_back.WebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorItems",
                columns: table => new
                {
                    SensorId = table.Column<Guid>(nullable: false),
                    MeasurementTime = table.Column<DateTime>(nullable: false),
                    SensorValue = table.Column<float>(nullable: false),
                    Localization = table.Column<int>(nullable: false),
                    SensorType = table.Column<int>(nullable: false),
                    SensorGroupGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorItems", x => x.SensorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorItems");
        }
    }
}
