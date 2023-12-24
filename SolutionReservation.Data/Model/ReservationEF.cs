using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Model
{
    public class ReservationEF
    {
        [Key]
        public int ReservationNumber { get; set; }
        public RestaurantEF Restaurant { get; set; }
        public UserEF Contactperson { get; set; }
        public int NumberofSeats { get; set; }
        public DateTime DateTime { get; set; }
        public int TableNumber { get; set; }
    }
}
