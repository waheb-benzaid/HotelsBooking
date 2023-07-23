using BookingHotels.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly DataSource _dataSource;
        public HotelController(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var hotels = _dataSource;
            return Ok(hotels);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotels = _dataSource.Hotels;
            var hotel = hotels.FirstOrDefault(h => h.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            var hotels = _dataSource.Hotels;
            hotels.Add(hotel);
            return Created("", hotel);
        }

        [Route("id")]
        [HttpPut]
        public IActionResult UpdateHotel([FromBody] Hotel updatedHotel, int id)
        {
            var hotels = _dataSource.Hotels;
            var oldHotel = hotels.FirstOrDefault(h => h.HotelId == id);
            hotels.Remove(oldHotel);
            hotels.Add(updatedHotel);
            return NoContent();
        }

        [Route("id")]
        [HttpDelete]
        public IActionResult DeleteHotelById(int id)
        {
            var hotels = _dataSource.Hotels;
            var hotelToDelete = hotels.FirstOrDefault(h => h.HotelId == id);
            if (hotelToDelete == null) return NotFound();
            hotels.Remove(hotelToDelete);
            return NoContent();
        }
    }
}
