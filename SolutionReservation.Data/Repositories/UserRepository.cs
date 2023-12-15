using SolutionReservation.Data.Context;
using SolutionReservation.Data.Mappers;
using SolutionReservation.Data.Model;
using SolutionReservation.Data.Repositories.RepositoryExceptions;
using SolutionReservation.Domain.Interfaces;
using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SolutionReservation.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ReservationContext _context;
        public UserRepository(ReservationContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(int clientNumber)
        {
            try
            {
                return await Task.FromResult(_context.Users.Any(u => u.ClientNumber == clientNumber));
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.ExistsAsync(int clientNumber)", ex);
            }
        }

        public async Task<User> GetAsync(int clientNumber)
        {
            try
            {
               UserEF userEF = await _context.Users.Include(l => l.Location).FirstOrDefaultAsync(u => u.ClientNumber == clientNumber);
                return UserMapper.ToUser(userEF);
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.GetAsync(int clientNumber)", ex);
            }
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                UserEF userEF = UserMapper.ToUserEF(user);
                _context.Users.Add(userEF);
                await _context.SaveChangesAsync();
                return UserMapper.ToUser(userEF);
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.AddUserAsync(User user)", ex);
            }
        }

        public async Task<User> UpdateUserAsync(int clientNumber, User user)
        {
            try
            {
                UserEF existingUserEF = await _context.Users.Include(l => l.Location).FirstOrDefaultAsync(u => u.ClientNumber == clientNumber);
                if (existingUserEF == null)
                {
                    throw new UserRepositoryException("User not found");
                }
                UserMapper.updateUserEF(existingUserEF, user);
                await _context.SaveChangesAsync();
                return UserMapper.ToUser(existingUserEF);
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.UpdateUserAsync(int clientNumber,User user)", ex);
            }
        }

        public async Task<User> DeleteUserAsync(int clientNumber)
        {
            try
            {
                UserEF existingUserEF = await _context.Users.Include(l => l.Location).FirstOrDefaultAsync(u => u.ClientNumber == clientNumber);
                if (existingUserEF == null)
                {
                    throw new UserRepositoryException("User not found");
                }
                existingUserEF.IsActive = false;
                await _context.SaveChangesAsync();
                return UserMapper.ToUser(existingUserEF);
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.DeleteUserAsync(int clientNumber)", ex);
            }
        }

    }
}
