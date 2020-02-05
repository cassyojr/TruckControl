using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TruckModel",
                columns: table => new
                {
                    TruckModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckModel", x => x.TruckModelId);
                });

            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    TruckId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProductionYear = table.Column<int>(nullable: false),
                    ModelYear = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    TruckModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.TruckId);
                    table.ForeignKey(
                        name: "FK_Truck_TruckModel_TruckModelId",
                        column: x => x.TruckModelId,
                        principalTable: "TruckModel",
                        principalColumn: "TruckModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TruckModel",
                columns: new[] { "TruckModelId", "Name" },
                values: new object[] { 1, "FH" });

            migrationBuilder.InsertData(
                table: "TruckModel",
                columns: new[] { "TruckModelId", "Name" },
                values: new object[] { 2, "FM" });

            migrationBuilder.InsertData(
                table: "Truck",
                columns: new[] { "TruckId", "CreationDate", "ModelYear", "Name", "ProductionYear", "TruckModelId" },
                values: new object[] { 1, new DateTime(2020, 2, 5, 15, 33, 50, 999, DateTimeKind.Local).AddTicks(6047), 2021, "Volvo FH16", 2020, 1 });

            migrationBuilder.InsertData(
                table: "Truck",
                columns: new[] { "TruckId", "CreationDate", "ModelYear", "Name", "ProductionYear", "TruckModelId" },
                values: new object[] { 2, new DateTime(2020, 2, 5, 15, 33, 51, 0, DateTimeKind.Local).AddTicks(750), 2021, "Volvo FH", 2020, 1 });

            migrationBuilder.InsertData(
                table: "Truck",
                columns: new[] { "TruckId", "CreationDate", "ModelYear", "Name", "ProductionYear", "TruckModelId" },
                values: new object[] { 3, new DateTime(2020, 2, 5, 15, 33, 51, 0, DateTimeKind.Local).AddTicks(772), 2021, "Volvo FM", 2020, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Truck_TruckModelId",
                table: "Truck",
                column: "TruckModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Truck");

            migrationBuilder.DropTable(
                name: "TruckModel");
        }
    }
}
