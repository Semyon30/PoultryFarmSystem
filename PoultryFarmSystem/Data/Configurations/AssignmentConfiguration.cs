using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoultryFarmSystem.Models.Entities;
using PoultryFarmSystem.Models.Enums;

namespace PoultryFarmSystem.Data.Configurations;

public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.HasKey(a => a.Id);
            
        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(100);
                
        builder.Property(a => a.Description)
            .HasMaxLength(500);
                
        builder.Property(a => a.StartDate)
            .IsRequired();
        
        builder.Property(a => a.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);
                
        builder.Property(a => a.Priority)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(15);
        
        builder.HasOne(a => a.Worker)
            .WithMany(w => w.Assignments)
            .HasForeignKey(a => a.WorkerId)
            .OnDelete(DeleteBehavior.Cascade);
                
        builder.HasOne(a => a.Cage)
            .WithMany(c => c.Assignments)
            .HasForeignKey(a => a.CageId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(
            new Assignment
            {
                Id = 1,
                Title = "Ежедневная уборка клетки A-50",
                Description = "Полная уборка клетки, дезинфекция кормушек и поилок",
                StartDate = new DateTime(2024, 11, 13),
                EndDate = new DateTime(2024, 11, 13, 17, 0, 0),
                CompletedDate = new DateTime(2024, 11, 13, 16, 30, 0),
                Status = AssignmentStatus.Завершено,
                Priority = PriorityLevel.Средний,
                WorkerId = 3, // Уборщик
                CageId = 1    // Клетка A-50
            },
            new Assignment
            {
                Id = 2,
                Title = "Вакцинация кур в клетке A-50",
                Description = "Проведение плановой вакцинации от болезни Ньюкасла",
                StartDate = new DateTime(2024, 11, 14),
                EndDate = new DateTime(2024, 11, 14, 15, 0, 0),
                CompletedDate = null,
                Status = AssignmentStatus.Выполняется,
                Priority = PriorityLevel.Высокий,
                WorkerId = 2, // Ветеринар
                CageId = 1    // Клетка A-50
            },
            new Assignment
            {
                Id = 3,
                Title = "Техническое обслуживание клетки B-75",
                Description = "Проверка системы вентиляции и освещения",
                StartDate = new DateTime(2024, 11, 15),
                EndDate = new DateTime(2024, 11, 15, 18, 0, 0),
                CompletedDate = null,
                Status = AssignmentStatus.Назначено,
                Priority = PriorityLevel.Средний,
                WorkerId = 5, // Инженер
                CageId = 2    // Клетка B-75
            },
            new Assignment
            {
                Id = 4,
                Title = "Сбор яиц из клетки C-100",
                Description = "Ежедневный сбор и сортировка яиц",
                StartDate = new DateTime(2024, 11, 12),
                EndDate = new DateTime(2024, 11, 12, 14, 0, 0),
                CompletedDate = new DateTime(2024, 11, 12, 13, 45, 0),
                Status = AssignmentStatus.Завершено,
                Priority = PriorityLevel.Низкий,
                WorkerId = 4, // Сборщик
                CageId = 3    // Клетка C-100
            },
            new Assignment
            {
                Id = 5,
                Title = "Кормление уток в клетке B-75",
                Description = "Утреннее кормление, проверка качества корма",
                StartDate = new DateTime(2024, 11, 14),
                EndDate = new DateTime(2024, 11, 14, 10, 0, 0),
                CompletedDate = new DateTime(2024, 11, 14, 9, 30, 0),
                Status = AssignmentStatus.Завершено,
                Priority = PriorityLevel.Высокий,
                WorkerId = 6, // Кормильщик
                CageId = 2    // Клетка B-75
            },
            new Assignment
            {
                Id = 6,
                Title = "Лечение больной птицы в клетке A-50",
                Description = "Осмотр и лечение птицы с признаками заболевания",
                StartDate = new DateTime(2024, 11, 13),
                EndDate = new DateTime(2024, 11, 15, 16, 0, 0),
                CompletedDate = null,
                Status = AssignmentStatus.Проверяется,
                Priority = PriorityLevel.Критический,
                WorkerId = 7, // Ветеринар
                CageId = 1    // Клетка A-50
            },
            new Assignment
            {
                Id = 7,
                Title = "Плановая инвентаризация клетки D-60",
                Description = "Переучет поголовья и оборудования",
                StartDate = new DateTime(2024, 11, 16),
                EndDate = new DateTime(2024, 11, 16, 17, 0, 0),
                CompletedDate = null,
                Status = AssignmentStatus.Назначено,
                Priority = PriorityLevel.Средний,
                WorkerId = 1, // Руководитель
                CageId = 4    // Клетка D-60
            }
        );
    }
}