using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PoultryFarmSystem.Models.Entities;

public class Cage
{
    public int Id { get; set; }
    
    [ValidateNever]
    public string Number { get; set; } = string.Empty; 
    
    [Display(Name = "Вместимость")]
    [Required(ErrorMessage = "Вместимость обязательна")]
    [Range(1, 1000, ErrorMessage = "Вместимость должна быть от 1 до 1000 птиц")]
    public int Capacity { get; set; }
    
    [Display(Name = "Секция")]
    [Required(ErrorMessage = "Секция обязательна")]
    [StringLength(3, ErrorMessage = "Секция имеет максимум 3 символа")]
    [RegularExpression(@"^[A-Z]+$", ErrorMessage = "Секция должна содержать только заглавные буквы")]
    public string Section { get; set; }
    
    [Display(Name = "Дата последней уборки")]
    [Required(ErrorMessage = "Дата последней уборки обязательна")]
    [DataType(DataType.Date)]
    public DateTime LastCleaning { get; set; }   
    
    [Display(Name = "Дата последнего обслуживания")]
    [Required(ErrorMessage = "Дата последнего обслуживания обязательна")]
    [DataType(DataType.Date)]
    public DateTime LastMaintenance { get; set; }   
    
    [ValidateNever]
    public ICollection<Bird> Birds { get; set; } 
    [ValidateNever]
    public ICollection<Assignment> Assignments { get; set; }
    
    public string GenerateCageNumber()
    {
        return $"{Section}-{Capacity}";
    }
}