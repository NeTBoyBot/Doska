using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doska.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql_category = $"INSERT INTO public.\"Category\" (\"Id\", \"Name\") VALUES('{Guid.NewGuid()}', 'Товары для животных')," +
            $"('{Guid.NewGuid()}', 'Хобби и отдых')," +
            $"('{Guid.NewGuid()}', 'Красота и здороье'), " +
            $"('{Guid.NewGuid()}', 'Недвижимость')" +
            $"('{Guid.NewGuid()}', 'Электроника')," +
            $"('{Guid.NewGuid()}', 'Одежда')," +
            $"('{Guid.NewGuid()}', 'Товары для детей'),";
            migrationBuilder.Sql(sql_category);

            

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
