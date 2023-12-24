namespace SolutionReservation.API.DTO.Input
{
    public class ReservationInputDTO
    {
        public ReservationInputDTO()
        {
        }
        public int NumberofSeats { get; set; }
        public DateTime DateTime { get; set; }
        public int TableNumber { get; set; }
    }
}
