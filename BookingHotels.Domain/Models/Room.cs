using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotels.Domain.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public int RoomNumber { get; set; }

        public double Surface { get; set; }

        public bool NeedsRepair { get; set; }

        public bool IsAvailable { get; set; }
    }
}
