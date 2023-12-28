using SolutionReservation.Data.Model;
using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Mappers
{
    public class RestaurantMapper
    {
        public static Restaurant ToRestaurant(RestaurantEF restaurantEF)
        {
            List<Table> tables = restaurantEF.Tables.Select(t => TableMapper.Map(t)).ToList();

            return new Restaurant(restaurantEF.Id,restaurantEF.Name, LocationMapper.ToLocation(restaurantEF.Location), restaurantEF.Keuken, restaurantEF.Phone, restaurantEF.Email,restaurantEF.IsActive,tables);
        }

        public static RestaurantEF ToRestaurantEF(Restaurant restaurant)
        {
            List<TableEF> tables = restaurant.Tables.Select(t => TableMapper.Map(t)).ToList();

            return new RestaurantEF {Id = restaurant.Id, Name = restaurant.Name, Location = LocationMapper.ToLocationEF(restaurant.Location), Keuken = restaurant.Keuken, Phone = restaurant.Phone, Email = restaurant.Email,IsActive = restaurant.IsActive,Tables = tables };
        }

        public static RestaurantEF UpdateRestaurantEF(RestaurantEF restaurantEF, Restaurant restaurant)
        {
            restaurantEF.Name = restaurant.Name;
            restaurantEF.Location.Street = restaurant.Location.Street;
            restaurantEF.Location.HouseNumber = restaurant.Location.HouseNumber;
            restaurantEF.Location.PostalCode = restaurant.Location.PostalCode;
            restaurantEF.Location.Municipality = restaurant.Location.Municipality;
            restaurantEF.Keuken = restaurant.Keuken;
            restaurantEF.Phone = restaurant.Phone;
            restaurantEF.Email = restaurant.Email;
            return restaurantEF;
        }
    }
}
