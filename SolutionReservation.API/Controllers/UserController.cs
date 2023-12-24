using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SolutionReservation.API.DTO.Input;
using SolutionReservation.API.MapperDTO;
using SolutionReservation.Data.Model;
using SolutionReservation.Domain.Managers;
using SolutionReservation.Domain.Model;


namespace SolutionReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager _userManager;
        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPut]
        [Route("AddUser")]
        public async Task<IActionResult> AddUserAsync(UserInputDTO user)
        {
            try
            {

                var result = await _userManager.AddUserAsync(UserMapperDTO.ToDomain(user));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUser/{clientNumber}")]
        public async Task<IActionResult> GetUserAsync(int clientNumber)
        {
            try
            {
                if (!await _userManager.ExistsAsync(clientNumber)) return NotFound($"User with ID {clientNumber} not found");
                var result = await _userManager.GetUserAsync(clientNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateUser/{clientNumber}")]
        public async Task<IActionResult> UpdateUserAsync(int clientNumber, UserInputDTO user)
        {
            try
            {
                if (!await _userManager.ExistsAsync(clientNumber)) return NotFound($"User with ID {clientNumber} not found");
                var userFromDb = await _userManager.GetUserAsync(clientNumber);
                user = UserMapperDTO.UpdateUser(userFromDb,user);
                var result = await _userManager.UpdateUserAsync(clientNumber, UserMapperDTO.ToDomain(user));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{clientNumber}")]
        public async Task<IActionResult> DeleteUserAsync(int clientNumber)
        {
            try
            {
                if (!await _userManager.ExistsAsync(clientNumber)) return NotFound($"User with ID {clientNumber} not found");
                var result = await _userManager.DeleteUserAsync(clientNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("SearchRestaurant/{search}")]
        public async Task<IActionResult> SearchRestaurantAsync(string search)
        {
            try
            {
                var result = await _userManager.SearchRestaurantAsync(search);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("AddReservation/{clientNumber}/{restaurantId}")]
        public async Task<IActionResult> AddReservationAsync(int clientNumber, int restaurantId, ReservationInputDTO reservation)
        {
            try
            {
                if (!await _userManager.ExistsAsync(clientNumber)) return NotFound($"User with ID {clientNumber} not found");
                if (!await _userManager.ExistsRestaurantAsync(restaurantId)) return NotFound($"Restaurant with ID {restaurantId} not found");
                var result = await _userManager.AddReservationAsync(clientNumber, restaurantId,ReservationMapperDTO.ToDomain(reservation));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateReservation/{reservationId}")]
        public async Task<IActionResult> UpdateReservationAsync(int reservationId, ReservationInputDTO reservation)
        {
            try
            {
                if(!await _userManager.ExistsReservation(reservationId)) return NotFound($"Reservation with ID {reservationId} not found");
                var reservationFromDb = await _userManager.GetReservationAsync(reservationId);
                reservation = ReservationMapperDTO.UpdateReservation(reservationFromDb,reservation);
                var result = await _userManager.UpdateReservationAsync(reservationId, ReservationMapperDTO.ToDomain(reservation));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteReservation/{reservationId}")]
        public async Task<IActionResult> DeleteReservationAsync(int reservationId)
        {
            try
            {
                if (!await _userManager.ExistsReservation(reservationId)) return NotFound($"Reservation with ID {reservationId} not found");
                var result = await _userManager.DeleteReservationAsync(reservationId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("SearchReservations/{search}")]
        public async Task<IActionResult> SearchReservationsAsync(string search)
        {
            try
            {
                var result = await _userManager.SearchReservationsAsync(search);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
