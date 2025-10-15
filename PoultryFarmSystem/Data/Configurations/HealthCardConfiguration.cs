using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoultryFarmSystem.Models.Entities;

namespace PoultryFarmSystem.Data.Configurations;

public class HealthCardConfiguration : IEntityTypeConfiguration<HealthCard>
{
    public void Configure(EntityTypeBuilder<HealthCard> builder)
    {
        builder.HasKey(h => h.Id);
            
        builder.Property(h => h.Vaccinations)
            .HasMaxLength(500);
                
        builder.Property(h => h.Diseases)
            .HasMaxLength(500);
                
        builder.Property(h => h.Allergies)
            .HasMaxLength(500);
                
        builder.Property(h => h.SpecialNotes)
            .HasMaxLength(1000);
        
        builder.HasData(
            new HealthCard 
            { 
                Id = 1, 
                BirdId = 1,
                Vaccinations = "Ньюкасл, Гамборо, Марек",
                Diseases = "Нет",
                Allergies = "Нет",
                SpecialNotes = "Здоровая птица, регулярные прививки" 
            },
            new HealthCard 
            { 
                Id = 2, 
                BirdId = 2,
                Vaccinations = "Ньюкасл, Гамборо",
                Diseases = "Легкая простуда в ноябре 2024",
                Allergies = "Нет",
                SpecialNotes = "Требуется наблюдение после болезни" 
            },
            new HealthCard 
            { 
                Id = 3, 
                BirdId = 3,
                Vaccinations = "Ньюкасл",
                Diseases = "Респираторная инфекция",
                Allergies = "Нет",
                SpecialNotes = "На лечении антибиотиками, изолировать от других птиц" 
            },
            
            new HealthCard 
            { 
                Id = 4, 
                BirdId = 4,
                Vaccinations = "Грипп птиц, Холера",
                Diseases = "Нет",
                Allergies = "Нет",
                SpecialNotes = "Отличное здоровье, активная" 
            },
            new HealthCard 
            { 
                Id = 5, 
                BirdId = 5,
                Vaccinations = "Грипп птиц",
                Diseases = "Травма крыла",
                Allergies = "Нет",
                SpecialNotes = "Проходит лечение, ограничить движение" 
            },
            new HealthCard 
            { 
                Id = 6, 
                BirdId = 6,
                Vaccinations = "Грипп птиц, Холера, Сальмонелла",
                Diseases = "Нет",
                Allergies = "Пыльца",
                SpecialNotes = "Сезонная аллергия, наблюдать в весенний период" 
            },
            
            new HealthCard 
            { 
                Id = 7, 
                BirdId = 7,
                Vaccinations = "Ньюкасл, Оспа",
                Diseases = "Кокцидиоз",
                Allergies = "Нет",
                SpecialNotes = "Карантин, инфекционное заболевание" 
            },
            new HealthCard 
            { 
                Id = 8, 
                BirdId = 8,
                Vaccinations = "Ньюкасл, Оспа, Грипп",
                Diseases = "Нет",
                Allergies = "Нет",
                SpecialNotes = "Идеальное здоровье, племенная птица" 
            },
            new HealthCard 
            { 
                Id = 9, 
                BirdId = 9,
                Vaccinations = "Ньюкасл, Оспа",
                Diseases = "Нет",
                Allergies = "Нет",
                SpecialNotes = "Хорошая физическая форма, быстро набирает вес" 
            }
        );
    }
}