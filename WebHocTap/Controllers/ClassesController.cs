using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.Data;
using WebHocTap.Entity;

namespace WebHocTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly Context _context;

        public ClassesController(Context context)
        {
            _context = context;
        }

        // GET: api/Classes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            if (_context.Classes == null)
            {
                return NotFound();
            }
            return await _context.Classes.ToListAsync();
        }

        // GET: api/Classes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass(string id)
        {
            if (_context.Classes == null)
            {
                return NotFound();
            }
            var @class = await _context.Classes.FindAsync(id);

            if (@class == null)
            {
                return NotFound();
            }

            return @class;
        }

        // PUT: api/Classes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(string id, Class @class)
        {
            if (id != @class.classId)
            {
                return BadRequest();
            }

            _context.Entry(@class).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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

        // POST: api/Classes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Class>> PostClass(Class @class)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'Context.Classes'  is null.");
            }
            _context.Classes.Add(@class);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClassExists(@class.classId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClass", new { id = @class.classId }, @class);
        }

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(string id)
        {
            if (_context.Classes == null)
            {
                return NotFound();
            }
            var @class = await _context.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(@class);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassExists(string id)
        {
            return (_context.Classes?.Any(e => e.classId == id)).GetValueOrDefault();
        }
    }
}
