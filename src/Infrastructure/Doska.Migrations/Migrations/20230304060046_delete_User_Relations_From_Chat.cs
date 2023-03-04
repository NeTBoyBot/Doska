using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doska.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class delete_User_Relations_From_Chat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_User_ParticipantId",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_ParticipantId",
                table: "Chat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Chat_ParticipantId",
                table: "Chat",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_User_ParticipantId",
                table: "Chat",
                column: "ParticipantId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
