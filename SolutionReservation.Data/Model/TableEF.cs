using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Model
{
    public class TableEF
    {
        [Key]
        public int TableID { get; set; }
        public int Seats { get; set; }
        public int RestaurantId { get; set; }

    }
}
