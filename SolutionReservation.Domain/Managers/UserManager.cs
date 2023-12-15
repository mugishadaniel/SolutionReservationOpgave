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

        public async Task<bool> ExistsAsync(int clientNumber)
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

        public async Task<User> GetAsync(int clientNumber)
        {
            try
            {
                return await _userRepository.GetAsync(clientNumber);
            }
            catch (Exception ex)
            {

                throw new UserManagerException("", ex);
            }
        }

        public async Task<User> AddUserAsync(User user)
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

        public async Task<User> DeleteUserAsync(int clientNumber)
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
    }
}
