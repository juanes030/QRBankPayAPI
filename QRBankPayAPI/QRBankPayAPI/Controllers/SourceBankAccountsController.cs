using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRBankPayAPI.Data;
using QRBankPayAPI.Data.Models;

namespace QRBankPayAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SourceBankAccountsController : ControllerBase
    {
        private readonly QRBankPayDbContext _context;

        public SourceBankAccountsController(QRBankPayDbContext context)
        {
            _context = context;
        }

        // GET: api/SourceBankAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SourceBankAccount>>> GetSourceBankAccount()
        {
          if (_context.SourceBankAccount == null)
          {
              return NotFound();
          }
            return await _context.SourceBankAccount.ToListAsync();
        }

        // GET: api/SourceBankAccounts/5
        [HttpGet("{documento}")]
        public async Task<ActionResult<SourceBankAccount>> GetSourceBankAccount(string documento)
        {
          if (_context.SourceBankAccount == null)
          {
              return NotFound();
          }
            var sourceBankAccount = await _context.SourceBankAccount.FirstOrDefaultAsync(p => p.Dna == documento);

            if (sourceBankAccount == null)
            {
                return NotFound();
            }

            return sourceBankAccount;
        }

        // PUT: api/SourceBankAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSourceBankAccount(long id, SourceBankAccount sourceBankAccount)
        {
            if (id != sourceBankAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(sourceBankAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SourceBankAccountExists(id))
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

        // POST: api/SourceBankAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SourceBankAccount>> PostSourceBankAccount(SourceBankAccount sourceBankAccount)
        {
          if (_context.SourceBankAccount == null)
          {
              return Problem("Entity set 'QRBankPayDbContext.SourceBankAccount'  is null.");
          }
            _context.SourceBankAccount.Add(sourceBankAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSourceBankAccount", new { id = sourceBankAccount.Id }, sourceBankAccount);
        }

        // DELETE: api/SourceBankAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSourceBankAccount(long id)
        {
            if (_context.SourceBankAccount == null)
            {
                return NotFound();
            }
            var sourceBankAccount = await _context.SourceBankAccount.FindAsync(id);
            if (sourceBankAccount == null)
            {
                return NotFound();
            }

            _context.SourceBankAccount.Remove(sourceBankAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SourceBankAccountExists(long id)
        {
            return (_context.SourceBankAccount?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
