using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Model
{
    public class UserEF
    {
        [Key]
        public int ClientNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public LocationEF Location { get; set; }
        public bool IsActive { get; set; }
    }
}
