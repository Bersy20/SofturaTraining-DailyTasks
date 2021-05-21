using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeathersAPIProject.Models;

namespace WeathersAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        private readonly WeatherContext _context;

        public WeathersController(WeatherContext context)
        {
            _context = context;
        }

        // GET: api/Weathers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weather>>> GetWeathers()
        {
            return await _context.Weathers.ToListAsync();
        }

        // GET: api/Weathers/5
        [HttpGet("{city}")]
        public async Task<ActionResult<Weather>> GetWeather(string city)
        {
            var weather = await _context.Weathers.FindAsync(city);

            if (weather == null)
            {
                return NotFound();
            }

            return weather;
        }

        // PUT: api/Weathers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{city}")]
        public async Task<IActionResult> PutWeather(string city, Weather weather)
        {
            if (city != weather.City)
            {
                return BadRequest();
            }

            _context.Entry(weather).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(city))
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

        // POST: api/Weathers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weather>> PostWeather(Weather weather)
        {
            _context.Weathers.Add(weather);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WeatherExists(weather.City))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWeather", new { city = weather.City }, weather);
        }

        // DELETE: api/Weathers/5
        [HttpDelete("{city}")]
        public async Task<IActionResult> DeleteWeather(string city)
        {
            var weather = await _context.Weathers.FindAsync(city);
            if (weather == null)
            {
                return NotFound();
            }

            _context.Weathers.Remove(weather);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost]
        [Route("AddtWeatherByCity")]
        public async Task<IActionResult> AddWeatherByCity(string city, Weather weather)
        {
            if (city != weather.City)
            {
                return BadRequest();
            }

            _context.Entry(weather).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(city))
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
        private bool WeatherExists(string city)
        {
            return _context.Weathers.Any(e => e.City == city);
        }
    }
}
