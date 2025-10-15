using PoultryFarmSystem.Models.Entities;

namespace PoultryFarmSystem.Models.ViewModels;

public class HealthCardFilterVM
{
    public string? BirdNumberFilter { get; set; }
    public string? VaccinationsFilter { get; set; }
    public List<HealthCard> HealthCards { get; set; } = new();
}