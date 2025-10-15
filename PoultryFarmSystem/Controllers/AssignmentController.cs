using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoultryFarmSystem.Data;
using PoultryFarmSystem.Models.Entities;
using PoultryFarmSystem.Models.Enums;
using PoultryFarmSystem.Models.ViewModels;

namespace PoultryFarmSystem.Controllers;

public class AssignmentController : Controller
{
    private readonly ApplicationDbContext _db;

    public AssignmentController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public IActionResult Index(string statusFilter, string priorityFilter, string workerFilter)
    {
        var assignments = _db.Assignments
            .Include(a => a.Worker)
            .Include(a => a.Cage)
            .AsQueryable();

        if (!string.IsNullOrEmpty(statusFilter))
        {
            assignments = assignments.Where(a => a.Status.ToString() == statusFilter);
        }

        if (!string.IsNullOrEmpty(priorityFilter))
        {
            assignments = assignments.Where(a => a.Priority.ToString() == priorityFilter);
        }

        if (!string.IsNullOrEmpty(workerFilter))
        {
            assignments = assignments.Where(a => 
                a.Worker.LastName.Contains(workerFilter) ||
                a.Worker.FirstName.Contains(workerFilter) ||
                (a.Worker.MiddleName != null && a.Worker.MiddleName.Contains(workerFilter)));
        }

        var viewModel = new AssignmentFilterVM
        {
            StatusFilter = statusFilter,
            PriorityFilter = priorityFilter,
            WorkerFilter = workerFilter,
            Assignments = assignments.ToList()
        };
    
        return View(viewModel);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Workers = GetWorkersSelectList();
        ViewBag.Cages = GetCagesSelectList();
        ViewBag.Statuses = GetStatusSelectList();
        ViewBag.Priorities = GetPrioritySelectList();
    
        return View(new Assignment());
    }

    [HttpPost]
    public IActionResult Create(Assignment model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Workers = GetWorkersSelectList();
            ViewBag.Cages = GetCagesSelectList();
            ViewBag.Statuses = GetStatusSelectList();
            ViewBag.Priorities = GetPrioritySelectList();
            return View(model);
        }

        _db.Assignments.Add(model);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var assignment = _db.Assignments
            .Include(a => a.Worker)
            .Include(a => a.Cage)
            .FirstOrDefault(a => a.Id == id);
        
        if (assignment == null)
        {
            return NotFound();
        }

        ViewBag.Workers = GetWorkersSelectList();
        ViewBag.Cages = GetCagesSelectList();
        ViewBag.Statuses = GetStatusSelectList();
        ViewBag.Priorities = GetPrioritySelectList();
    
        return View(assignment);
    }

    [HttpPost]
    public IActionResult Update(Assignment model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Workers = GetWorkersSelectList();
            ViewBag.Cages = GetCagesSelectList();
            ViewBag.Statuses = GetStatusSelectList();
            ViewBag.Priorities = GetPrioritySelectList();
            return View(model);
        }

        _db.Assignments.Update(model);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var assignment = _db.Assignments
            .Include(a => a.Worker)
            .Include(a => a.Cage)
            .FirstOrDefault(a => a.Id == id);
        
        if (assignment == null)
        {
            return NotFound();
        }
        return View(assignment);
    }

    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var assignment = _db.Assignments.Find(id);
        if (assignment == null)
        {
            return NotFound();
        }

        _db.Assignments.Remove(assignment);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }

    private SelectList GetWorkersSelectList()
    {
        var workers = _db.Workers
            .Select(w => new SelectListItem
            {
                Value = w.Id.ToString(),
                Text = $"{w.LastName} {w.FirstName} {w.MiddleName} - {w.Type}"
            }).ToList();
    
        return new SelectList(workers, "Value", "Text");
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

    private SelectList GetStatusSelectList()
    {
        return new SelectList(Enum.GetValues<AssignmentStatus>()
            .Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }), "Value", "Text");
    }

    private SelectList GetPrioritySelectList()
    {
        return new SelectList(Enum.GetValues<PriorityLevel>()
            .Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }), "Value", "Text");
    }
}