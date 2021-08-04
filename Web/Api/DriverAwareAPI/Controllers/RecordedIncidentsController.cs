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
    public class RecordedIncidentsController : ControllerBase
    {
        private readonly DriverAwareDB_1Context _context;

        public RecordedIncidentsController(DriverAwareDB_1Context context)
        {
            _context = context;
        }

        // GET: api/Everythings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecordedIncident>>> GetRecordedIncidents()
        {
            return await _context.RecordedIncidents.ToListAsync();
        }

        // GET: api/Everythings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecordedIncident>> GetRecordedIncident(int id)
        {
            var recordedIncident = await _context.RecordedIncidents.FindAsync(id);

            if (recordedIncident == null)
            {
                return NotFound();
            }

            return recordedIncident;
        }

        // PUT: api/Everythings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordedIncident(int id, RecordedIncident recordedIncident)
        {
            if (id != recordedIncident.Id)
            {
                return BadRequest();
            }

            _context.Entry(recordedIncident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordedIncidentExists(id))
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

        // POST: api/Everythings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecordedIncident>> PostRecordedIncident(RecordedIncident recordedIncident)
        {
            _context.RecordedIncidents.Add(recordedIncident);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecordedIncident), new { id = recordedIncident.Id }, recordedIncident);
        }

        // DELETE: api/Everythings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecordedIncident(int id)
        {
            var recordedIncident = await _context.RecordedIncidents.FindAsync(id);
            if (recordedIncident == null)
            {
                return NotFound();
            }

            _context.RecordedIncidents.Remove(recordedIncident);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecordedIncidentExists(int id)
        {
            return _context.RecordedIncidents.Any(e => e.Id == id);
        }
    }
}
