using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatConnectRepoClasses.Migrations
{
    /// <inheritdoc />
    public partial class CreateLoginAndRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Controllers",
                schema: "ChatConnect",
                columns: table => new
                {
                    ControllerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControllerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controllers", x => x.ControllerId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "ChatConnect",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Methods",
                schema: "ChatConnect",
                columns: table => new
                {
                    MethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ControllerId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.MethodId);
                    table.ForeignKey(
                        name: "FK_Methods_Controllers_ControllerId",
                        column: x => x.ControllerId,
                        principalSchema: "ChatConnect",
                        principalTable: "Controllers",
                        principalColumn: "ControllerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Methods_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "ChatConnect",
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "ChatConnect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "ChatConnect",
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ChatConnect",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Methods_ControllerId",
                schema: "ChatConnect",
                table: "Methods",
                column: "ControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_Methods_RoleId",
                schema: "ChatConnect",
                table: "Methods",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "ChatConnect",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "ChatConnect",
                table: "UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Methods",
                schema: "ChatConnect");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "ChatConnect");

            migrationBuilder.DropTable(
                name: "Controllers",
                schema: "ChatConnect");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "ChatConnect");
        }
    }
}
