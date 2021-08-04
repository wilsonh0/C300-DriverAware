using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DriverAwareAPI.Models;

namespace DriverAwareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogInsController : ControllerBase
    {
        private readonly DriverAwareDB_1Context _context;

        public UserLogInsController(DriverAwareDB_1Context context)
        {
            _context = context;
        }

        // GET: api/UserLogIns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLogIn>>> GetUserLogIns()
        {
            return await _context.UserLogIns.ToListAsync();
        }

        // GET: api/UserLogIns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLogIn>> GetUserLogIn(int id)
        {
            var userLogIn = await _context.UserLogIns.FindAsync(id);

            if (userLogIn == null)
            {
                return NotFound();
            }

            return userLogIn;
        }

        // PUT: api/UserLogIns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLogIn(int id, UserLogIn userLogIn)
        {
            if (id != userLogIn.Id)
            {
                return BadRequest();
            }

            _context.Entry(userLogIn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLogInExists(id))
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

        // POST: api/UserLogIns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserLogIn>> PostUserLogIn(UserLogIn userLogIn)
        {
            _context.UserLogIns.Add(userLogIn);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUserLogIn", new { id = userLogIn.Id }, userLogIn);
            return CreatedAtAction(nameof(GetUserLogIn), new { id = userLogIn.Id }, userLogIn);
        }

        // DELETE: api/UserLogIns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLogIn(int id)
        {
            var userLogIn = await _context.UserLogIns.FindAsync(id);
            if (userLogIn == null)
            {
                return NotFound();
            }

            _context.UserLogIns.Remove(userLogIn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserLogInExists(int id)
        {
            return _context.UserLogIns.Any(e => e.Id == id);
        }
    }
}
