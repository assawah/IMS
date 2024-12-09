using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PM.Data;
using PM.Models;
using PM.Models.ViewModels;
using System.Security.Claims;

namespace PM.Controllers
{
    public class ScopePackageDepartmentsController(ApplicationDbContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound("user Not Found");
            }

            var scopePackage = await context.ScopePackages.FirstOrDefaultAsync(x => x.ManagerEmail == user.Email);

            if (scopePackage == null)
            {
                return NotFound("Scope Package Not Found");
            }

            var scopePackageDepartments = context.ScopePackageDepartments.Include(c => c.Project).Where(x => x.ScopePackageId == scopePackage.Id);

            return View(await scopePackageDepartments.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound("user Not Found");
            }

            var projects = await context.Projects
                .Include(s => s.ScopePackages)
                .Where(f => f.ScopePackages.Any(x => x.ManagerEmail == user.Email)).ToListAsync();

            ViewBag.projects = projects.Select(c => new SelectListItem(c.ProjectName, c.Id.ToString()));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScopePackageDepartmentViewModel scopePackageDepartmentViewModel)
        {
            if (!scopePackageDepartmentViewModel.projectId.HasValue)
            {
                ModelState.AddModelError("projectId", "Project is required");
            }

            if (!ModelState.IsValid) return View(scopePackageDepartmentViewModel);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound("user Not Found");
            }

            var scopePackage = await context.ScopePackages.FirstOrDefaultAsync(x => x.ManagerEmail == user.Email);

            if (scopePackage == null)
            {
                return NotFound("Scope Package Not Found");
            }

            context.Add(new ScopePackageDepartment
            {
                Name = scopePackageDepartmentViewModel.Name,
                Description = scopePackageDepartmentViewModel.Description,
                ScopePackageId = scopePackage.Id,
                ProjectId = scopePackageDepartmentViewModel.projectId!.Value
            });

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scopePackageDepartment = await context.ScopePackageDepartments.FindAsync(id);

            if (scopePackageDepartment == null)
            {
                return NotFound();
            }

            return View(new ScopePackageDepartmentViewModel()
            {
                Id = scopePackageDepartment.Id,
                Name = scopePackageDepartment.Name,
                Description = scopePackageDepartment.Description
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ScopePackageDepartmentViewModel scopePackageDepartmentViewModel)
        {
            if (id != scopePackageDepartmentViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(scopePackageDepartmentViewModel);
            }

            var scopePackageDepartment = await context.ScopePackageDepartments.FindAsync(id);

            if (scopePackageDepartment == null)
            {
                return NotFound();
            }

            scopePackageDepartment.Name = scopePackageDepartmentViewModel.Name;
            scopePackageDepartment.Description = scopePackageDepartmentViewModel.Description;

            context.Update(scopePackageDepartment);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scopePackageDepartment = await context.ScopePackageDepartments.FindAsync(id);
            if (scopePackageDepartment != null)
            {
                context.ScopePackageDepartments.Remove(scopePackageDepartment);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
