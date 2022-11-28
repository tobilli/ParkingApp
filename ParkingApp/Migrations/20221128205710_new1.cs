using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingApp.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_spaces_Spaceid",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_Spaceid",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Spaceid",
                table: "Booking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Spaceid",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Spaceid",
                table: "Booking",
                column: "Spaceid");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_spaces_Spaceid",
                table: "Booking",
                column: "Spaceid",
                principalTable: "spaces",
                principalColumn: "id");
        }
    }
}
