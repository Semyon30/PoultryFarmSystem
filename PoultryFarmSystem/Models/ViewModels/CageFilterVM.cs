using PoultryFarmSystem.Models.Entities;

namespace PoultryFarmSystem.Models.ViewModels;

public class CageFilterVM
{
    public string? NumberFilter { get; set; }
    public DateTime? CleaningDateFilter { get; set; }
    public DateTime? MaintenanceDateFilter { get; set; }
    public List<Cage> Cages { get; set; } = new();
}