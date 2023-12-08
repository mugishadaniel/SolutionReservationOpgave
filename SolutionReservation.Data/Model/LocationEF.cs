using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Model
{
    public class LocationEF
    {
        public LocationEF() { }
        public int PostalCode { get; set; }
        public string Municipality { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
    }
}
