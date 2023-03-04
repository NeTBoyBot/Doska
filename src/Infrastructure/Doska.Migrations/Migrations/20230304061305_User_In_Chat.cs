using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doska.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class User_In_Chat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_User_Id",
                table: "Chat");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_InitializerId",
                table: "Chat",
                column: "InitializerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_User_InitializerId",
                table: "Chat",
                column: "InitializerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_User_InitializerId",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_InitializerId",
                table: "Chat");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_User_Id",
                table: "Chat",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
