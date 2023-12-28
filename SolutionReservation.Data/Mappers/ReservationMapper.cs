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
            return new Reservation(reservationEF.ReservationNumber, RestaurantMapper.ToRestaurant(reservationEF.Restaurant), UserMapper.ToUser(reservationEF.User), reservationEF.NumberofSeats, reservationEF.DateTime,reservationEF.TableNumber);
        }

        public static ReservationEF ToReservationEF(Reservation reservation)
        {
            return new ReservationEF() { ReservationNumber = reservation.ReservationNumber, Restaurant = RestaurantMapper.ToRestaurantEF(reservation.Restaurant), User = UserMapper.ToUserEF(reservation.Contactperson), NumberofSeats = reservation.NumberofSeats, DateTime = reservation.DateTime, TableNumber = reservation.TableNumber };
        }

        public static ReservationEF UpdateReservationEF(ReservationEF reservationEF, Reservation reservation)
        {
            reservationEF.NumberofSeats = reservation.NumberofSeats;
            reservationEF.DateTime = reservation.DateTime;
            reservationEF.TableNumber = reservation.TableNumber;
            return reservationEF;
        }
    }
}
