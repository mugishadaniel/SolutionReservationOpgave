using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SolutionReservation.API.DTO.Input;
using SolutionReservation.API.MapperDTO;
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
                var result = await _userManager.GetAsync(clientNumber);
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
                var result = await _userManager.DeleteUserAsync(clientNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
