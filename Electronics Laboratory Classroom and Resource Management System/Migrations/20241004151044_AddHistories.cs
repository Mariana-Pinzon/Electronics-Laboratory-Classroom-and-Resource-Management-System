using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddHistories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modification_date",
                table: "reservations_history");

            migrationBuilder.CreateTable(
                name: "inventories_history",
                columns: table => new
                {
                    Inventory_History_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inventory_ID = table.Column<int>(type: "int", nullable: false),
                    Equipment_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available_quantity = table.Column<int>(type: "int", nullable: false),
                    Total_quantity = table.Column<int>(type: "int", nullable: false),
                    Last_update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Laboratory_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventories_history", x => x.Inventory_History_ID);
                });

            migrationBuilder.CreateTable(
                name: "status_equipments_history",
                columns: table => new
                {
                    Status_Equipment_History_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusE_ID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status_equipments_history", x => x.Status_Equipment_History_ID);
                });

            migrationBuilder.CreateTable(
                name: "status_reservations_history",
                columns: table => new
                {
                    Status_Reservation_History_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusR_ID = table.Column<int>(type: "int", nullable: false),
                    StatusR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status_reservations_history", x => x.Status_Reservation_History_ID);
                });

            migrationBuilder.CreateTable(
                name: "users_history",
                columns: table => new
                {
                    User_History_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Type_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_history", x => x.User_History_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventories_history");

            migrationBuilder.DropTable(
                name: "status_equipments_history");

            migrationBuilder.DropTable(
                name: "status_reservations_history");

            migrationBuilder.DropTable(
                name: "users_history");

            migrationBuilder.AddColumn<DateTime>(
                name: "Modification_date",
                table: "reservations_history",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
