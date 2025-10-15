using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PoultryFarmSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedBirdTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "BatchId", "BirdNumber", "CageId", "LastHealthCheck", "Status", "Type", "Weight" },
                values: new object[,]
                {
                    { 1, 1, "CHKN-001", 1, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Курица", 2.5m },
                    { 2, 1, "CHKN-002", 1, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Курица", 2.3m },
                    { 3, 1, "CHKN-003", 1, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Больна", "Курица", 2.7m },
                    { 4, 2, "DUCK-001", 2, new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Утка", 3.2m },
                    { 5, 2, "DUCK-002", 2, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лечение", "Утка", 3m },
                    { 6, 2, "DUCK-003", 2, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Утка", 3.5m },
                    { 7, 3, "TURK-001", 3, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Карантин", "Индейка", 8.2m },
                    { 8, 3, "TURK-002", 3, new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Индейка", 7.8m },
                    { 9, 3, "TURK-003", 3, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Индейка", 9.1m },
                    { 10, 4, "GOOS-001", 4, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Гусь", 5.3m },
                    { 11, 4, "GOOS-002", 4, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Больна", "Гусь", 4.9m },
                    { 12, 4, "GOOS-003", 4, new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Гусь", 5.8m },
                    { 13, 5, "QUAIL-001", 5, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Перепел", 0.15m },
                    { 14, 5, "QUAIL-002", 5, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Перепел", 0.18m },
                    { 15, 5, "QUAIL-003", 5, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Умерла", "Перепел", 0.16m },
                    { 16, 6, "CHKN-101", 6, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Курица", 2.8m },
                    { 17, 6, "CHKN-102", 6, new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Курица", 2.6m },
                    { 18, 6, "CHKN-103", 6, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лечение", "Курица", 2.9m },
                    { 19, 7, "DUCK-101", 7, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Утка", 3.3m },
                    { 20, 7, "DUCK-102", 7, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Карантин", "Утка", 3.1m },
                    { 21, 7, "DUCK-103", 7, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Активна", "Утка", 3.4m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
