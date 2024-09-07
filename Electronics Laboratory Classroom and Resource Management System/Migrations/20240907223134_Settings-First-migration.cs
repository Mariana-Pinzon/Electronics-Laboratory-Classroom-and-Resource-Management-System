using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class SettingsFirstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Modification_date",
                table: "reservations_history",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "reservations_equipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "End_time",
                table: "reservations",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "Reservation_date",
                table: "reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Start_time",
                table: "reservations",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "laboratories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Laboratory_Num",
                table: "laboratories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Available_quantity",
                table: "inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Last_update",
                table: "inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Total_quantity",
                table: "inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Acquisition_date",
                table: "equipments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modification_date",
                table: "reservations_history");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "reservations_equipment");

            migrationBuilder.DropColumn(
                name: "End_time",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "Reservation_date",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "Start_time",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "laboratories");

            migrationBuilder.DropColumn(
                name: "Laboratory_Num",
                table: "laboratories");

            migrationBuilder.DropColumn(
                name: "Available_quantity",
                table: "inventories");

            migrationBuilder.DropColumn(
                name: "Last_update",
                table: "inventories");

            migrationBuilder.DropColumn(
                name: "Total_quantity",
                table: "inventories");

            migrationBuilder.DropColumn(
                name: "Acquisition_date",
                table: "equipments");
        }
    }
}
