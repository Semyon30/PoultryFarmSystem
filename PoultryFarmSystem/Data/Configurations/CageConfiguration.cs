using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoultryFarmSystem.Models.Entities;

namespace PoultryFarmSystem.Data.Configurations;

public class CageConfiguration : IEntityTypeConfiguration<Cage>
{
    public void Configure(EntityTypeBuilder<Cage> builder)
    {
        builder.HasKey(c => c.Id);
            
        builder.Property(c => c.Number)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(c => c.Section)
            .IsRequired()
            .HasMaxLength(3);
                
        builder.Property(c => c.Capacity)
            .IsRequired();
                
        builder.Property(c => c.LastCleaning)
            .IsRequired();
                
        builder.Property(c => c.LastMaintenance)
            .IsRequired();
        
        builder.HasMany(c => c.Birds)
            .WithOne(b => b.Cage)
            .HasForeignKey(b => b.CageId)
            .OnDelete(DeleteBehavior.Cascade);
                
        builder.HasMany(c => c.Assignments)
            .WithOne(a => a.Cage)
            .HasForeignKey(a => a.CageId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(
            new Cage
            {
                Id = 1,
                Number = "AAA-50",
                Section = "AAB",
                Capacity = 50,
                LastCleaning = new DateTime(2024, 11, 13),
                LastMaintenance = new DateTime(2024, 10, 15)
            },
            new Cage
            {
                Id = 2,
                Number = "AAC-75",
                Section = "AAC",
                Capacity = 75,
                LastCleaning = new DateTime(2024, 11, 14),
                LastMaintenance = new DateTime(2024, 9, 15)
            },
            new Cage
            {
                Id = 3,
                Number = "AAD-100",
                Section = "AAD",
                Capacity = 100,
                LastCleaning = new DateTime(2024, 11, 12),
                LastMaintenance = new DateTime(2024, 10, 10)
            },
            new Cage
            {
                Id = 4,
                Number = "AAE-60",
                Section = "AAE",
                Capacity = 60,
                LastCleaning = new DateTime(2024, 11, 10),
                LastMaintenance = new DateTime(2024, 8, 15)
            },
            new Cage
            {
                Id = 5,
                Number = "ABA-120",
                Section = "ABA",
                Capacity = 120,
                LastCleaning = new DateTime(2024, 11, 14),
                LastMaintenance = new DateTime(2024, 10, 5)
            },
            new Cage
            {
                Id = 6,
                Number = "ABC-80",
                Section = "ABC",
                Capacity = 80,
                LastCleaning = new DateTime(2024, 11, 11),
                LastMaintenance = new DateTime(2024, 9, 10)
            },
            new Cage
            {
                Id = 7,
                Number = "ACA-90",
                Section = "ACA",
                Capacity = 90,
                LastCleaning = new DateTime(2024, 11, 9),
                LastMaintenance = new DateTime(2024, 7, 15)
            }
        );
        
        
    }
}