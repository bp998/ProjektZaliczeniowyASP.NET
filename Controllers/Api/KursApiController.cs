using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowyASP.NET.Data;
using ProjektZaliczeniowyASP.NET.Models;

namespace ProjektZaliczeniowyASP.NET.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class KursApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KursApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KursModel>>> GetCourses()
        {
            return await _context.Kursy.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KursModel>> GetCourse(int id)
        {
            var kurs = await _context.Kursy.FindAsync(id);
            if (kurs == null)
            {
                return NotFound();
            }
            return kurs;
        }

        [HttpPost]
        public async Task<ActionResult<KursModel>> CreateCourse(KursModel kurs)
        {
            _context.Kursy.Add(kurs);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCourse), new { id = kurs.Id }, kurs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, KursModel kurs)
        {
            if (id != kurs.Id)
            {
                return BadRequest();
            }

            _context.Entry(kurs).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var kurs = await _context.Kursy.FindAsync(id);
            if (kurs == null)
            {
                return NotFound();
            }

            _context.Kursy.Remove(kurs);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
