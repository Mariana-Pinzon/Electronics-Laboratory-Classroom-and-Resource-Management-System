using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddUserPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    Permission_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.Permission_ID);
                });

            migrationBuilder.CreateTable(
                name: "user_permissions",
                columns: table => new
                {
                    UserP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Type_ID = table.Column<int>(type: "int", nullable: false),
                    Permission_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_permissions", x => x.UserP_ID);
                    table.ForeignKey(
                        name: "FK_user_permissions_permissions_Permission_ID",
                        column: x => x.Permission_ID,
                        principalTable: "permissions",
                        principalColumn: "Permission_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_permissions_user_types_User_Type_ID",
                        column: x => x.User_Type_ID,
                        principalTable: "user_types",
                        principalColumn: "User_Type_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_permissions_Permission_ID",
                table: "user_permissions",
                column: "Permission_ID");

            migrationBuilder.CreateIndex(
                name: "IX_user_permissions_User_Type_ID",
                table: "user_permissions",
                column: "User_Type_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_permissions");

            migrationBuilder.DropTable(
                name: "permissions");
        }
    }
}
