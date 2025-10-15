using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoultryFarmSystem.Models.Entities;
using PoultryFarmSystem.Models.Enums;

namespace PoultryFarmSystem.Data.Configurations;

public class BirdConfiguration : IEntityTypeConfiguration<Bird>
{
    public void Configure(EntityTypeBuilder<Bird> builder)
    {
        builder.HasKey(b => b.Id);
            
        builder.Property(b => b.BirdNumber)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(b => b.Type)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);
        
        builder.Property(b => b.Weight)
            .IsRequired()
            .HasColumnType("decimal(5,2)");
        
        builder.Property(b => b.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);
        
        builder.HasOne(b => b.HealthCard)
            .WithOne(h => h.Bird)
            .HasForeignKey<HealthCard>(h => h.BirdId)
            .OnDelete(DeleteBehavior.Cascade);
                
        builder.Ignore(b => b.AgeInDays);
        
        
        builder.HasData(
        
            new Bird { Id = 1, BirdNumber = "CHKN-001", Type = BirdType.Курица, Weight = 2.5, LastHealthCheck = new DateTime(2024, 11, 10), Status = BirdStatus.Активна, BatchId = 1, CageId = 1 },
            new Bird { Id = 2, BirdNumber = "CHKN-002", Type = BirdType.Курица, Weight = 2.3, LastHealthCheck = new DateTime(2024, 11, 12), Status = BirdStatus.Активна, BatchId = 1, CageId = 1 },
            new Bird { Id = 3, BirdNumber = "CHKN-003", Type = BirdType.Курица, Weight = 2.7, LastHealthCheck = new DateTime(2024, 11, 14), Status = BirdStatus.Больна, BatchId = 1, CageId = 1 },
            
            // Птицы из партии 2 (Утки) в клетке 2
            new Bird { Id = 4, BirdNumber = "DUCK-001", Type = BirdType.Утка, Weight = 3.2, LastHealthCheck = new DateTime(2024, 11, 8), Status = BirdStatus.Активна, BatchId = 2, CageId = 2 },
            new Bird { Id = 5, BirdNumber = "DUCK-002", Type = BirdType.Утка, Weight = 3.0, LastHealthCheck = new DateTime(2024, 11, 13), Status = BirdStatus.Лечение, BatchId = 2, CageId = 2 },
            new Bird { Id = 6, BirdNumber = "DUCK-003", Type = BirdType.Утка, Weight = 3.5, LastHealthCheck = new DateTime(2024, 11, 11), Status = BirdStatus.Активна, BatchId = 2, CageId = 2 },
            
            // Птицы из партии 3 (Индейки) в клетке 3
            new Bird { Id = 7, BirdNumber = "TURK-001", Type = BirdType.Индейка, Weight = 8.2, LastHealthCheck = new DateTime(2024, 11, 5), Status = BirdStatus.Карантин, BatchId = 3, CageId = 3 },
            new Bird { Id = 8, BirdNumber = "TURK-002", Type = BirdType.Индейка, Weight = 7.8, LastHealthCheck = new DateTime(2024, 11, 9), Status = BirdStatus.Активна, BatchId = 3, CageId = 3 },
            new Bird { Id = 9, BirdNumber = "TURK-003", Type = BirdType.Индейка, Weight = 9.1, LastHealthCheck = new DateTime(2024, 11, 7), Status = BirdStatus.Активна, BatchId = 3, CageId = 3 },
            
            // Птицы из партии 4 (Гуси) в клетке 4
            new Bird { Id = 10, BirdNumber = "GOOS-001", Type = BirdType.Гусь, Weight = 5.3, LastHealthCheck = new DateTime(2024, 11, 3), Status = BirdStatus.Активна, BatchId = 4, CageId = 4 },
            new Bird { Id = 11, BirdNumber = "GOOS-002", Type = BirdType.Гусь, Weight = 4.9, LastHealthCheck = new DateTime(2024, 11, 6), Status = BirdStatus.Больна, BatchId = 4, CageId = 4 },
            new Bird { Id = 12, BirdNumber = "GOOS-003", Type = BirdType.Гусь, Weight = 5.8, LastHealthCheck = new DateTime(2024, 10, 30), Status = BirdStatus.Активна, BatchId = 4, CageId = 4 },
            
            // Птицы из партии 5 (Перепела) в клетке 5
            new Bird { Id = 13, BirdNumber = "QUAIL-001", Type = BirdType.Перепел, Weight = 0.15, LastHealthCheck = new DateTime(2024, 11, 13), Status = BirdStatus.Активна, BatchId = 5, CageId = 5 },
            new Bird { Id = 14, BirdNumber = "QUAIL-002", Type = BirdType.Перепел, Weight = 0.18, LastHealthCheck = new DateTime(2024, 11, 11), Status = BirdStatus.Активна, BatchId = 5, CageId = 5 },
            new Bird { Id = 15, BirdNumber = "QUAIL-003", Type = BirdType.Перепел, Weight = 0.16, LastHealthCheck = new DateTime(2024, 11, 14), Status = BirdStatus.Умерла, BatchId = 5, CageId = 5 },
            
            // Птицы из партии 6 (Куры) в клетке 6
            new Bird { Id = 16, BirdNumber = "CHKN-101", Type = BirdType.Курица, Weight = 2.8, LastHealthCheck = new DateTime(2024, 11, 12), Status = BirdStatus.Активна, BatchId = 6, CageId = 6 },
            new Bird { Id = 17, BirdNumber = "CHKN-102", Type = BirdType.Курица, Weight = 2.6, LastHealthCheck = new DateTime(2024, 11, 9), Status = BirdStatus.Активна, BatchId = 6, CageId = 6 },
            new Bird { Id = 18, BirdNumber = "CHKN-103", Type = BirdType.Курица, Weight = 2.9, LastHealthCheck = new DateTime(2024, 11, 13), Status = BirdStatus.Лечение, BatchId = 6, CageId = 6 },
            
            // Птицы из партии 7 (Утки) в клетке 7
            new Bird { Id = 19, BirdNumber = "DUCK-101", Type = BirdType.Утка, Weight = 3.3, LastHealthCheck = new DateTime(2024, 11, 10), Status = BirdStatus.Активна, BatchId = 7, CageId = 7 },
            new Bird { Id = 20, BirdNumber = "DUCK-102", Type = BirdType.Утка, Weight = 3.1, LastHealthCheck = new DateTime(2024, 11, 7), Status = BirdStatus.Карантин, BatchId = 7, CageId = 7 },
            new Bird { Id = 21, BirdNumber = "DUCK-103", Type = BirdType.Утка, Weight = 3.4, LastHealthCheck = new DateTime(2024, 11, 12), Status = BirdStatus.Активна, BatchId = 7, CageId = 7 }
        );  

    }
}