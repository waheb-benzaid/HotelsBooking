using BookingHotels.Dal;
using BookingHotels.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingHotels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly DataContext _context;

        public HotelController(ILogger<HotelController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return Ok(hotels);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);

            return Ok(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.HotelId }, hotel);
        }

        [Route("id")]
        [HttpPut]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel updatedHotel, int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);
            hotel.Stars = updatedHotel.Stars;
            hotel.Description = updatedHotel.Description;
            hotel.Name = updatedHotel.Name;

            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("id")]
        [HttpDelete]
        public async Task<IActionResult> DeleteHotelById(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
