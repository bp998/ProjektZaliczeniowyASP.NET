using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowyASP.NET.Data;
using ProjektZaliczeniowyASP.NET.Models;

namespace ProjektZaliczeniowyASP.NET.Controllers
{
    public class ZapisNaKursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZapisNaKursController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var zapisy = await _context.ZapisyNaKurs
                .Include(z => z.Student)
                .Include(z => z.Kurs)
                .ToListAsync();
            return View(zapisy);
        }

        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Studenci, "Id", "Imie");
            ViewData["KursId"] = new SelectList(_context.Kursy, "Id", "Nazwa");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ZapisNaKursModel zapisNaKurs)
        {
            if (ModelState.IsValid)
            {
                _context.ZapisyNaKurs.Add(zapisNaKurs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zapisNaKurs);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var zapis = await _context.ZapisyNaKurs.FindAsync(id);
            if (zapis == null) return NotFound();
            return View(zapis);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zapis = await _context.ZapisyNaKurs.FindAsync(id);
            if (zapis != null)
            {
                _context.ZapisyNaKurs.Remove(zapis);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
