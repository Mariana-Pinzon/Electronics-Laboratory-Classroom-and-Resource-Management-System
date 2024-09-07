using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "laboratories",
                columns: table => new
                {
                    Laboratory_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laboratories", x => x.Laboratory_ID);
                });

            migrationBuilder.CreateTable(
                name: "status_equipments",
                columns: table => new
                {
                    StatusE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status_equipments", x => x.StatusE_ID);
                });

            migrationBuilder.CreateTable(
                name: "status_reservations",
                columns: table => new
                {
                    StatusR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status_reservations", x => x.StatusR_ID);
                });

            migrationBuilder.CreateTable(
                name: "user_types",
                columns: table => new
                {
                    User_Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_types", x => x.User_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "equipments",
                columns: table => new
                {
                    Equipment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_EquipmentStatusE_ID = table.Column<int>(type: "int", nullable: false),
                    Laboratory_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipments", x => x.Equipment_ID);
                    table.ForeignKey(
                        name: "FK_equipments_laboratories_Laboratory_ID",
                        column: x => x.Laboratory_ID,
                        principalTable: "laboratories",
                        principalColumn: "Laboratory_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipments_status_equipments_Status_EquipmentStatusE_ID",
                        column: x => x.Status_EquipmentStatusE_ID,
                        principalTable: "status_equipments",
                        principalColumn: "StatusE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Type_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_users_user_types_User_Type_ID",
                        column: x => x.User_Type_ID,
                        principalTable: "user_types",
                        principalColumn: "User_Type_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventories",
                columns: table => new
                {
                    Inventory_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment_ID = table.Column<int>(type: "int", nullable: false),
                    Laboratory_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventories", x => x.Inventory_ID);
                    table.ForeignKey(
                        name: "FK_inventories_equipments_Equipment_ID",
                        column: x => x.Equipment_ID,
                        principalTable: "equipments",
                        principalColumn: "Equipment_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventories_laboratories_Laboratory_ID",
                        column: x => x.Laboratory_ID,
                        principalTable: "laboratories",
                        principalColumn: "Laboratory_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reservations_equipment",
                columns: table => new
                {
                    ReservationE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations_equipment", x => x.ReservationE_ID);
                    table.ForeignKey(
                        name: "FK_reservations_equipment_equipments_Equipment_ID",
                        column: x => x.Equipment_ID,
                        principalTable: "equipments",
                        principalColumn: "Equipment_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    Reservation_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Laboratory_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.Reservation_ID);
                    table.ForeignKey(
                        name: "FK_reservations_laboratories_Laboratory_ID",
                        column: x => x.Laboratory_ID,
                        principalTable: "laboratories",
                        principalColumn: "Laboratory_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservations_history",
                columns: table => new
                {
                    History_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reservation_ID = table.Column<int>(type: "int", nullable: false),
                    Status_ReservationStatusR_ID = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_equipments_Laboratory_ID",
                table: "equipments",
                column: "Laboratory_ID");

            migrationBuilder.CreateIndex(
                name: "IX_equipments_Status_EquipmentStatusE_ID",
                table: "equipments",
                column: "Status_EquipmentStatusE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_inventories_Equipment_ID",
                table: "inventories",
                column: "Equipment_ID");

            migrationBuilder.CreateIndex(
                name: "IX_inventories_Laboratory_ID",
                table: "inventories",
                column: "Laboratory_ID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_Laboratory_ID",
                table: "reservations",
                column: "Laboratory_ID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_User_ID",
                table: "reservations",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_equipment_Equipment_ID",
                table: "reservations_equipment",
                column: "Equipment_ID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_history_Reservation_ID",
                table: "reservations_history",
                column: "Reservation_ID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_history_Status_ReservationStatusR_ID",
                table: "reservations_history",
                column: "Status_ReservationStatusR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_users_User_Type_ID",
                table: "users",
                column: "User_Type_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventories");

            migrationBuilder.DropTable(
                name: "reservations_equipment");

            migrationBuilder.DropTable(
                name: "reservations_history");

            migrationBuilder.DropTable(
                name: "equipments");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "status_reservations");

            migrationBuilder.DropTable(
                name: "status_equipments");

            migrationBuilder.DropTable(
                name: "laboratories");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "user_types");
        }
    }
}
