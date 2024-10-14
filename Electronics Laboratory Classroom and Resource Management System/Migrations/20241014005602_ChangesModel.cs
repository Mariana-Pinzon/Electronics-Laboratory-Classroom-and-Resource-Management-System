using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class ChangesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Reservation_EquipmentReservationE_ID",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reservations_Reservation_EquipmentReservationE_ID",
                table: "reservations",
                column: "Reservation_EquipmentReservationE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_reservations_equipment_Reservation_EquipmentReservationE_ID",
                table: "reservations",
                column: "Reservation_EquipmentReservationE_ID",
                principalTable: "reservations_equipment",
                principalColumn: "ReservationE_ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_reservations_equipment_Reservation_EquipmentReservationE_ID",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "IX_reservations_Reservation_EquipmentReservationE_ID",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "Reservation_EquipmentReservationE_ID",
                table: "reservations");

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
    }
}
