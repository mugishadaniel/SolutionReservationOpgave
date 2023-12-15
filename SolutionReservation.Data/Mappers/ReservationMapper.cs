using SolutionReservation.Domain.Model;
using SolutionReservation.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Mappers
{
    public class ReservationMapper
    {
        public static Reservation ToReservation(ReservationEF reservationEF)
        {
            return new Reservation(reservationEF.ReservationNumber, RestaurantMapper.ToRestaurant(reservationEF.Restaurant), reservationEF.Contactperson, reservationEF.NumberofSeats, reservationEF.DateTime, reservationEF.TableNumber);
        }

        public static ReservationEF ToReservationEF(Reservation reservation)
        {
            return new ReservationEF() { ReservationNumber = reservation.ReservationNumber, Restaurant = RestaurantMapper.ToRestaurantEF(reservation.Restaurant), Contactperson = reservation.Contactperson, NumberofSeats = reservation.NumberofSeats, DateTime = reservation.DateTime, TableNumber = reservation.TableNumber };
        }
    }
}
