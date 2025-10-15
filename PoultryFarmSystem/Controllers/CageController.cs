using Microsoft.AspNetCore.Mvc;
using PoultryFarmSystem.Data;
using PoultryFarmSystem.Models.Entities;
using PoultryFarmSystem.Models.ViewModels;

namespace PoultryFarmSystem.Controllers;

public class CageController : Controller
{
    private readonly ApplicationDbContext _db;

    public CageController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public IActionResult Index(string numberFilter, DateTime? cleaningDateFilter, DateTime? maintenanceDateFilter)
    {
        var cages = _db.Cages.AsQueryable();

        if (!string.IsNullOrEmpty(numberFilter))
        {
            cages = cages.Where(c => c.Number.Contains(numberFilter));
        }

        if (cleaningDateFilter.HasValue)
        {
            cages = cages.Where(c => c.LastCleaning.Date == cleaningDateFilter.Value.Date);
        }

        if (maintenanceDateFilter.HasValue)
        {
            cages = cages.Where(c => c.LastMaintenance.Date == maintenanceDateFilter.Value.Date);
        }
        
        // Проценты зачислиненности для каждой клетки
        var cagesList = cages.ToList();
        var occupancyDict = new Dictionary<int, int>();
        foreach (var cage in cagesList)
        {
            occupancyDict[cage.Id] = _db.GetCageOccupancyPercentage(cage.Id);
        }

        var viewModel = new CageFilterVM
        {
            NumberFilter = numberFilter,
            CleaningDateFilter = cleaningDateFilter,
            MaintenanceDateFilter = maintenanceDateFilter,
            Cages = cages.ToList()
        };
        
        ViewBag.OccupancyPercentageDict = occupancyDict;
        
        return View(viewModel);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Cage());
    }

    [HttpPost]
    public IActionResult Create(Cage model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
    
        model.Number = model.GenerateCageNumber();
    
        if (model.LastCleaning == default)
            model.LastCleaning = DateTime.Now;
        if (model.LastMaintenance == default)
            model.LastMaintenance = DateTime.Now;

        _db.Cages.Add(model);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var cage = _db.Cages.Find(id);
        if (cage == null)
        {
            return NotFound();
        }

        return View(cage);
    }

    [HttpPost]
    public IActionResult Update(Cage model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }


        model.Number = model.GenerateCageNumber();

        _db.Cages.Update(model);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var cage = _db.Cages.Find(id);
        if (cage == null)
        {
            return NotFound();
        }
        return View(cage);
    }

    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var cage = _db.Cages.Find(id);
        if (cage == null)
        {
            return NotFound();
        }

        _db.Cages.Remove(cage);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
}