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
            return new Restaurant(restaurantEF.Id,restaurantEF.Name, LocationMapper.ToLocation(restaurantEF.Location), restaurantEF.Keuken, restaurantEF.Phone, restaurantEF.Email,restaurantEF.IsActive);
        }

        public static RestaurantEF ToRestaurantEF(Restaurant restaurant)
        {
            return new RestaurantEF {Id = restaurant.Id, Name = restaurant.Name, Location = LocationMapper.ToLocationEF(restaurant.Location), Keuken = restaurant.Keuken, Phone = restaurant.Phone, Email = restaurant.Email,IsActive = restaurant.IsActive };
        }
    }
}
