using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PoultryFarmSystem.Models.Enums;

namespace PoultryFarmSystem.Models.Entities;

public class Bird
{
    public int Id { get; set; }
    
    [ValidateNever]
    public string BirdNumber { get; set; } = string.Empty;
    
    [Display(Name = "Тип птицы")]
    [Required(ErrorMessage = "Тип птицы обязателен")]
    public BirdType Type { get; set; }
    
    [Display(Name = "Вес (кг)")]
    [Required(ErrorMessage = "Вес обязателен")]
    [Range(0.01, 50.00, ErrorMessage = "Вес должен быть от 0.01 до 50.00 кг")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Вес должен иметь до 2 знаков после запятой")]
    public double Weight { get; set; }
    
    [Display(Name = "Последняя проверка здоровья")]
    [Required(ErrorMessage = "Дата последней проверки обязательна")]
    [DataType(DataType.Date)]
    public DateTime LastHealthCheck { get; set; }
    
    [Display(Name = "Статус")]
    [Required(ErrorMessage = "Статус обязателен")]
    public BirdStatus Status { get; set; }
    
    [ValidateNever]
    public Batch Batch { get; set; }
    
    [Display(Name = "Партия")]
    [Required(ErrorMessage = "Партия обязательна")]
    public int BatchId { get; set; }
    
    [ValidateNever]
    public Cage Cage { get; set; }
    
    [Display(Name = "Клетка")]
    [Required(ErrorMessage = "Клетка обязательна")]
    public int CageId { get; set; }
    
    [ValidateNever]
    public HealthCard HealthCard { get; set; }
    [ValidateNever]
    public int AgeInDays => (DateTime.Now - Batch.HatchDate).Days;
}