using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class settings2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reservation_ID",
                table: "reservations_equipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reservations_equipment_Reservation_ID",
                table: "reservations_equipment",
                column: "Reservation_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_equipment_reservations_Reservation_ID",
                table: "reservations_equipment",
                column: "Reservation_ID",
                principalTable: "reservations",
                principalColumn: "Reservation_ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_equipment_reservations_Reservation_ID",
                table: "reservations_equipment");

            migrationBuilder.DropIndex(
                name: "IX_reservations_equipment_Reservation_ID",
                table: "reservations_equipment");

            migrationBuilder.DropColumn(
                name: "Reservation_ID",
                table: "reservations_equipment");
        }
    }
}
