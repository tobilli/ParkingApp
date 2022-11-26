using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingApp.Data.Migrations
{
    public partial class Space : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "spaces",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Local_Govt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    No_Slot = table.Column<int>(type: "int", nullable: false),
                    Open_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Close_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Daily_Parking = table.Column<decimal>(type: "Money", nullable: false),
                    Weekly_Parking = table.Column<decimal>(type: "Money", nullable: false),
                    Monthly_Parking = table.Column<decimal>(type: "Money", nullable: false),
                    Parking_Desc = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spaces", x => x.id);
                    table.ForeignKey(
                        name: "FK_spaces_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_spaces_UserId",
                table: "spaces",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spaces");
        }
    }
}
