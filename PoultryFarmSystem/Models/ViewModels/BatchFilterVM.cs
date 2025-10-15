using PoultryFarmSystem.Models.Entities;

namespace PoultryFarmSystem.Models.ViewModels;

public class BatchFilterVM
{
    public string? BatchNumberFilter { get; set; }
    public string? ArrivedFilter { get; set; }
    public List<Batch> Batches { get; set; } = new();
}