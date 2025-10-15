using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PoultryFarmSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedHealthCardTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HealthCards",
                columns: new[] { "Id", "Allergies", "BirdId", "Diseases", "SpecialNotes", "Vaccinations" },
                values: new object[,]
                {
                    { 1, "Нет", 1, "Нет", "Здоровая птица, регулярные прививки", "Ньюкасл, Гамборо, Марек" },
                    { 2, "Нет", 2, "Легкая простуда в ноябре 2024", "Требуется наблюдение после болезни", "Ньюкасл, Гамборо" },
                    { 3, "Нет", 3, "Респираторная инфекция", "На лечении антибиотиками, изолировать от других птиц", "Ньюкасл" },
                    { 4, "Нет", 4, "Нет", "Отличное здоровье, активная", "Грипп птиц, Холера" },
                    { 5, "Нет", 5, "Травма крыла", "Проходит лечение, ограничить движение", "Грипп птиц" },
                    { 6, "Пыльца", 6, "Нет", "Сезонная аллергия, наблюдать в весенний период", "Грипп птиц, Холера, Сальмонелла" },
                    { 7, "Нет", 7, "Кокцидиоз", "Карантин, инфекционное заболевание", "Ньюкасл, Оспа" },
                    { 8, "Нет", 8, "Нет", "Идеальное здоровье, племенная птица", "Ньюкасл, Оспа, Грипп" },
                    { 9, "Нет", 9, "Нет", "Хорошая физическая форма, быстро набирает вес", "Ньюкасл, Оспа" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HealthCards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HealthCards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HealthCards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HealthCards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HealthCards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HealthCards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HealthCards",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HealthCards",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HealthCards",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
