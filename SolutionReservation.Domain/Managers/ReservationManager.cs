using SolutionReservation.Domain.Interfaces;
using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Domain.Managers
{
    public class ReservationManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IAdminRepository _adminRepository;

        public ReservationManager(IUserRepository userRepository,IAdminRepository adminRepository)
        {
            _userRepository = userRepository;
            _adminRepository = adminRepository;
        }

        public virtual async Task<bool> TryMakeReservationAsync(Reservation reservation, int restaurantId, int reservationNumber)
        {
            DateTime requestedStartTime = reservation.DateTime;
            DateTime requestedEndTime = requestedStartTime.AddHours(1.5);

            var availableTable = await FindAvailableTable(restaurantId, reservation.NumberofSeats, requestedStartTime, requestedEndTime);
            if (availableTable == null)
            {
                return false; // No suitable table available at the requested time.
            }

            reservation.SetTableNumber(availableTable.TableID);


            return true;
        }


        private async Task<Table> FindAvailableTable(int restaurantId, int numberOfSeats, DateTime requestedStartTime, DateTime requestedEndTime)
        {
            Restaurant restaurant = await _adminRepository.GetRestaurantAsync(restaurantId);
            ICollection<Table> tables = restaurant.Tables;

            // Get all reservations for the restaurant
            List<Reservation> reservations = await _adminRepository.GetReservationsPeriodAsync(
                               restaurantId,
                                              DateOnly.FromDateTime(requestedStartTime),
                                                             DateOnly.FromDateTime(requestedEndTime));

            // Find a table that is not reserved during the requested time period
            foreach (Table table in tables)
            {
                bool isReserved = reservations.Any(reservation =>
                                   reservation.TableNumber == table.TableID &&
                                                      requestedStartTime < reservation.DateTime.AddHours(1.5) &&
                                                                         requestedEndTime > reservation.DateTime);

                if (!isReserved && table.Seats >= numberOfSeats)
                {
                    return table;
                }
            }

            return null;
        }


    }
}
