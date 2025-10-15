using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoultryFarmSystem.Data;
using PoultryFarmSystem.Models.Entities;
using PoultryFarmSystem.Models.ViewModels;

namespace PoultryFarmSystem.Controllers;

public class HealthCardController : Controller
{
    private readonly ApplicationDbContext _db;

    public HealthCardController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index(string birdNumberFilter, string vaccinationsFilter)
    {
        var healthCards = _db.HealthCards
            .Include(h => h.Bird)
            .ThenInclude(b => b.Batch)
            .Include(h => h.Bird)
            .ThenInclude(b => b.Cage)
            .AsQueryable();

        if (!string.IsNullOrEmpty(birdNumberFilter))
        {
            healthCards = healthCards.Where(h => h.Bird.BirdNumber.Contains(birdNumberFilter));
        }

        if (!string.IsNullOrEmpty(vaccinationsFilter))
        {
            healthCards = healthCards.Where(h => h.Vaccinations.Contains(vaccinationsFilter));
        }

        var viewModel = new HealthCardFilterVM
        {
            BirdNumberFilter = birdNumberFilter,
            VaccinationsFilter = vaccinationsFilter,
            HealthCards = healthCards.ToList()
        };
    
        return View(viewModel);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Birds = GetBirdsSelectList();
        return View(new HealthCard());
    }

    [HttpPost]
    public IActionResult Create(HealthCard model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Birds = GetBirdsSelectList();
            return View(model);
        }
        
        _db.HealthCards.Add(model);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var healthCard = _db.HealthCards
            .Include(h => h.Bird)
            .FirstOrDefault(h => h.Id == id);
        
        if (healthCard == null)
        {
            return NotFound();
        }
    
        return View(healthCard);
    }

    [HttpPost]
    public IActionResult Update(HealthCard model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        _db.HealthCards.Update(model);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var healthCard = _db.HealthCards
            .Include(h => h.Bird)
            .FirstOrDefault(h => h.Id == id);
        
        if (healthCard == null)
        {
            return NotFound();
        }
        return View(healthCard);
    }

    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var healthCard = _db.HealthCards.Find(id);
        if (healthCard == null)
        {
            return NotFound();
        }

        _db.HealthCards.Remove(healthCard);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    private SelectList GetBirdsSelectList()
    {
        var birdsWithCards = _db.HealthCards
            .Select(h => h.BirdId)
            .ToList();

        var availableBirds = _db.Birds
            .Where(b => !birdsWithCards.Contains(b.Id))
            .Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = $"{b.BirdNumber} - {b.Type} ({b.Batch.BatchNumber})"
            })
            .ToList();
    
        return new SelectList(availableBirds, "Value", "Text");
    }
}