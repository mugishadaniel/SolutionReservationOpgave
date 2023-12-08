using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Model
{
    public class RestaurantEF
    {
        public RestaurantEF() { }
        public string Name { get; set; }
        public LocationEF Location { get; set; }
        public string Keuken { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
