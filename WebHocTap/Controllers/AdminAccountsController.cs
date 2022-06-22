using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.Data;
using WebHocTap.Entity;

namespace WebHocTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAccountsController : ControllerBase
    {
        private readonly Context _context;

        public AdminAccountsController(Context context)
        {
            _context = context;
        }

        // GET: api/AdminAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminAccount>>> GetAdminAccounts()
        {
            if (_context.AdminAccounts == null)
            {
                return NotFound();
            }
            return await _context.AdminAccounts.ToListAsync();
        }

        // GET: api/AdminAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminAccount>> GetAdminAccount(string id)
        {
            if (_context.AdminAccounts == null)
            {
                return NotFound();
            }
            var adminAccount = await _context.AdminAccounts.FindAsync(id);

            if (adminAccount == null)
            {
                return NotFound();
            }

            return adminAccount;
        }

        // PUT: api/AdminAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminAccount(string id, AdminAccount adminAccount)
        {
            if (id != adminAccount.userName)
            {
                return BadRequest();
            }

            _context.Entry(adminAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminAccountExists(id))
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

        // POST: api/AdminAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminAccount>> PostAdminAccount(AdminAccount adminAccount)
        {
            if (_context.AdminAccounts == null)
            {
                return Problem("Entity set 'Context.AdminAccounts'  is null.");
            }
            _context.AdminAccounts.Add(adminAccount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdminAccountExists(adminAccount.userName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdminAccount", new { id = adminAccount.userName }, adminAccount);
        }

        // DELETE: api/AdminAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminAccount(string id)
        {
            if (_context.AdminAccounts == null)
            {
                return NotFound();
            }
            var adminAccount = await _context.AdminAccounts.FindAsync(id);
            if (adminAccount == null)
            {
                return NotFound();
            }

            _context.AdminAccounts.Remove(adminAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminAccountExists(string id)
        {
            return (_context.AdminAccounts?.Any(e => e.userName == id)).GetValueOrDefault();
        }
    }
}
