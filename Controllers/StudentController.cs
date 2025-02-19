using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowyASP.NET.Data;
using ProjektZaliczeniowyASP.NET.Models;

namespace ProjektZaliczeniowyASP.NET.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Studenci.ToListAsync();
            return View(students);
        }

        public IActionResult Create()
        {
            return View( new StudentModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                _context.Studenci.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine("Błąd walidacji: " + error.ErrorMessage);
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Studenci.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                _context.Studenci.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Studenci.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Studenci.FindAsync(id);
            if (student != null)
            {
                _context.Studenci.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
