using Microsoft.EntityFrameworkCore;
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

namespace SolutionReservation.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ReservationContext _context;
        public AdminRepository(ReservationContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsRestaurantAsync(int restaurantId)
        {
            try
            {
                return await Task.FromResult(_context.Restaurants.Any(r => r.Id == restaurantId));
            }
            catch (Exception ex)
            {

                throw new AdminRepositoryException("Error in AdminRepository.ExistsRestaurantAsync: ", ex);
            }
        }

        public async Task<Restaurant> GetRestaurantAsync(int restaurantId)
        {
            try
            {
                RestaurantEF restaurantEF = await _context.Restaurants
                    .Include(r => r.Location) 
                    .FirstOrDefaultAsync(r => r.Id == restaurantId); 
                return RestaurantMapper.ToRestaurant(restaurantEF);
            }
            catch (Exception ex)
            {

                throw new AdminRepositoryException("Error in AdminRepository.GetRestaurantAsync: ", ex);
            }
        }

        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            try
            {
                RestaurantEF restaurantEF = RestaurantMapper.ToRestaurantEF(restaurant);
                await _context.Restaurants.AddAsync(restaurantEF);
                await _context.SaveChangesAsync();
                return RestaurantMapper.ToRestaurant(restaurantEF);
            }
            catch (Exception ex)
            {

                throw new AdminRepositoryException("Error in AdminRepository.AddRestaurant: ", ex);
            }
        }

        public async Task<Restaurant> UpdateRestaurantAsync(int restaurantId, Restaurant restaurant)
        {
            try
            {
                RestaurantEF restaurantEF = await _context.Restaurants
                    .Include(r => r.Location) 
                    .FirstOrDefaultAsync(r => r.Id == restaurantId); 

                restaurantEF = RestaurantMapper.UpdateRestaurantEF(restaurantEF, restaurant);
                await _context.SaveChangesAsync();
                return RestaurantMapper.ToRestaurant(restaurantEF);
            }
            catch (Exception ex)
            {

                throw new AdminRepositoryException("Error in AdminRepository.UpdateRestaurantAsync: ", ex);
            }
        }

        public async Task<Restaurant> DeleteRestaurantAsync(int restaurantId)
        {
            try
            {
                RestaurantEF restaurantEF = await _context.Restaurants
                    .Include(r => r.Location)
                    .FirstOrDefaultAsync(r => r.Id == restaurantId);
                restaurantEF.IsActive = false;
                await _context.SaveChangesAsync();
                return RestaurantMapper.ToRestaurant(restaurantEF);
            }
            catch (Exception ex)
            {

                throw new AdminRepositoryException("Error in AdminRepository.DeleteRestaurantAsync: ", ex);
            }
        }

        public async Task<List<Reservation>> GetReservationsAsync(int restaurantId)
        {
            try
            {
                List<ReservationEF> reservationEFs = await _context.Reservations.Where(r => r.Restaurant.Id == restaurantId).ToListAsync();
                List<Reservation> reservations = new List<Reservation>();
                foreach (ReservationEF reservationEF in reservationEFs)
                {
                    reservations.Add(ReservationMapper.ToReservation(reservationEF));
                }
                return reservations;
            }
            catch (Exception ex)
            {

                throw new AdminRepositoryException("Error in AdminRepository.GetReservationsAsync: ", ex);
            }
        }
    }
}
