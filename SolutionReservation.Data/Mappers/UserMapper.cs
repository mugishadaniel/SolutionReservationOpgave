using SolutionReservation.Data.Model;
using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Mappers
{
    public class UserMapper
    {
        public static User ToUser(UserEF userEF)
        {
            return new User(userEF.ClientNumber, userEF.Name, userEF.Email, userEF.Phone, LocationMapper.ToLocation(userEF.Location),userEF.IsActive);
        }

        public static UserEF ToUserEF(User user)
        {
            return new UserEF { ClientNumber = user.Clientnumber, Name = user.Name, Email = user.Email, Phone = user.Phone, Location = LocationMapper.ToLocationEF(user.Location),IsActive = user.IsActive};
        }

        public static UserEF updateUserEF(UserEF userEF, User user)
        {
            userEF.Name = user.Name;
            userEF.Email = user.Email;
            userEF.Phone = user.Phone;
            userEF.Location.Street = user.Location.Street;
            userEF.Location.HouseNumber = user.Location.HouseNumber;
            userEF.Location.PostalCode = user.Location.PostalCode;
            userEF.Location.Municipality = user.Location.Municipality;
            return userEF;
        }
    }
}
