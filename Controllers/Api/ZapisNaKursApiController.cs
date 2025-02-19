using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowyASP.NET.Data;
using ProjektZaliczeniowyASP.NET.Models;

namespace ProjektZaliczeniowyASP.NET.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZapisNaKursApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ZapisNaKursApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZapisNaKursModel>>> GetRegistrations()
        {
            return await _context.ZapisyNaKurs
                .Include(z => z.Student)
                .Include(z => z.Kurs)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZapisNaKursModel>> GetRegistration(int id)
        {
            var zapis = await _context.ZapisyNaKurs
                .Include(z => z.Student)
                .Include(z => z.Kurs)
                .FirstOrDefaultAsync(z => z.Id == id);

            if (zapis == null)
            {
                return NotFound();
            }

            return zapis;
        }

        [HttpPost]
        public async Task<ActionResult<ZapisNaKursModel>> CreateRegistration(ZapisNaKursModel zapis)
        {
            _context.ZapisyNaKurs.Add(zapis);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRegistration), new { id = zapis.Id }, zapis);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var zapis = await _context.ZapisyNaKurs.FindAsync(id);
            if (zapis == null)
            {
                return NotFound();
            }

            _context.ZapisyNaKurs.Remove(zapis);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
