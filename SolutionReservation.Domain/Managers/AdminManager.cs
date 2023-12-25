using SolutionReservation.Domain.Interfaces;
using SolutionReservation.Domain.Managers.ManagerExceptions;
using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Domain.Managers
{
    public class AdminManager
    {
        private readonly IAdminRepository _adminRepository;
        public AdminManager(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<bool> ExistsRestaurantAsync(int restaurantId)
        {
            try
            {
                return await _adminRepository.ExistsRestaurantAsync(restaurantId);
            }
            catch (Exception ex)
            {

                throw new AdminManagerException("Error in AdminManager.ExistsRestaurantAsync(int restaurantId)", ex);
            }
        }

        public async Task<Restaurant> GetRestaurantAsync(int restaurantId)
        {
            try
            {
                return await _adminRepository.GetRestaurantAsync(restaurantId);
            }
            catch (Exception ex)
            {

                throw new AdminManagerException("Error in AdminManager.GetRestaurantAsync(int restaurantId)", ex);
            }
        }

        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            try
            {
                return await _adminRepository.AddRestaurantAsync(restaurant);
            }
            catch (Exception ex)
            {

                throw new AdminManagerException("Error in AdminManager.AddRestaurant(Restaurant restaurant)", ex);
            }
        }

        public async Task<Restaurant> UpdateRestaurantAsync(int restaurantId, Restaurant restaurant)
        {
            try
            {
                return await _adminRepository.UpdateRestaurantAsync(restaurantId, restaurant);
            }
            catch (Exception ex)
            {

                throw new AdminManagerException("Error in AdminManager.UpdateRestaurantAsync(int restaurantId, Restaurant restaurant)", ex);
            }
        }

        public async Task<Restaurant> DeleteRestaurantAsync(int restaurantId)
        {
            try
            {
                return await _adminRepository.DeleteRestaurantAsync(restaurantId);
            }
            catch (Exception ex)
            {

                throw new AdminManagerException("Error in AdminManager.DeleteRestaurantAsync(int restaurantId)", ex);
            }
        }

        public async Task<List<Reservation>> GetReservationsAsync(int restaurantId)
        {
            try
            {
                return await _adminRepository.GetReservationsAsync(restaurantId);
            }
            catch (Exception ex)
            {

                throw new AdminManagerException("Error in AdminManager.GetReservationsAsync(int restaurantId)", ex);
            }
        }

        public async Task<List<Reservation>> GetReservationsAsync(int restaurantId, DateOnly startDate, DateOnly endDate)
        {
            try
            {
                return await _adminRepository.GetReservationsPeriodAsync(restaurantId, startDate, endDate);
            }
            catch (Exception ex)
            {

                throw new AdminManagerException("Error in AdminManager.GetReservationsAsync(int restaurantId, DateOnly startDate, DateOnly endDate)", ex);
            }
        }
    }
}
