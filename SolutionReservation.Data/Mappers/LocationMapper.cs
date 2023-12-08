using SolutionReservation.Data.Model;
using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Mappers
{
    public class LocationMapper
    {
        public static Location ToLocation(LocationEF locationEF)
        {
            return new Location(locationEF.PostalCode, locationEF.Municipality, locationEF.Street, locationEF.HouseNumber);
        }

        public static LocationEF ToLocationEF(Location location)
        {
            return new LocationEF
            {
                PostalCode = location.PostalCode,
                Municipality = location.Municipality,
                Street = location.Street,
                HouseNumber = location.HouseNumber
            };
        }
    }
}
