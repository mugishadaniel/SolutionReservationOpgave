using SolutionReservation.API.DTO.Input;
using SolutionReservation.Domain.Model;

namespace SolutionReservation.API.MapperDTO
{
    public class ReservationMapperDTO
    {
        public static Reservation ToDomain(ReservationInputDTO reservationInputDTO)
        {
            return new Reservation(reservationInputDTO.NumberofSeats,reservationInputDTO.DateTime,reservationInputDTO.TableNumber);
        }

        public static ReservationInputDTO UpdateReservation(Reservation reservationFromDb, ReservationInputDTO reservation)
        {
            if (reservation.NumberofSeats == 0) reservation.NumberofSeats = reservationFromDb.NumberofSeats;
            if (reservation.DateTime == null) reservation.DateTime = reservationFromDb.DateTime;
            if (reservation.TableNumber == 0) reservation.TableNumber = reservationFromDb.TableNumber;
            return reservation;
        }
    }
}
