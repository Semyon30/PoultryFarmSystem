using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PoultryFarmSystem.Data;
using PoultryFarmSystem.Models.Enums;

namespace PoultryFarmSystem.Models.Entities;

public class Batch
{
    public int Id { get; set; }

    [ValidateNever]
    public string BatchNumber { get; set; }

    [Display(Name = "Дата вывода")]
    [Required(ErrorMessage = "Дата вывода обязательна")]
    [DataType(DataType.Date)]
    public DateTime HatchDate { get; set; }        
    
    [Display(Name = "Количество")]
    [Required(ErrorMessage = "Количество обязательно")]
    [Range(1, 100000, ErrorMessage = "Количество должно быть от 1 до 100 000")]
    public int Count { get; set; } 
    
    [Display(Name = "Тип птицы")]
    [Required(ErrorMessage = "Тип птицы обязателен")]
    public BirdType Type { get; set; }
    
    [Display(Name = "Партия прибыла")]
    [Required(ErrorMessage = "Статус прибытия обязателен")]
    public bool IsArrived { get; set; } = false;
    
    [Display(Name = "Источник")]
    [Required(ErrorMessage = "Источник обязателен")]
    public SourceType Source { get; set; }
    
    [Display(Name = "Дата прибытия(необязательно)")]
    [DataType(DataType.Date)]
    public DateTime? ArrivalDate { get; set; }
    
    [Display(Name = "Порода")]
    [Required(ErrorMessage = "Порода обязательна")]
    [StringLength(50, ErrorMessage = "Порода не должна превышать 50 символов")]
    public string Breed { get; set; } = string.Empty;
    
    [ValidateNever]
    public ICollection<Bird> Birds { get; set; }
    
    public string GenerateBatchNumber()
    {
        var now = DateTime.Now;
        string typeCode = Type switch
        {
            BirdType.Курица => "CHKN",
            BirdType.Утка => "DUCK", 
            BirdType.Гусь => "GOOS",
            BirdType.Индейка => "TURK",
            BirdType.Перепел => "QUAIL",
            _ => "OTHER"
        };

        return $"{now:yyyyMMdd}-{typeCode}-{now:HHmm}";
    }
}