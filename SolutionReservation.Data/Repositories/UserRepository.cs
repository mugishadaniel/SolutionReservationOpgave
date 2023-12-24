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
                userEF.IsActive = true;
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

        public async Task<List<Restaurant>> SearchRestaurantAsync(string search)
        {
            try
            {
                List<RestaurantEF> restaurantEFs = await _context.Restaurants
                    .Where(r => r.Keuken.Contains(search) || r.Location.PostalCode.ToString().Contains(search))
                    .Include(l => l.Location)
                    .ToListAsync();
                return restaurantEFs.Select(r => RestaurantMapper.ToRestaurant(r)).ToList();
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.SearchRestaurantAsync(string search)", ex);
            }
        }

        public async Task<bool> ExistsRestaurantAsync(int restaurantId)
        {
            try
            {
                return await Task.FromResult(_context.Restaurants.Any(r => r.Id == restaurantId));
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.ExistsRestaurantAsync(int restaurantId)", ex);
            }
        }

        public async Task<Reservation> AddReservationAsync(int clientNumber, int restaurantId, Reservation reservation)
        {
            try
            {
                UserEF userEF = await _context.Users.Include(l => l.Location).FirstOrDefaultAsync(u => u.ClientNumber == clientNumber);
                RestaurantEF restaurantEF = await _context.Restaurants.Include(l => l.Location).FirstOrDefaultAsync(r => r.Id == restaurantId);
                ReservationEF reservationEF = new ReservationEF()
                {
                    Contactperson = userEF.Name,
                    Restaurant = restaurantEF,
                    DateTime = reservation.DateTime,
                    NumberofSeats = reservation.NumberofSeats,
                    TableNumber = reservation.TableNumber
                };
                _context.Reservations.Add(reservationEF);
                await _context.SaveChangesAsync();
                return ReservationMapper.ToReservation(reservationEF);
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.AddReservationAsync(int clientNumber, int restaurantId)", ex);
            }
        }
    }
}
