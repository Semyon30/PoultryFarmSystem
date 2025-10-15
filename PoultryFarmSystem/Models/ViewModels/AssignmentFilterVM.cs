using PoultryFarmSystem.Models.Entities;

namespace PoultryFarmSystem.Models.ViewModels;

public class AssignmentFilterVM
{
    public string? StatusFilter { get; set; }
    public string? PriorityFilter { get; set; }
    public string? WorkerFilter { get; set; }
    public List<Assignment> Assignments { get; set; } = new();
}