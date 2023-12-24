using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistsAsync(int clientNumber);
        Task<User> GetUserAsync(int clientNumber);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(int clientNumber,User user);
        Task<User> DeleteUserAsync(int clientNumber);
        Task<List<Restaurant>> SearchRestaurantAsync(string search);
        Task<bool> ExistsRestaurantAsync(int restaurantId);
        Task<bool> ExistsReservation(int reservationId);
        Task<Reservation> GetReservationAsync(int reservationId);   
        Task<Reservation> AddReservationAsync(int clientNumber, int restaurantId, Reservation reservation);
        Task<Reservation> UpdateReservationAsync(int reservationId, Reservation reservation);
        Task<Reservation> DeleteReservationAsync(int reservationId);
        Task<List<Reservation>> SearchReservationsAsync(string search);


    }
}
