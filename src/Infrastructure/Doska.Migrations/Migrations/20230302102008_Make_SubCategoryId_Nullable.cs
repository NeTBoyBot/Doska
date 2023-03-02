using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doska.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Make_SubCategoryId_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Subcategory_SubcategoryId",
                table: "Ad");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubcategoryId",
                table: "Ad",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Subcategory_SubcategoryId",
                table: "Ad",
                column: "SubcategoryId",
                principalTable: "Subcategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Subcategory_SubcategoryId",
                table: "Ad");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubcategoryId",
                table: "Ad",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Subcategory_SubcategoryId",
                table: "Ad",
                column: "SubcategoryId",
                principalTable: "Subcategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
