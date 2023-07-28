using BookingHotels.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingHotels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;

        public HotelController( ILogger<HotelController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetHotelById(int id)
        {
           
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            return Created("", hotel);
        }

        [Route("id")]
        [HttpPut]
        public IActionResult UpdateHotel([FromBody] Hotel updatedHotel, int id)
        {
            return NoContent();
        }

        [Route("id")]
        [HttpDelete]
        public IActionResult DeleteHotelById(int id)
        {
            return NoContent();
        }
    }
}
