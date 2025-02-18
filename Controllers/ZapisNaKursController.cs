﻿using Microsoft.AspNetCore.Mvc;
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
            return View( new ZapisNaKursModel() );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ZapisNaKursModel zapisNaKurs)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState.IsValid = false");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("Błąd walidacji: " + error.ErrorMessage);
                }
                ViewData["StudentId"] = new SelectList(_context.Studenci, "Id", "Imie", zapisNaKurs.StudentId);
                ViewData["KursId"] = new SelectList(_context.Kursy, "Id", "Nazwa", zapisNaKurs.KursId);
                return View(zapisNaKurs);
            }

            try
            {
                _context.ZapisyNaKurs.Add(zapisNaKurs);
                await _context.SaveChangesAsync();
                Console.WriteLine("Student zapisany na kurs!");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd zapisu do bazy: " + ex.Message);
                return View(zapisNaKurs);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var zapis = await _context.ZapisyNaKurs.FindAsync(id);
            if (zapis == null) return NotFound();

            ViewData["StudentId"] = new SelectList(_context.Studenci, "Id", "Imie", zapis.StudentId);
            ViewData["KursId"] = new SelectList(_context.Kursy, "Id", "Nazwa", zapis.KursId);

            return View(zapis);
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
