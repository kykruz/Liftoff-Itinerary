using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Itinerary_Designer;
using Trips.Data;
using Trips.Models;
using Itinerary.Models; 
// make

namespace Itinerary_Designer.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationApiController : ControllerBase
    {
        private readonly TripDbContext _context;

        public LocationApiController(TripDbContext context)
        {
            _context = context;
        }

        // GET: api/LocationApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationData>>> GetLocationData()
        {
            return await _context.LocationData.ToListAsync();
        }

        // GET: api/LocationApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationData>> GetLocationData(int id)
        {
            var locationData = await _context.LocationData.FindAsync(id);

            if (locationData == null)
            {
                return NotFound();
            }

            return locationData;
        }

        // PUT: api/LocationApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationData(int id, LocationData locationData)
        {
            if (id != locationData.Id)
            {
                return BadRequest();
            }

            _context.Entry(locationData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationDataExists(id))
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

        // POST: api/LocationApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocationData>> PostLocationData(LocationData locationData)
        {
            _context.LocationData.Add(locationData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocationData", new { id = locationData.Id }, locationData);
        }

        // DELETE: api/LocationApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationData(int id)
        {
            var locationData = await _context.LocationData.FindAsync(id);
            if (locationData == null)
            {
                return NotFound();
            }

            _context.LocationData.Remove(locationData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationDataExists(int id)
        {
            return _context.LocationData.Any(e => e.Id == id);
        }
    }
}