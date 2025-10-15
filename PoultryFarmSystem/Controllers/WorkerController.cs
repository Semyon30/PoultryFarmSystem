using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoultryFarmSystem.Data;
using PoultryFarmSystem.Models.Entities;
using PoultryFarmSystem.Models.Enums;
using PoultryFarmSystem.Models.ViewModels;

namespace PoultryFarmSystem.Controllers;

public class WorkerController : Controller
{
    private readonly ApplicationDbContext _db;

    public WorkerController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index(string nameFilter, string typeFilter)
    {
        var workers = _db.Workers.AsQueryable();

        if (!string.IsNullOrEmpty(nameFilter))
        {
            workers = workers.Where(w =>
                w.FirstName.Contains(nameFilter) ||
                w.LastName.Contains(nameFilter) ||
                (w.MiddleName != null && w.MiddleName.Contains(nameFilter)));
        }

        if (!string.IsNullOrEmpty(typeFilter))
        {
            workers = workers.Where(w => w.Type.ToString() == typeFilter);
        }

        var viewModel = new WorkerFilterVM
        {
            NameFilter = nameFilter,
            TypeFilter = typeFilter,
            Workers = workers.ToList()
        };
    
        return View(viewModel);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.WorkerTypes  = GetWorkerTypeSelectList();
        
        return View(new Worker());
    }
    
    [HttpPost]
    public IActionResult Create(Worker model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.WorkerTypes  = GetWorkerTypeSelectList();
            return View(model);
        }
    
        _db.Workers.Add(model);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var worker = _db.Workers.Find(id);
        if (worker == null)
        {
            return NotFound();
        }

        ViewBag.WorkerTypes = GetWorkerTypeSelectList();
        return View(worker);
    }

    [HttpPost]
    public IActionResult Update(Worker model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.WorkerTypes = GetWorkerTypeSelectList();
            return View(model);
        }
        
        _db.Workers.Update(model);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var worker = _db.Workers.Find(id);
        if (worker == null)
        {
            return NotFound();
        }
        return View(worker);
    }
    
    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var worker = _db.Workers.Find(id);
        if (worker == null)
        {
            return NotFound();
        }

        _db.Workers.Remove(worker);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    
    private SelectList GetWorkerTypeSelectList()
    {
        return new SelectList(Enum.GetValues<WorkerType>()
            .Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }), "Value", "Text");
    }
}