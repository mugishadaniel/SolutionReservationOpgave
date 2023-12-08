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
            return new User(userEF.ClientNumber, userEF.Name, userEF.Email, userEF.Phone, LocationMapper.ToLocation(userEF.Location));
        }

        public static UserEF ToUserEF(User user)
        {
            return new UserEF { ClientNumber = user.Clientnumber, Name = user.Name, Email = user.Email, Phone = user.Phone, Location = LocationMapper.ToLocationEF(user.Location) };
        }
    }
}
