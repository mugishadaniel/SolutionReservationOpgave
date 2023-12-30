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


        public static UserInputDTO UpdateUser(User userFromDb,UserInputDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))user.Name = userFromDb.Name;
            if (string.IsNullOrEmpty(user.Email)) user.Email = userFromDb.Email;
            if (string.IsNullOrWhiteSpace(user.Phone)) user.Phone = userFromDb.Phone;
            if (user.PostalCode == 0) user.PostalCode = userFromDb.Location.PostalCode;
            if (string.IsNullOrWhiteSpace(user.Municipality)) user.Municipality = userFromDb.Location.Municipality;
            if (string.IsNullOrWhiteSpace(user.Street)) user.Street = userFromDb.Location.Street;
            if (string.IsNullOrWhiteSpace(user.HouseNumber)) user.HouseNumber = userFromDb.Location.HouseNumber;
            return user;
        }
    }
}
