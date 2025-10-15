using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoultryFarmSystem.Models.Entities;
using PoultryFarmSystem.Models.Enums;

namespace PoultryFarmSystem.Data.Configurations;

public class BatchConfiguration : IEntityTypeConfiguration<Batch>
{
    public void Configure(EntityTypeBuilder<Batch> builder)
    {
        builder.HasKey(b => b.Id);
            
        builder.Property(b => b.BatchNumber)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(b => b.HatchDate)
            .IsRequired();
                
        builder.Property(b => b.Count)
            .IsRequired();
        
        builder.Property(b => b.Type)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);
        
        builder.Property(b => b.IsArrived)
            .IsRequired();
        
        builder.Property(b => b.Source)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);
        
        builder.Property(b => b.Breed)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.HasMany(b => b.Birds)
            .WithOne(b => b.Batch)
            .HasForeignKey(b => b.BatchId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        builder.HasData(
            new Batch
            {
                Id = 1,
                BatchNumber = "20241115-CHKN-0930",
                HatchDate = new DateTime(2024, 11, 10),
                Count = 1000,
                Type = BirdType.Курица,
                IsArrived = true,
                Source = SourceType.Птицефабрика,
                ArrivalDate = new DateTime(2024, 11, 15),
                Breed = "Ломан Браун"
            },
            new Batch
            {
                Id = 2,
                BatchNumber = "20241116-DUCK-1430", 
                HatchDate = new DateTime(2024, 11, 12),
                Count = 500,
                Type = BirdType.Утка,
                IsArrived = true,
                Source = SourceType.Ферма,
                ArrivalDate = new DateTime(2024, 11, 16),
                Breed = "Пекинская"
            },
            new Batch
            {
                Id = 3,
                BatchNumber = "20241117-TURK-1100",
                HatchDate = new DateTime(2024, 11, 8),
                Count = 300,
                Type = BirdType.Индейка,
                IsArrived = false,
                Source = SourceType.Инкубатор,
                ArrivalDate = null,
                Breed = "Бронзовая"
            },
            new Batch
            {
                Id = 4,
                BatchNumber = "20241118-GOOS-1600",
                HatchDate = new DateTime(2024, 11, 5),
                Count = 200,
                Type = BirdType.Гусь,
                IsArrived = true,
                Source = SourceType.Локальный,
                ArrivalDate = new DateTime(2024, 11, 18),
                Breed = "Холмогорская"
            },
            new Batch
            {
                Id = 5,
                BatchNumber = "20241119-QUAIL-0900",
                HatchDate = new DateTime(2024, 11, 15),
                Count = 2000,
                Type = BirdType.Перепел,
                IsArrived = true,
                Source = SourceType.Собственный,
                ArrivalDate = new DateTime(2024, 11, 19),
                Breed = "Японская"
            },
            new Batch
            {
                Id = 6,
                BatchNumber = "20241120-CHKN-1400",
                HatchDate = new DateTime(2024, 11, 12),
                Count = 800,
                Type = BirdType.Курица,
                IsArrived = false,
                Source = SourceType.Импорт,
                ArrivalDate = null,
                Breed = "Хайсекс Браун"
            },
            new Batch
            {
                Id = 7,
                BatchNumber = "20241121-DUCK-1030",
                HatchDate = new DateTime(2024, 11, 10),
                Count = 600,
                Type = BirdType.Утка,
                IsArrived = true,
                Source = SourceType.Птицефабрика,
                ArrivalDate = new DateTime(2024, 11, 21),
                Breed = "Мускусная"
            }
        );
    }
}