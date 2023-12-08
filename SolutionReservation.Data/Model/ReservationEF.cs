using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Model
{
    public class ReservationEF
    {
        public ReservationEF() { }
        public int ReservationNumber { get; set; }
        public RestaurantEF Restaurant { get; set; }
        public string Contactperson { get; set; }
        public int NumberofSeats { get; set; }
        public DateTime DateTime { get; set; }
        public int TableNumber { get; set; }
    }
}
