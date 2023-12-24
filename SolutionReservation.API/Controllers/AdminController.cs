using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolutionReservation.API.DTO.Input;
using SolutionReservation.API.MapperDTO;
using SolutionReservation.Domain.Managers;
using SolutionReservation.Domain.Model;

namespace SolutionReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private AdminManager _adminManager;
        public AdminController(AdminManager adminManager)
        {
            _adminManager = adminManager;
        }

        [HttpPut]
        [Route("AddRestaurant")]
        public async Task<IActionResult> AddRestaurantAsync(RestaurantInputDTO restaurant)
        {
            try
            {             
                var result = await _adminManager.AddRestaurantAsync(RestaurantMapperDTO.ToDomain(restaurant));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateRestaurant")]
        public async Task<IActionResult> UpdateRestaurantAsync(int restaurantId, RestaurantInputDTO restaurant)
        {
            try
            {
                if (!await _adminManager.ExistsRestaurantAsync(restaurantId)) return NotFound($"Restaurant with ID {restaurantId} not found");
                var restaurantFromDb = await _adminManager.GetRestaurantAsync(restaurantId);
                restaurant = RestaurantMapperDTO.UpdateRestaurant(restaurantFromDb, restaurant);
                var result = await _adminManager.UpdateRestaurantAsync(restaurantId, RestaurantMapperDTO.ToDomain(restaurant));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteRestaurant/{restaurantId}")]
        public async Task<IActionResult> DeleteRestaurantAsync(int restaurantId)
        {
            try
            {
                if (!await _adminManager.ExistsRestaurantAsync(restaurantId)) return NotFound($"Restaurant with ID {restaurantId} not found");
                await _adminManager.DeleteRestaurantAsync(restaurantId);
                return Ok($"Restaurant with ID {restaurantId} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
