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

        public async Task<bool> TryMakeReservationAsync(Reservation reservation,int restaurantId,int reservationNumber)
        {
            DateTime requestedStartTime = reservation.DateTime;
            DateTime requestedEndTime = requestedStartTime.AddHours(1.5);

            List<Reservation> overlappingReservations = await _adminRepository.GetReservationsPeriodAsync(
                restaurantId,
                DateOnly.FromDateTime(requestedStartTime),
                DateOnly.FromDateTime(requestedEndTime));

            foreach (Reservation existingReservation in overlappingReservations)
            {
                // if its updating a reservation, ignore the reservation that is being updated
                if (reservationNumber == existingReservation.ReservationNumber) continue;
                DateTime existingReservationEndTime = existingReservation.DateTime.AddHours(1.5);


                if (requestedStartTime < existingReservationEndTime && requestedEndTime > existingReservation.DateTime)
                {

                    return false; 
                }
            }

            return true;
        }


    }
}
