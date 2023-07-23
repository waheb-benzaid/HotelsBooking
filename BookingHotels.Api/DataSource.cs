using BookingHotels.Domain.Models;

namespace BookingHotels.Api
{
    public class DataSource
    {
        public DataSource()
        {
            Hotels = GetHotels();
        }

        public List<Hotel> Hotels { get; set; }

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
