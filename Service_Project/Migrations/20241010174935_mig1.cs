using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service_Project.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carrierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carrierIsActive = table.Column<bool>(type: "bit", nullable: false),
                    carrierPlusDesiCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carrierID = table.Column<int>(type: "int", nullable: false),
                    orderDesi = table.Column<int>(type: "int", nullable: false),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    orderCarrierCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarrierConfigurations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carrierID = table.Column<int>(type: "int", nullable: false),
                    carrierMaxDesi = table.Column<int>(type: "int", nullable: false),
                    carrierMinDesi = table.Column<int>(type: "int", nullable: false),
                    carrierCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarriersID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierConfigurations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarrierConfigurations_Carriers_CarriersID",
                        column: x => x.CarriersID,
                        principalTable: "Carriers",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "carrierID", "orderCarrierCost", "orderDate", "orderDesi" },
                values: new object[] { 1, 0, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "carrierID", "orderCarrierCost", "orderDate", "orderDesi" },
                values: new object[] { 2, 0, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "carrierID", "orderCarrierCost", "orderDate", "orderDesi" },
                values: new object[] { 3, 0, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30 });

            migrationBuilder.CreateIndex(
                name: "IX_CarrierConfigurations_CarriersID",
                table: "CarrierConfigurations",
                column: "CarriersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrierConfigurations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Carriers");
        }
    }
}
