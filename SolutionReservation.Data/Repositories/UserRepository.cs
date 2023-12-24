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

        public async Task<User> GetUserAsync(int clientNumber)
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
                    User = userEF,
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

        public async Task<Reservation> UpdateReservationAsync(int reservationId, Reservation reservation)
        {
            try
            {
                ReservationEF existingReservationEF = await _context.Reservations
                    .Include(r => r.Restaurant)
                        .ThenInclude(restaurant => restaurant.Location)
                    .Include(r => r.User)
                        .ThenInclude(user => user.Location)
                    .FirstOrDefaultAsync(r => r.ReservationNumber == reservationId);
                if (existingReservationEF == null)
                {
                    throw new UserRepositoryException("Reservation not found");
                }
                ReservationMapper.UpdateReservationEF(existingReservationEF, reservation);
                await _context.SaveChangesAsync();
                return ReservationMapper.ToReservation(existingReservationEF);
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.UpdateReservationAsync(int reservationId, Reservation reservation)", ex);
            }
        }

        public async Task<bool> ExistsReservation(int reservationId)
        {
            try
            {
                return await Task.FromResult(_context.Reservations.Any(r => r.ReservationNumber == reservationId));
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.ExistsReservation(int reservationId)", ex);
            }
        }

        public async Task<Reservation> GetReservationAsync(int reservationId)
        {
            try
            {
                ReservationEF reservationEF = await _context.Reservations
                    .Include(r => r.Restaurant)
                        .ThenInclude(restaurant => restaurant.Location)
                    .Include(r => r.User)
                        .ThenInclude(user => user.Location) 
                    .FirstOrDefaultAsync(r => r.ReservationNumber == reservationId);

                return ReservationMapper.ToReservation(reservationEF);
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.GetReservationAsync(int reservationId)", ex);
            }
        }

        public async Task<Reservation> DeleteReservationAsync(int reservationId)
        {
            try
            {
                ReservationEF existingReservationEF = await _context.Reservations
                    .Include(r => r.Restaurant)
                        .ThenInclude(restaurant => restaurant.Location)
                    .Include(r => r.User)
                        .ThenInclude(user => user.Location)
                    .FirstOrDefaultAsync(r => r.ReservationNumber == reservationId);
                if (existingReservationEF == null)
                {
                    throw new UserRepositoryException("Reservation not found");
                }
                _context.Reservations.Remove(existingReservationEF);
                await _context.SaveChangesAsync();
                return ReservationMapper.ToReservation(existingReservationEF);
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.DeleteReservationAsync(int reservationId)", ex);
            }
        }

        public async Task<List<Reservation>> SearchReservationsAsync(string search)
        {
            try
            {
                List<ReservationEF> reservationEFs = await _context.Reservations
                    .Where(r => r.Restaurant.Keuken.Contains(search) || r.Restaurant.Location.PostalCode.ToString().Contains(search) || r.DateTime.ToString().Contains(search))
                    .Include(r => r.Restaurant)
                        .ThenInclude(restaurant => restaurant.Location)
                    .Include(r => r.User)
                        .ThenInclude(user => user.Location)
                    .ToListAsync();
                return reservationEFs.Select(r => ReservationMapper.ToReservation(r)).ToList();
            }
            catch (Exception ex)
            {

                throw new UserRepositoryException("Error in UserRepository.SearchReservationsAsync(string search)", ex);
            }
        }
    }
}
