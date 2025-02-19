using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowyASP.NET.Data;
using ProjektZaliczeniowyASP.NET.Models;

namespace ProjektZaliczeniowyASP.NET.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudents()
        {
            return await _context.Studenci.ToListAsync();
        }

        // GET: api/StudentApi/id
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudent(int id)
        {
            var student = await _context.Studenci.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST: api/StudentApi
        [HttpPost]
        public async Task<ActionResult<StudentModel>> CreateStudent(StudentModel student)
        {
            _context.Studenci.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT: api/StudentApi/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentModel student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/StudentApi/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Studenci.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Studenci.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Studenci.Any(e => e.Id == id);
        }
    }
}
