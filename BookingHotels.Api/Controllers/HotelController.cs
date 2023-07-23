using BookingHotels.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        public HotelController()
        {

        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var hotels = GetHotels();
            return Ok(hotels);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotels = GetHotels();
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
            var hotels = GetHotels();
            hotels.Add(hotel);
            return Created("", hotel);
        }

        [Route("id")]
        [HttpPut]
        public IActionResult UpdateHotel([FromBody] Hotel updatedHotel, int id)
        {
            var hotels = GetHotels();
            var oldHotel = hotels.FirstOrDefault(h => h.HotelId == id);
            hotels.Remove(oldHotel);
            hotels.Add(updatedHotel);
            return NoContent();
        }

        [Route("id")]
        [HttpDelete]
        public IActionResult DeleteHotelById(int id)
        {
            var hotels = GetHotels();
            var hotelToDelete = hotels.FirstOrDefault(h => h.HotelId == id);
            if (hotelToDelete == null)  return NotFound();
            hotels.Remove(hotelToDelete);
            return NoContent();
        }

        private List<Hotel> GetHotels() // just for test before getting started with the database
        {
            return new List<Hotel>
            {
                new Hotel
                {
                    HotelId= 1,
                    Name="Sabri",
                    Stars = 4,
                    Country= "Algeria",
                    City="Annaba"
                },
                new Hotel
                {
                    HotelId= 2,
                    Name="Sheraton",
                    Stars=5,
                    Country="Algeria",
                    City="Annaba"
                }
            };
        }
    }
}
