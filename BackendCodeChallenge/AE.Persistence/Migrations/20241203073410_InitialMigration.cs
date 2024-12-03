using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AE.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Velocity = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipUser",
                columns: table => new
                {
                    ShipsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipUser", x => new { x.ShipsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ShipUser_Ships_ShipsId",
                        column: x => x.ShipsId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ports",
                columns: new[] { "Id", "CreatedAt", "Latitude", "Longitude", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6029), 31.230399999999999, 121.47369999999999, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6040), "Port of Shanghai" },
                    { 2, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6042), 1.3521000000000001, 103.8198, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6043), "Port of Singapore" },
                    { 3, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6044), 29.868300000000001, 121.544, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6045), "Port of Ningbo-Zhoushan" },
                    { 4, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6046), 22.543099999999999, 114.0579, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6047), "Port of Shenzhen" },
                    { 5, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6048), 23.129100000000001, 113.26439999999999, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6049), "Port of Guangzhou" },
                    { 6, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6050), 35.179600000000001, 129.07560000000001, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6051), "Port of Busan" },
                    { 7, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6052), 22.319299999999998, 114.1694, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6053), "Port of Hong Kong" },
                    { 8, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6054), 36.067100000000003, 120.3826, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6055), "Port of Qingdao" },
                    { 9, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6056), 39.343400000000003, 117.3616, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6057), "Port of Tianjin" },
                    { 10, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6058), 51.922499999999999, 4.4791999999999996, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6059), "Port of Rotterdam" },
                    { 11, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6060), 25.067399999999999, 55.1372, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6061), "Port of Jebel Ali" },
                    { 12, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6062), 53.551099999999998, 9.9937000000000005, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6062), "Port of Hamburg" },
                    { 13, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6064), 51.260199999999998, 4.4028, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6065), "Port of Antwerp" },
                    { 14, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6066), 33.740499999999997, -118.2727, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6067), "Port of Los Angeles" },
                    { 15, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6068), 33.770099999999999, -118.19370000000001, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6069), "Port of Long Beach" },
                    { 16, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6070), 1.3622000000000001, 103.56829999999999, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6070), "Port of Tanjung Pelepas" },
                    { 17, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6072), 22.627300000000002, 120.3014, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6072), "Port of Kaohsiung" },
                    { 18, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6073), 51.963999999999999, 1.3513999999999999, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6074), "Port of Felixstowe" },
                    { 19, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6075), 36.140799999999999, -5.4561999999999999, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6076), "Port of Algeciras" },
                    { 20, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6077), 35.4437, 139.63800000000001, new DateTime(2024, 12, 3, 14, 34, 10, 593, DateTimeKind.Local).AddTicks(6078), "Port of Yokohama" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShipUser_UsersId",
                table: "ShipUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "ShipUser");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
