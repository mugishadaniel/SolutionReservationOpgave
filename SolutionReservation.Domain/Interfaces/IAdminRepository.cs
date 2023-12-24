using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Domain.Interfaces
{
    public interface IAdminRepository
    {
        Task<bool> ExistsRestaurantAsync(int restaurantId);
        Task<Restaurant> GetRestaurantAsync(int restaurantId);
        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);
        Task<Restaurant> UpdateRestaurantAsync(int restaurantId, Restaurant restaurant);
        Task<Restaurant> DeleteRestaurantAsync(int restaurantId);

        Task<List<Reservation>> GetReservationsAsync(int restaurantId);
    }
}
