using PoultryFarmSystem.Models.Entities;

namespace PoultryFarmSystem.Models.ViewModels;

public class BirdFilterVM
{
    public string? BirdNumberFilter { get; set; }
    public string? StatusFilter { get; set; }
    public string? TypeFilter { get; set; }
    public List<Bird> Birds { get; set; } = new();
}