using SolutionReservation.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Domain.Model
{
    public class Table
    {
        public Table(int id, int seats)
        {
            SetId(id);
            SetSeats(seats);
        }
        public int TableID { get;private set; }
        public int Seats { get;private  set; }
        public int RestaurantId { get;private set; }

        public void SetId(int id)
        {
            if (id == 0) throw new RestaurantException("Id is invalid");
            TableID = id;
        }

        public void SetSeats(int seats)
        {
            if (seats == 0) throw new RestaurantException("Seats is invalid");
            Seats = seats;
        }
    }
}
