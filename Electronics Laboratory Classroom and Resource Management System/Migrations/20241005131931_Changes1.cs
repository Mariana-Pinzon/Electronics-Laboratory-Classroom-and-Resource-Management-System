using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Changes1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations_history");

            migrationBuilder.DropColumn(
                name: "Total_quantity",
                table: "inventories_history");

            migrationBuilder.DropColumn(
                name: "Total_quantity",
                table: "inventories");

            migrationBuilder.AddColumn<int>(
                name: "Status_ReservationStatusR_ID",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reservations_Status_ReservationStatusR_ID",
                table: "reservations",
                column: "Status_ReservationStatusR_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_status_reservations_Status_ReservationStatusR_ID",
                table: "reservations",
                column: "Status_ReservationStatusR_ID",
                principalTable: "status_reservations",
                principalColumn: "StatusR_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_status_reservations_Status_ReservationStatusR_ID",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "IX_reservations_Status_ReservationStatusR_ID",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "Status_ReservationStatusR_ID",
                table: "reservations");

            migrationBuilder.AddColumn<string>(
                name: "Total_quantity",
                table: "inventories_history",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Total_quantity",
                table: "inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "reservations_history",
                columns: table => new
                {
                    History_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reservation_ID = table.Column<int>(type: "int", nullable: false),
                    Status_ReservationStatusR_ID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations_history", x => x.History_ID);
                    table.ForeignKey(
                        name: "FK_reservations_history_reservations_Reservation_ID",
                        column: x => x.Reservation_ID,
                        principalTable: "reservations",
                        principalColumn: "Reservation_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_history_status_reservations_Status_ReservationStatusR_ID",
                        column: x => x.Status_ReservationStatusR_ID,
                        principalTable: "status_reservations",
                        principalColumn: "StatusR_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservations_history_Reservation_ID",
                table: "reservations_history",
                column: "Reservation_ID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_history_Status_ReservationStatusR_ID",
                table: "reservations_history",
                column: "Status_ReservationStatusR_ID");
        }
    }
}
