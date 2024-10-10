using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service_Project.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrierConfigurations_Carriers_CarriersID",
                table: "CarrierConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_CarrierConfigurations_CarriersID",
                table: "CarrierConfigurations");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CarriersID",
                table: "CarrierConfigurations");

            migrationBuilder.AlterColumn<string>(
                name: "carrierName",
                table: "Carriers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "carrierName",
                table: "Carriers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "CarriersID",
                table: "CarrierConfigurations",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CarrierConfigurations_Carriers_CarriersID",
                table: "CarrierConfigurations",
                column: "CarriersID",
                principalTable: "Carriers",
                principalColumn: "ID");
        }
    }
}
