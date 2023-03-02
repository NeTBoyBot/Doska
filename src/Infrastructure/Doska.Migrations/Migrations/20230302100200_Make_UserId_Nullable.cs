using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doska.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Make_UserId_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteAd",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteAd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteAd_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteAd_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteAd_AdId",
                table: "FavoriteAd",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteAd_UserId",
                table: "FavoriteAd",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteAd");
        }
    }
}
