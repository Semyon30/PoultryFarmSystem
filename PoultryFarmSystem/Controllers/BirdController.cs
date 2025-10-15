using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoultryFarmSystem.Data;
using PoultryFarmSystem.Models.Entities;
using PoultryFarmSystem.Models.Enums;
using PoultryFarmSystem.Models.ViewModels;

namespace PoultryFarmSystem.Controllers;

public class BirdController : Controller
{
    private readonly ApplicationDbContext _db;

    public BirdController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index(string birdNumberFilter, string statusFilter, string typeFilter)
    {
        var birds = _db.Birds
            .Include(b => b.Batch)
            .Include(b => b.Cage)
            .AsQueryable();

        if (!string.IsNullOrEmpty(birdNumberFilter))
        {
            birds = birds.Where(b => b.BirdNumber.Contains(birdNumberFilter));
        }

        if (!string.IsNullOrEmpty(statusFilter))
        {
            birds = birds.Where(b => b.Status.ToString() == statusFilter);
        }

        if (!string.IsNullOrEmpty(typeFilter))
        {
            birds = birds.Where(b => b.Type.ToString() == typeFilter);
        }

        var viewModel = new BirdFilterVM
        {
            BirdNumberFilter = birdNumberFilter,
            StatusFilter = statusFilter,
            TypeFilter = typeFilter,
            Birds = birds.ToList()
        };
    
        return View(viewModel);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.BirdTypes = GetBirdTypeSelectList();
        ViewBag.BirdStatuses = GetBirdStatusSelectList();
        ViewBag.Batches = GetBatchesSelectList();
        ViewBag.Cages = GetCagesSelectList();
    
        return View(new Bird());
    }

    [HttpPost]
    public IActionResult Create(Bird model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.BirdTypes = GetBirdTypeSelectList();
            ViewBag.BirdStatuses = GetBirdStatusSelectList();
            ViewBag.Batches = GetBatchesSelectList();
            ViewBag.Cages = GetCagesSelectList();
            return View(model);
        }
    
        model.BirdNumber = GenerateBirdNumber(model.Type);

        _db.Birds.Add(model);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var bird = _db.Birds
            .Include(b => b.Batch)
            .Include(b => b.Cage)
            .FirstOrDefault(b => b.Id == id);
        
        if (bird == null)
        {
            return NotFound();
        }

        ViewBag.BirdTypes = GetBirdTypeSelectList();
        ViewBag.BirdStatuses = GetBirdStatusSelectList();
        ViewBag.Batches = GetBatchesSelectList();
        ViewBag.Cages = GetCagesSelectList();
    
        return View(bird);
    }

    [HttpPost]
    public IActionResult Update(Bird model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.BirdTypes = GetBirdTypeSelectList();
            ViewBag.BirdStatuses = GetBirdStatusSelectList();
            ViewBag.Batches = GetBatchesSelectList();
            ViewBag.Cages = GetCagesSelectList();
            return View(model);
        }
        var existingBird = _db.Birds.Where(b=>b.Id == model.Id).AsNoTracking().FirstOrDefault();

        if (existingBird.Type != model.Type)
        {
            model.BirdNumber = GenerateBirdNumber(model.Type);
        }

        _db.Birds.Update(model);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var bird = _db.Birds
            .Include(b => b.Batch)
            .Include(b => b.Cage)
            .FirstOrDefault(b => b.Id == id);
        
        if (bird == null)
        {
            return NotFound();
        }
        return View(bird);
    }

    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var bird = _db.Birds.Find(id);
        if (bird == null)
        {
            return NotFound();
        }

        _db.Birds.Remove(bird);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    private SelectList GetBirdTypeSelectList()
    {
        return new SelectList(Enum.GetValues<BirdType>()
            .Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }), "Value", "Text");
    }

    private SelectList GetBirdStatusSelectList()
    {
        return new SelectList(Enum.GetValues<BirdStatus>()
            .Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }), "Value", "Text");
    }

    private SelectList GetBatchesSelectList()
    {
        var batches = _db.Batches
            .Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.BatchNumber
            }).ToList();
    
        return new SelectList(batches, "Value", "Text");
    }

    private SelectList GetCagesSelectList()
    {
        var cages = _db.Cages
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Number
            }).ToList();
    
        return new SelectList(cages, "Value", "Text");
    }

    private string GenerateBirdNumber(BirdType type)
    {
        var count = _db.Birds.Count(b => b.Type == type) + 1;
        string typeCode = type switch
        {
            BirdType.Курица => "CHKN",
            BirdType.Утка => "DUCK", 
            BirdType.Гусь => "GOOS",
            BirdType.Индейка => "TURK",
            BirdType.Перепел => "QUAIL",
            _ => "BIRD"
        };

        return $"{typeCode}-{count:000}";
    }
}