namespace SolutionReservation.API.DTO.Input
{
    public class RestaurantInputDTO
    {
        public RestaurantInputDTO()
        {
        }
        public string Name { get; set; }
        public string Keuken { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Municipality { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public int PostalCode { get; set; }
    }
}
