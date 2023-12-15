using SolutionReservation.API.DTO.Input;
using SolutionReservation.Domain.Model;

namespace SolutionReservation.API.MapperDTO
{
    public class UserMapperDTO
    {
        public static User ToDomain(UserInputDTO userInputDTO)
        {
            return new User(userInputDTO.Name,userInputDTO.Email,userInputDTO.Phone,new Location(userInputDTO.PostalCode,userInputDTO.Municipality,userInputDTO.Street,userInputDTO.HouseNumber));
        }
    }
}
