using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoultryFarmSystem.Data;
using PoultryFarmSystem.Models.Entities;
using PoultryFarmSystem.Models.Enums;
using PoultryFarmSystem.Models.ViewModels;

namespace PoultryFarmSystem.Controllers;

public class BatchController : Controller
{
    private readonly ApplicationDbContext _db;

    public BatchController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index(string batchNumberFilter, string arrivedFilter)
    {
        var batches = _db.Batches.AsQueryable();

        if (!string.IsNullOrEmpty(batchNumberFilter))
        {
            batches = batches.Where(b => b.BatchNumber.Contains(batchNumberFilter));
        }

        if (!string.IsNullOrEmpty(arrivedFilter))
        {
            bool isArrived = arrivedFilter == "true";
            batches = batches.Where(b => b.IsArrived == isArrived);
        }

        var viewModel = new BatchFilterVM
        {
            BatchNumberFilter = batchNumberFilter,
            ArrivedFilter = arrivedFilter,
            Batches = batches.ToList()
        };
    
        return View(viewModel);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.BirdTypes = GetBirdTypeSelectList();
        ViewBag.SourceTypes = GetSourceTypeSelectList();
    
        return View(new Batch());
    }

    [HttpPost]
    public IActionResult Create(Batch model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.BirdTypes = GetBirdTypeSelectList();
            ViewBag.SourceTypes = GetSourceTypeSelectList();
            return View(model);
        }
        
        model.BatchNumber = model.GenerateBatchNumber();

        _db.Batches.Add(model);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var batch = _db.Batches.Find(id);
        if (batch == null)
        {
            return NotFound();
        }

        ViewBag.BirdTypes = GetBirdTypeSelectList();
        ViewBag.SourceTypes = GetSourceTypeSelectList();
    
        return View(batch);
    }
    
    [HttpPost]
    public IActionResult Update(Batch model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.BirdTypes = GetBirdTypeSelectList();
            ViewBag.SourceTypes = GetSourceTypeSelectList();
            return View(model);
        }
        
        model.BatchNumber = model.GenerateBatchNumber();
        
        _db.Batches.Update(model);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var batch = _db.Batches.Find(id);
        if (batch == null)
        {
            return NotFound();
        }
        return View(batch);
    }

    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var batch = _db.Batches.Find(id);
        if (batch == null)
        {
            return NotFound();
        }

        _db.Batches.Remove(batch);
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

    private SelectList GetSourceTypeSelectList()
    {
        return new SelectList(Enum.GetValues<SourceType>()
            .Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }), "Value", "Text");
    }
}