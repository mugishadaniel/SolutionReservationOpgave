namespace SolutionReservation.API.DTO.Input
{
    public class UserInputDTO
    {
        public UserInputDTO()
        {
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PostalCode { get; set; }
        public string Municipality { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }

    }
}
