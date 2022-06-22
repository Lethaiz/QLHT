using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.Data;
using WebHocTap.Entity;

namespace WebHocTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Class_CourseController : ControllerBase
    {
        private readonly Context _context;

        public Class_CourseController(Context context)
        {
            _context = context;
        }

        // GET: api/Class_Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class_Course>>> GetClass_Course()
        {
            if (_context.Class_Course == null)
            {
                return NotFound();
            }
            return await _context.Class_Course.ToListAsync();
        }

        // GET: api/Class_Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class_Course>> GetClass_Course(int id)
        {
            if (_context.Class_Course == null)
            {
                return NotFound();
            }
            var class_Course = await _context.Class_Course.FindAsync(id);

            if (class_Course == null)
            {
                return NotFound();
            }

            return class_Course;
        }

        // PUT: api/Class_Course/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass_Course(int id, Class_Course class_Course)
        {
            if (id != class_Course.lassCourseId)
            {
                return BadRequest();
            }

            _context.Entry(class_Course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Class_CourseExists(id))
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

        // POST: api/Class_Course
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Class_Course>> PostClass_Course(Class_Course class_Course)
        {
            if (_context.Class_Course == null)
            {
                return Problem("Entity set 'Context.Class_Course'  is null.");
            }
            _context.Class_Course.Add(class_Course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClass_Course", new { id = class_Course.lassCourseId }, class_Course);
        }

        // DELETE: api/Class_Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass_Course(int id)
        {
            if (_context.Class_Course == null)
            {
                return NotFound();
            }
            var class_Course = await _context.Class_Course.FindAsync(id);
            if (class_Course == null)
            {
                return NotFound();
            }

            _context.Class_Course.Remove(class_Course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Class_CourseExists(int id)
        {
            return (_context.Class_Course?.Any(e => e.lassCourseId == id)).GetValueOrDefault();
        }
    }
}
