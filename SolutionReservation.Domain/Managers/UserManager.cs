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
    public class UserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public virtual async Task<bool> ExistsAsync(int clientNumber)
        {
            try
            {
                return await _userRepository.ExistsAsync(clientNumber);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("Error in UserManager.ExistsAsync(int clientNumber)", ex);
            }
        }

        public virtual async Task<User> GetUserAsync(int clientNumber)
        {
            try
            {
                return await _userRepository.GetUserAsync(clientNumber);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }

        public virtual async Task<User> AddUserAsync(User user)
        {
            try
            {
                return await _userRepository.AddUserAsync(user);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }

        public async Task<User> UpdateUserAsync(int clientNumber,User user)
        {
            try
            {
                return await _userRepository.UpdateUserAsync(clientNumber,user);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }

        public virtual async Task<User> DeleteUserAsync(int clientNumber)
        {
            try
            {
                return await _userRepository.DeleteUserAsync(clientNumber);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }

        public virtual async Task<List<Restaurant>> SearchRestaurantAsync(string search)
        {
            try
            {
                return await _userRepository.SearchRestaurantAsync(search);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }

        public async Task<bool> ExistsRestaurantAsync(int restaurantId)
        {
            try
            {
                return await _userRepository.ExistsRestaurantAsync(restaurantId);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }

        public async Task<Reservation> AddReservationAsync(int clientNumber, int restaurantId,Reservation reservation)
        {
            try
            {
                return await _userRepository.AddReservationAsync(clientNumber,restaurantId,reservation);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }

        public async Task<Reservation> UpdateReservationAsync(int reservationId, Reservation reservation)
        {
            try
            {
                return await _userRepository.UpdateReservationAsync(reservationId, reservation);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }

        public async Task<bool> ExistsReservation(int reservationId)
        {
            try
            {
                return await _userRepository.ExistsReservation(reservationId);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }

        public async Task<Reservation> GetReservationAsync(int reservationId)
        {
            try
            {
                return await _userRepository.GetReservationAsync(reservationId);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }

        public async Task<Reservation> DeleteReservationAsync(int reservationId)
        {
            try
            {
                return await _userRepository.DeleteReservationAsync(reservationId);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }

        public virtual async Task<List<Reservation>> SearchReservationsAsync(string search)
        {
            try
            {
                return await _userRepository.SearchReservationsAsync(search);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }
    }
}
