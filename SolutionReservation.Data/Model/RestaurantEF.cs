using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Model
{
    public class RestaurantEF
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationEF Location { get; set; }
        public string Keuken { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<TableEF> Tables { get; set; }

        public bool IsActive { get; set; }
    }
}
