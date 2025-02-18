using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowyASP.NET.Data;
using ProjektZaliczeniowyASP.NET.Models;

namespace ProjektZaliczeniowyASP.NET.Controllers
{
    public class KursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KursController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kursy = await _context.Kursy.ToListAsync();
            return View(kursy);
        }

        public IActionResult Create()
        {
            return View( new KursModel() );
        }

        [HttpPost]
        public async Task<IActionResult> Create(KursModel kurs)
        {
            if (ModelState.IsValid)
            {
                _context.Kursy.Add(kurs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kurs);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var kurs = await _context.Kursy.FindAsync(id);
            if (kurs == null) return NotFound();
            return View(kurs);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(KursModel kurs)
        {
            if (ModelState.IsValid)
            {
                _context.Kursy.Update(kurs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kurs);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var kurs = await _context.Kursy.FindAsync(id);
            if (kurs == null) return NotFound();
            return View(kurs);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kurs = await _context.Kursy.FindAsync(id);
            if (kurs != null)
            {
                _context.Kursy.Remove(kurs);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
