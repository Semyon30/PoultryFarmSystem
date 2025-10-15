using PoultryFarmSystem.Models.Entities;

namespace PoultryFarmSystem.Models.ViewModels;

public class WorkerFilterVM
{
    public string? NameFilter { get; set; }
    public string? TypeFilter { get; set; }
    public List<Worker> Workers { get; set; } = new List<Worker>();
}