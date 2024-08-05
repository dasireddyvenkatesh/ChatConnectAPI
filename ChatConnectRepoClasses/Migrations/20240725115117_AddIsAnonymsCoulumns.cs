using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatConnectRepoClasses.Migrations
{
    /// <inheritdoc />
    public partial class AddIsAnonymsCoulumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnonymous",
                schema: "ChatConnect",
                table: "Methods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnonymous",
                schema: "ChatConnect",
                table: "Controllers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnonymous",
                schema: "ChatConnect",
                table: "Methods");

            migrationBuilder.DropColumn(
                name: "IsAnonymous",
                schema: "ChatConnect",
                table: "Controllers");
        }
    }
}
