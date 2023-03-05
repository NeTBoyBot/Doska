using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doska.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Add_KodBase64_To_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KodBase64",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KodBase64",
                table: "User");
        }
    }
}
