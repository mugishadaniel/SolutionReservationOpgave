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
    }
}
