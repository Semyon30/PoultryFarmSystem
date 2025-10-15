using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PoultryFarmSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsArrived = table.Column<bool>(type: "bit", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    LastCleaning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastMaintenance = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirdNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    LastHealthCheck = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    CageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Birds_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Birds_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    CageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vaccinations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Diseases = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SpecialNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    BirdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCards_Birds_BirdId",
                        column: x => x.BirdId,
                        principalTable: "Birds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Batches",
                columns: new[] { "Id", "ArrivalDate", "BatchNumber", "Breed", "Count", "HatchDate", "IsArrived", "Source", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "20241115-CHKN-0930", "Ломан Браун", 1000, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Птицефабрика", "Курица" },
                    { 2, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "20241116-DUCK-1430", "Пекинская", 500, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ферма", "Утка" },
                    { 3, null, "20241117-TURK-1100", "Бронзовая", 300, new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Инкубатор", "Индейка" },
                    { 4, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "20241118-GOOS-1600", "Холмогорская", 200, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Локальный", "Гусь" },
                    { 5, new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "20241119-QUAIL-0900", "Японская", 2000, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Собственный", "Перепел" },
                    { 6, null, "20241120-CHKN-1400", "Хайсекс Браун", 800, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Импорт", "Курица" },
                    { 7, new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "20241121-DUCK-1030", "Мускусная", 600, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Птицефабрика", "Утка" }
                });

            migrationBuilder.InsertData(
                table: "Cages",
                columns: new[] { "Id", "Capacity", "LastCleaning", "LastMaintenance", "Number", "Section" },
                values: new object[,]
                {
                    { 1, 50, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "AAA-50", "AAB" },
                    { 2, 75, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "AAC-75", "AAC" },
                    { 3, 100, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "AAD-100", "AAD" },
                    { 4, 60, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "AAE-60", "AAE" },
                    { 5, 120, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABA-120", "ABA" },
                    { 6, 80, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC-80", "ABC" },
                    { 7, 90, new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ACA-90", "ACA" }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "BirthDate", "FirstName", "HireDate", "IsActive", "LastName", "MiddleName", "Phone", "Salary", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Петров", "Сергеевич", "79123456789", 85000m, "Руководитель" },
                    { 2, new DateTime(1990, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мария", new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Сидорова", "Ивановна", "79234567890", 65000m, "Ветеринар" },
                    { 3, new DateTime(1992, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Алексей", new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Кузнецов", null, "79345678901", 35000m, "Уборщик" },
                    { 4, new DateTime(1988, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ольга", new DateTime(2020, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Васильева", "Петровна", "+79456789012", 42000m, "Сборщик" },
                    { 5, new DateTime(1983, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дмитрий", new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Николаев", "Александрович", "+79567890123", 72000m, "Инженер" },
                    { 6, new DateTime(1995, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Екатерина", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Морозова", "Дмитриевна", "+79678901234", 38000m, "Кормильщик" },
                    { 7, new DateTime(1991, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сергей", new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Орлов", "Викторович", "79789012345", 68000m, "Ветеринар" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CageId",
                table: "Assignments",
                column: "CageId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_WorkerId",
                table: "Assignments",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Birds_BatchId",
                table: "Birds",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Birds_CageId",
                table: "Birds",
                column: "CageId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCards_BirdId",
                table: "HealthCards",
                column: "BirdId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "HealthCards");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "Cages");
        }
    }
}
