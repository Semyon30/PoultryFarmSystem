using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PoultryFarmSystem.Models.Entities;

public class HealthCard
{
    public int Id { get; set; }

    [Display(Name = "Вакцинации")]
    [StringLength(500, ErrorMessage = "Вакцинации не должны превышать 500 символов")]
    public string Vaccinations { get; set; } = string.Empty;

    [Display(Name = "Заболевания")]
    [StringLength(500, ErrorMessage = "Заболевания не должны превышать 500 символов")]
    public string Diseases { get; set; } = string.Empty;

    [Display(Name = "Аллергии")]
    [StringLength(500, ErrorMessage = "Аллергии не должны превышать 500 символов")]
    public string Allergies { get; set; } = string.Empty;

    [Display(Name = "Особые заметки")]
    [StringLength(1000, ErrorMessage = "Особые заметки не должны превышать 1000 символов")]
    public string SpecialNotes { get; set; } = string.Empty;

    [Display(Name = "Птица")]
    [Required(ErrorMessage = "Птица обязательна")]
    public int BirdId { get; set; }

    [ValidateNever]
    public Bird Bird { get; set; }
}