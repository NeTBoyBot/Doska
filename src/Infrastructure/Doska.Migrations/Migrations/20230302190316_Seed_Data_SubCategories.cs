using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doska.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Data_SubCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql_subcategory = $"INSERT INTO public.\"Subcategory\" (\"Id\", \"Name\", \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Медикаменты','d77d1f86-329f-41ff-ab33-87d49944b0f0')," +
            $"('{Guid.NewGuid()}', 'Игрушки','d77d1f86-329f-41ff-ab33-87d49944b0f0')," +
            $"('{Guid.NewGuid()}', 'Одежда','d77d1f86-329f-41ff-ab33-87d49944b0f0')," +
            $"('{Guid.NewGuid()}', 'Питание','d77d1f86-329f-41ff-ab33-87d49944b0f0')," +
            $"('{Guid.NewGuid()}', 'Женская','51205404-6f44-45d7-9efb-488397290ee5')," +
            $"('{Guid.NewGuid()}', 'Мужская','51205404-6f44-45d7-9efb-488397290ee5')," +
            $"('{Guid.NewGuid()}', 'Дом','ba1009db-b701-47b7-b9ee-f50abcc64562')," +
            $"('{Guid.NewGuid()}', 'Квартира','ba1009db-b701-47b7-b9ee-f50abcc64562')," +
            $"('{Guid.NewGuid()}', 'Рыбалка','d925518b-223c-4c4a-950e-55fa3c1b38d8')," +
            $"('{Guid.NewGuid()}', 'Активный спорт','d925518b-223c-4c4a-950e-55fa3c1b38d8')," +
            $"('{Guid.NewGuid()}', 'Музыкальные инструменты','d925518b-223c-4c4a-950e-55fa3c1b38d8')," +
            $"('{Guid.NewGuid()}', 'Косметика','dc1b368f-97b8-4eba-aba0-2719a05424a3')," +
            $"('{Guid.NewGuid()}', 'Косметические инструменты','dc1b368f-97b8-4eba-aba0-2719a05424a3')";
            migrationBuilder.Sql(sql_subcategory);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
