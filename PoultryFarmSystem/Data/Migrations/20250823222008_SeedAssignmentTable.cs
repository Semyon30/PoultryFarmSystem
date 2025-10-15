using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PoultryFarmSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAssignmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "CageId", "CompletedDate", "Description", "EndDate", "Priority", "StartDate", "Status", "Title", "WorkerId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 13, 16, 30, 0, 0, DateTimeKind.Unspecified), "Полная уборка клетки, дезинфекция кормушек и поилок", new DateTime(2024, 11, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), "Средний", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Завершено", "Ежедневная уборка клетки A-50", 3 },
                    { 2, 1, null, "Проведение плановой вакцинации от болезни Ньюкасла", new DateTime(2024, 11, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Высокий", new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Выполняется", "Вакцинация кур в клетке A-50", 2 },
                    { 3, 2, null, "Проверка системы вентиляции и освещения", new DateTime(2024, 11, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "Средний", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Назначено", "Техническое обслуживание клетки B-75", 5 },
                    { 4, 3, new DateTime(2024, 11, 12, 13, 45, 0, 0, DateTimeKind.Unspecified), "Ежедневный сбор и сортировка яиц", new DateTime(2024, 11, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), "Низкий", new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Завершено", "Сбор яиц из клетки C-100", 4 },
                    { 5, 2, new DateTime(2024, 11, 14, 9, 30, 0, 0, DateTimeKind.Unspecified), "Утреннее кормление, проверка качества корма", new DateTime(2024, 11, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Высокий", new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Завершено", "Кормление уток в клетке B-75", 6 },
                    { 6, 1, null, "Осмотр и лечение птицы с признаками заболевания", new DateTime(2024, 11, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), "Критический", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Проверяется", "Лечение больной птицы в клетке A-50", 7 },
                    { 7, 4, null, "Переучет поголовья и оборудования", new DateTime(2024, 11, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), "Средний", new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Назначено", "Плановая инвентаризация клетки D-60", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
