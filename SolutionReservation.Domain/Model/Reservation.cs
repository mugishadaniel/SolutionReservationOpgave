using SolutionReservation.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Domain.Model
{
    public class Reservation
    {
        public Reservation(int reservationNumber, Restaurant restaurant, string contactperson, int numberofSeats, DateTime dateTime, int tableNumber)
        {
            SetReservationNumber(reservationNumber);
            SetRestaurant(restaurant);
            SetContactperson(contactperson);
            SetNumberofSeats(numberofSeats);
            SetDateTime(dateTime);
            SetTableNumber(tableNumber);
        }

        public int ReservationNumber { get; private set; }
        public Restaurant Restaurant { get; private set; }
        public string Contactperson { get; private set; }
        public int NumberofSeats { get; private set; }
        public DateTime DateTime { get; private set; }
        public int TableNumber { get; private set; }

        public void SetReservationNumber(int reservationNumber)
        {
            if (reservationNumber < 0) throw new ReservationException("ReservationNumber is invalid");
            ReservationNumber = reservationNumber;
        }

        public void SetRestaurant(Restaurant restaurant)
        {
            if (restaurant is null) throw new ReservationException("Restaurant is invalid");
            Restaurant = restaurant;
        }

        public void SetContactperson(string contactperson)
        {
            if (string.IsNullOrEmpty(contactperson)) throw new ReservationException("Contactperson is invalid");
            Contactperson = contactperson;
        }

        public void SetNumberofSeats(int numberofSeats)
        {
            if (numberofSeats < 0) throw new ReservationException("NumberofSeats is invalid");
            NumberofSeats = numberofSeats;
        }

        public void SetDateTime(DateTime dateTime)
        {
            if (dateTime == null || dateTime < DateTime.Now) throw new ReservationException("DateTime is invalid");
            DateTime = dateTime;
        }

        public void SetTableNumber(int tableNumber)
        {
            if (tableNumber < 0) throw new ReservationException("TableNumber is invalid");
            TableNumber = tableNumber;
        }
    }
}
