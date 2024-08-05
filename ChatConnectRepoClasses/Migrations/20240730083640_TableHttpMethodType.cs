using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatConnectRepoClasses.Migrations
{
    /// <inheritdoc />
    public partial class TableHttpMethodType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HttpTypeId",
                schema: "ChatConnect",
                table: "Methods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HttpMethodType",
                schema: "ChatConnect",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpMethodType", x => x.TypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Methods_HttpTypeId",
                schema: "ChatConnect",
                table: "Methods",
                column: "HttpTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Methods_HttpMethodType_HttpTypeId",
                schema: "ChatConnect",
                table: "Methods",
                column: "HttpTypeId",
                principalSchema: "ChatConnect",
                principalTable: "HttpMethodType",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Methods_HttpMethodType_HttpTypeId",
                schema: "ChatConnect",
                table: "Methods");

            migrationBuilder.DropTable(
                name: "HttpMethodType",
                schema: "ChatConnect");

            migrationBuilder.DropIndex(
                name: "IX_Methods_HttpTypeId",
                schema: "ChatConnect",
                table: "Methods");

            migrationBuilder.DropColumn(
                name: "HttpTypeId",
                schema: "ChatConnect",
                table: "Methods");
        }
    }
}
