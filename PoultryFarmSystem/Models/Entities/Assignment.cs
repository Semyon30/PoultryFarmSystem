using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PoultryFarmSystem.Models.Enums;

namespace PoultryFarmSystem.Models.Entities;

public class Assignment
{
    public int Id { get; set; }
    
    [Display(Name = "Название задания")]
    [Required(ErrorMessage = "Название задания обязательно")]
    [StringLength(100, ErrorMessage = "Название не должно превышать 100 символов")]
    public string Title { get; set; } = string.Empty;     
    
    [Display(Name = "Описание")]
    [StringLength(500, ErrorMessage = "Описание не должно превышать 500 символов")]
    public string Description { get; set; } = string.Empty; 
    
    
    [Display(Name = "Дата начала")]
    [Required(ErrorMessage = "Дата начала обязательна")]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; } = DateTime.Now;      
    
    [Display(Name = "Дата окончания")]
    [Required(ErrorMessage = "Дата окончания обязательна")]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }  
    
    [Display(Name = "Дата завершения")]
    [DataType(DataType.DateTime)]
    public DateTime? CompletedDate { get; set; }       
    
    [Display(Name = "Статус")]
    [Required(ErrorMessage = "Статус обязателен")]
    public AssignmentStatus Status { get; set; } = AssignmentStatus.Назначено;
    
    [Display(Name = "Приоритет")]
    [Required(ErrorMessage = "Приоритет обязателен")]
    public PriorityLevel Priority { get; set; } = PriorityLevel.Средний;
    
    [ValidateNever]
    public Worker Worker { get; set; }
    
    [Display(Name = "Сотрудник")]
    [Required(ErrorMessage = "Сотрудник обязателен")]
    public int WorkerId { get; set; }                        
   
    [ValidateNever]
    public Cage Cage { get; set; }
    
    [Display(Name = "Клетка")]
    [Required(ErrorMessage = "Клетка обязательна")]
    public int CageId { get; set; }                          
}