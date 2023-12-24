using SolutionReservation.API.DTO.Input;
using SolutionReservation.Domain.Model;

namespace SolutionReservation.API.MapperDTO
{
    public class RestaurantMapperDTO
    {
        public static Restaurant ToDomain(RestaurantInputDTO restaurantInputDTO)
        {
            return new Restaurant(restaurantInputDTO.Name,restaurantInputDTO.Keuken,restaurantInputDTO.Phone,restaurantInputDTO.Email,new Location(restaurantInputDTO.PostalCode,restaurantInputDTO.Municipality,restaurantInputDTO.Street,restaurantInputDTO.HouseNumber));
        }

        public static RestaurantInputDTO UpdateRestaurant(Restaurant restaurantFromDb, RestaurantInputDTO restaurant)
        {
            if (string.IsNullOrWhiteSpace(restaurant.Name)) restaurant.Name = restaurantFromDb.Name;
            if (string.IsNullOrWhiteSpace(restaurant.Keuken)) restaurant.Keuken = restaurantFromDb.Keuken;
            if (string.IsNullOrWhiteSpace(restaurant.Phone)) restaurant.Phone = restaurantFromDb.Phone;
            if (string.IsNullOrWhiteSpace(restaurant.Email)) restaurant.Email = restaurantFromDb.Email;
            if (string.IsNullOrWhiteSpace(restaurant.Municipality)) restaurant.Municipality = restaurantFromDb.Location.Municipality;
            if (string.IsNullOrWhiteSpace(restaurant.Street)) restaurant.Street = restaurantFromDb.Location.Street;
            if (string.IsNullOrWhiteSpace(restaurant.HouseNumber)) restaurant.HouseNumber = restaurantFromDb.Location.HouseNumber;
            if (restaurant.PostalCode == 0) restaurant.PostalCode = restaurantFromDb.Location.PostalCode;
            return restaurant;
        }
    }
}
