using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PM.Data;
using PM.Models.ViewModels;
using System.Security.Claims;

namespace PM.Controllers
{
    public class BOQsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BOQsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BOQs
        public async Task<IActionResult> Index(int? projectId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewBag.projects = _context.Projects.Where(x => x.OwnerId == userId).Select(c => new SelectListItem(c.ProjectName, c.Id.ToString())).ToList();

            var applicationDbContext = _context.BOQs.Include(b => b.Project).Where(b => b.Project.OwnerId == userId);
            if (projectId != null)
            {
                applicationDbContext = applicationDbContext.Where(b => b.ProjectId == projectId);
            }
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bOQ = await _context.BOQs.FindAsync(id);
            if (bOQ == null)
            {
                return NotFound();
            }

            var boqViewModel = new BOQViewModel
            {
                Name = bOQ.Name,
                Cost = bOQ.Cost,
                Quantity = bOQ.Quantity,
                Id = bOQ.Id,
                Unit = bOQ.Unit
            };

            return View(boqViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BOQViewModel bOQ)
        {
            if (id != bOQ.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return View(bOQ);

            var updatedBOQ = await _context.BOQs.FindAsync(bOQ.Id);

            if (updatedBOQ == null)
            {
                return NotFound();
            }

            updatedBOQ.Name = bOQ.Name;
            updatedBOQ.Quantity = bOQ.Quantity;
            updatedBOQ.Cost = bOQ.Cost;
            updatedBOQ.Unit = bOQ.Unit;

            _context.Update(updatedBOQ);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
