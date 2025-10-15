using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoultryFarmSystem.Models.Entities;
using PoultryFarmSystem.Models.Enums;

namespace PoultryFarmSystem.Data.Configurations;

public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.HasKey(w => w.Id);

        builder.Property(w => w.FirstName)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(w => w.LastName)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(w => w.MiddleName)
            .HasMaxLength(25);

        builder.Property(w => w.Phone)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(w => w.Type)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(w => w.HireDate)
            .IsRequired();

        builder.Property(w => w.Salary)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder.Property(w => w.IsActive)
            .IsRequired();

        builder.HasData(
            new Worker
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Петров",
                MiddleName = "Сергеевич",
                Phone = "79123456789",
                BirthDate = new DateTime(1985, 3, 15),
                Type = WorkerType.Руководитель,
                HireDate = new DateTime(2020, 1, 10),
                Salary = 85000m,
                IsActive = true
            },
            new Worker
            {
                Id = 2,
                FirstName = "Мария",
                LastName = "Сидорова",
                MiddleName = "Ивановна",
                Phone = "79234567890",
                BirthDate = new DateTime(1990, 7, 22),
                Type = WorkerType.Ветеринар,
                HireDate = new DateTime(2021, 5, 18),
                Salary = 65000m,
                IsActive = true
            },
            new Worker
            {
                Id = 3,
                FirstName = "Алексей",
                LastName = "Кузнецов",
                MiddleName = null,
                Phone = "79345678901",
                BirthDate = new DateTime(1992, 11, 5),
                Type = WorkerType.Уборщик,
                HireDate = new DateTime(2022, 3, 8),
                Salary = 35000m,
                IsActive = true
            },
            new Worker
            {
                Id = 4,
                FirstName = "Ольга",
                LastName = "Васильева",
                MiddleName = "Петровна",
                Phone = "+79456789012",
                BirthDate = new DateTime(1988, 9, 30),
                Type = WorkerType.Сборщик,
                HireDate = new DateTime(2020, 8, 25),
                Salary = 42000m,
                IsActive = true
            },
            new Worker
            {
                Id = 5,
                FirstName = "Дмитрий",
                LastName = "Николаев",
                MiddleName = "Александрович",
                Phone = "+79567890123",
                BirthDate = new DateTime(1983, 12, 14),
                Type = WorkerType.Инженер,
                HireDate = new DateTime(2019, 11, 3),
                Salary = 72000m,
                IsActive = false
            },
            new Worker
            {
                Id = 6,
                FirstName = "Екатерина",
                LastName = "Морозова",
                MiddleName = "Дмитриевна",
                Phone = "+79678901234",
                BirthDate = new DateTime(1995, 4, 18),
                Type = WorkerType.Кормильщик,
                HireDate = new DateTime(2023, 2, 15),
                Salary = 38000m,
                IsActive = true
            },
            new Worker
            {
                Id = 7,
                FirstName = "Сергей",
                LastName = "Орлов",
                MiddleName = "Викторович",
                Phone = "79789012345",
                BirthDate = new DateTime(1991, 6, 25),
                Type = WorkerType.Ветеринар,
                HireDate = new DateTime(2021, 9, 10),
                Salary = 68000m,
                IsActive = true
            }
        );
    }
}