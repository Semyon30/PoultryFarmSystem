using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PoultryFarmSystem.Models.Enums;

namespace PoultryFarmSystem.Models.Entities;

public class Worker
{
    public int Id { get; set; }

    [Display(Name = "Имя")]
    [Required(ErrorMessage = "Имя обязательно")]
    [StringLength(25, ErrorMessage = "Имя не должно превышать 25 символов")]
    public string FirstName { get; set; }
    
    [Display(Name = "Фамилия")]
    [Required(ErrorMessage = "Фамилия обязательна")]
    [StringLength(25, ErrorMessage = "Фамилия не должна превышать 25 символов")]
    public string LastName { get; set; } 
    
    [Display(Name = "Отчество")]
    [StringLength(25, ErrorMessage = "Отчество не должно превышать 25 символов")]
    public string? MiddleName { get; set; }
    
    [Display(Name = "Телефон")]
    [Required(ErrorMessage = "Телефон обязателен")]
    [StringLength(15, ErrorMessage = "Телефон не должен превышать 15 символов")]
    [Phone(ErrorMessage = "Неверный формат телефона")]
    public string Phone { get; set; }
    
    [Display(Name = "Дата рождения")]
    [DataType(DataType.Date)]
    public DateTime? BirthDate { get; set; }
    
    [Display(Name = "Должность")]
    [Required(ErrorMessage = "Должность обязательна")]
    public WorkerType Type { get; set; }
    
    [Display(Name = "Дата найма")]
    [Required(ErrorMessage = "Дата найма обязательна")]
    [DataType(DataType.Date)]
    public DateTime HireDate { get; set; }
    
    [Display(Name = "Зарплата")]
    [Required(ErrorMessage = "Зарплата обязательна")]
    [Range(0, 9999999.99, ErrorMessage = "Зарплата должна быть от 0 до 9,999,999.99")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Зарплата должна иметь до 2 знаков после запятой")]
    public decimal Salary { get; set; }
    
    [Display(Name = "Активный сотрудник")]
    [Required(ErrorMessage = "Статус активности обязателен")]
    public bool IsActive { get; set; } = true;

    [ValidateNever]
    public ICollection<Assignment> Assignments { get; set; }
}
