using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Client.UseroutputDTOs
{
    public class LocationoutputDTO
    {
        public LocationoutputDTO() { }
        public int locationId { get; set; }
        public int postalcode { get; set; }
        public string municipality { get; set; }
        public string street { get; set; }
        public string housenumber { get; set; }
    }
}
