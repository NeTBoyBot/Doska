using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doska.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Delete_Sub_Categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Subcategory_SubcategoryId",
                table: "Ad");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.AddColumn<Guid>(
                name: "ParenCategoryId",
                table: "Category",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SubcategoryId",
                table: "Ad",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "СategoryId",
                table: "Ad",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParenCategoryId",
                table: "Category",
                column: "ParenCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Category_SubcategoryId",
                table: "Ad",
                column: "SubcategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParenCategoryId",
                table: "Category",
                column: "ParenCategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Category_SubcategoryId",
                table: "Ad");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParenCategoryId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_ParenCategoryId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ParenCategoryId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "СategoryId",
                table: "Ad");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubcategoryId",
                table: "Ad",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_CategoryId",
                table: "Subcategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Subcategory_SubcategoryId",
                table: "Ad",
                column: "SubcategoryId",
                principalTable: "Subcategory",
                principalColumn: "Id");
        }
    }
}
