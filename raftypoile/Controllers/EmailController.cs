using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using raftypoile.Models;

namespace raftypoile.Controllers
{
    [Route("api/Email")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly raftypoileidlvContext _context;
        public EmailController(raftypoileidlvContext context) => _context = context;
        //To Protect Data from unauthorised access, HTTP GET function is disabled as default.
        // Function is only used during testing of API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmails()
        {
            //return Redirect("/");
            return await _context.Emails.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmail(int id, Email email)
        {
            if (id != email.IdEmail) return BadRequest();

            _context.Entry(email).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // GET: api/Emails/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Email>> GetEmail(int id)
        {
            var email = await _context.Emails.FindAsync(id);

            if (email == null) return NotFound();

            return email;
        }

        // POST: api/Emails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Email>> PostEmail(Email email)
        {
            _context.Emails.Add(email);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmail", new {id = email.IdEmail}, email);
        }

        private bool EmailExists(int id)
        {
            return _context.Emails.Any(e => e.IdEmail == id);
        }
    }
}