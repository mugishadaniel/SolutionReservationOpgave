using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SolutionReservation.API.Controllers;
using SolutionReservation.API.DTO.Input;
using SolutionReservation.API.MapperDTO;
using SolutionReservation.Domain.Interfaces;
using SolutionReservation.Domain.Managers;
using SolutionReservation.Domain.Model;

namespace SolutionReservation.Test
{
    public class UserControllerTests
    {
        [Fact]
        public async Task AddUserAsync_ShouldReturnOk()
        {
            // Arrange
            var iUserRepositoryMock = new Mock<IUserRepository>();
            var userManagerMock = new Mock<UserManager>(iUserRepositoryMock.Object);
            var AdminRepositoryMock = new Mock<IAdminRepository>();
            var ReservationManagerMock = new Mock<ReservationManager>(iUserRepositoryMock.Object, AdminRepositoryMock.Object);
            var userController = new UserController(userManagerMock.Object, ReservationManagerMock.Object);
            var userinputDTO = new UserInputDTO()
            {
                Name = "Test",
                Email = "test@",
                Phone = "0123",
                PostalCode = 0,
                Municipality = "test",
                Street = "test",
                HouseNumber = "test"
            };
            User user = UserMapperDTO.ToDomain(userinputDTO);

            userManagerMock.Setup(manager => manager.AddUserAsync(It.IsAny<User>())).ReturnsAsync(user);

            // Act
            var result = await userController.AddUserAsync(userinputDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task AddUserAsync_ShouldReturnStatusCode500InternalServerError()
        {
            // Arrange
            var iUserRepositoryMock = new Mock<IUserRepository>();
            var userManagerMock = new Mock<UserManager>(iUserRepositoryMock.Object);
            var AdminRepositoryMock = new Mock<IAdminRepository>();
            var ReservationManagerMock = new Mock<ReservationManager>(iUserRepositoryMock.Object, AdminRepositoryMock.Object);
            var userController = new UserController(userManagerMock.Object, ReservationManagerMock.Object);
            var userinputDTO = new UserInputDTO()
            {
                Name = "Test",
                Email = "test@",
                Phone = "0123",
                PostalCode = 0,
                Municipality = "test",
                Street = "test",
                HouseNumber = "test"
            };
            User user = UserMapperDTO.ToDomain(userinputDTO);

            userManagerMock.Setup(manager => manager.AddUserAsync(user))
                             .ThrowsAsync(new Exception("Simulated exception"));

            // Act
            var result = await userController.AddUserAsync(userinputDTO);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("User Could not be created", badRequestResult.Value);


        }

        [Fact]
        public async Task GetUserAsync_ShouldReturnOk()
        {
            // Arrange
            var iUserRepositoryMock = new Mock<IUserRepository>();
            var userManagerMock = new Mock<UserManager>(iUserRepositoryMock.Object);
            var AdminRepositoryMock = new Mock<IAdminRepository>();
            var ReservationManagerMock = new Mock<ReservationManager>(iUserRepositoryMock.Object, AdminRepositoryMock.Object);
            var userController = new UserController(userManagerMock.Object, ReservationManagerMock.Object);
            var userinputDTO = new UserInputDTO()
            {
                Name = "Test",
                Email = "test@",
                Phone = "0123",
                PostalCode = 0,
                Municipality = "test",
                Street = "test",
                HouseNumber = "test"
            };
            User user = UserMapperDTO.ToDomain(userinputDTO);

            userManagerMock.Setup(manager => manager.GetUserAsync(1)).ReturnsAsync(user);
            userManagerMock.Setup(manager => manager.ExistsAsync(1)).ReturnsAsync(true);

            // Act
            var result = await userController.GetUserAsync(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetUserAsync_ShouldReturnNotFound()
        {
            // Arrange
            var iUserRepositoryMock = new Mock<IUserRepository>();
            var userManagerMock = new Mock<UserManager>(iUserRepositoryMock.Object);
            var AdminRepositoryMock = new Mock<IAdminRepository>();
            var ReservationManagerMock = new Mock<ReservationManager>(iUserRepositoryMock.Object, AdminRepositoryMock.Object);
            var userController = new UserController(userManagerMock.Object, ReservationManagerMock.Object);
            var userinputDTO = new UserInputDTO()
            {
                Name = "Test",
                Email = "test@",
                Phone = "0123",
                PostalCode = 0,
                Municipality = "test",
                Street = "test",
                HouseNumber = "test"
            };
            User user = UserMapperDTO.ToDomain(userinputDTO);

            userManagerMock.Setup(manager => manager.GetUserAsync(1)).ReturnsAsync(user);
            userManagerMock.Setup(manager => manager.ExistsAsync(1)).ReturnsAsync(false);

            // Act
            var result = await userController.GetUserAsync(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task DeleteUserAsyncReturnsOk()
        {
            // Arrange
            var iUserRepositoryMock = new Mock<IUserRepository>();
            var userManagerMock = new Mock<UserManager>(iUserRepositoryMock.Object);
            var AdminRepositoryMock = new Mock<IAdminRepository>();
            var ReservationManagerMock = new Mock<ReservationManager>(iUserRepositoryMock.Object, AdminRepositoryMock.Object);
            var userController = new UserController(userManagerMock.Object, ReservationManagerMock.Object);
            var userinputDTO = new UserInputDTO()
            {
                Name = "Test",
                Email = "test@",
                Phone = "0123",
                PostalCode = 0,
                Municipality = "test",
                Street = "test",
                HouseNumber = "test"
            };
            User user = UserMapperDTO.ToDomain(userinputDTO);

            userManagerMock.Setup(manager => manager.DeleteUserAsync(1)).ReturnsAsync(user);
            userManagerMock.Setup(manager => manager.ExistsAsync(1)).ReturnsAsync(true);

            // Act
            var result = await userController.DeleteUserAsync(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteUserAsyncReturnsNotFound()
        {
            // Arrange
            var iUserRepositoryMock = new Mock<IUserRepository>();
            var userManagerMock = new Mock<UserManager>(iUserRepositoryMock.Object);
            var AdminRepositoryMock = new Mock<IAdminRepository>();
            var ReservationManagerMock = new Mock<ReservationManager>(iUserRepositoryMock.Object, AdminRepositoryMock.Object);
            var userController = new UserController(userManagerMock.Object, ReservationManagerMock.Object);
            var userinputDTO = new UserInputDTO()
            {
                Name = "Test",
                Email = "test@",
                Phone = "0123",
                PostalCode = 0,
                Municipality = "test",
                Street = "test",
                HouseNumber = "test"
            };
            User user = UserMapperDTO.ToDomain(userinputDTO);

            userManagerMock.Setup(manager => manager.DeleteUserAsync(1)).ReturnsAsync(user);
            userManagerMock.Setup(manager => manager.ExistsAsync(1)).ReturnsAsync(false);

            // Act
            var result = await userController.DeleteUserAsync(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task SearchRestaurantAsyncReturnsOk()
        {
            // Arrange
            var iUserRepositoryMock = new Mock<IUserRepository>();
            var userManagerMock = new Mock<UserManager>(iUserRepositoryMock.Object);
            var AdminRepositoryMock = new Mock<IAdminRepository>();
            var ReservationManagerMock = new Mock<ReservationManager>(iUserRepositoryMock.Object, AdminRepositoryMock.Object);
            var userController = new UserController(userManagerMock.Object, ReservationManagerMock.Object);
            List<Restaurant> restaurants = new List<Restaurant>();
            restaurants.Add(new Restaurant(1, "test", new Location(1, "test", "test",""), "test", "test", "test@", true, new List<Table>()));

            userManagerMock.Setup(manager => manager.SearchRestaurantAsync("test")).ReturnsAsync(restaurants);

            // Act
            var result = await userController.SearchRestaurantAsync("test");

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task SearchRestaurantAsyncReturnsNotFound()
        {
            // Arrange
            var iUserRepositoryMock = new Mock<IUserRepository>();
            var userManagerMock = new Mock<UserManager>(iUserRepositoryMock.Object);
            var AdminRepositoryMock = new Mock<IAdminRepository>();
            var ReservationManagerMock = new Mock<ReservationManager>(iUserRepositoryMock.Object, AdminRepositoryMock.Object);
            var userController = new UserController(userManagerMock.Object, ReservationManagerMock.Object);
            List<Restaurant> restaurants = new List<Restaurant>();

            userManagerMock.Setup(manager => manager.SearchRestaurantAsync("test")).ReturnsAsync(restaurants);

            // Act
            var result = await userController.SearchRestaurantAsync("test");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task SearchReservationsAsyncReturnsOk()
        {
            // Arrange
            var iUserRepositoryMock = new Mock<IUserRepository>();
            var userManagerMock = new Mock<UserManager>(iUserRepositoryMock.Object);
            var AdminRepositoryMock = new Mock<IAdminRepository>();
            var ReservationManagerMock = new Mock<ReservationManager>(iUserRepositoryMock.Object, AdminRepositoryMock.Object);
            var userController = new UserController(userManagerMock.Object, ReservationManagerMock.Object);
            var user = new User(1, "test", "test", "test", new Location(1, "test", "test", ""), true);
            List<Reservation> reservations = new List<Reservation>();
            var restaurant = new Restaurant(1, "test", new Location(1, "test", "test",""), "test", "test", "test@", true, new List<Table>());
            reservations.Add(new Reservation(1,restaurant, user,1, new DateTime(2025, 1, 1), 1));

            userManagerMock.Setup(manager => manager.SearchReservationsAsync("test")).ReturnsAsync(reservations);

            // Act
            var result = await userController.SearchReservationsAsync("test");

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task SearchReservationsAsyncReturnsNotFound()
        {
            // Arrange
            var iUserRepositoryMock = new Mock<IUserRepository>();
            var userManagerMock = new Mock<UserManager>(iUserRepositoryMock.Object);
            var AdminRepositoryMock = new Mock<IAdminRepository>();
            var ReservationManagerMock = new Mock<ReservationManager>(iUserRepositoryMock.Object, AdminRepositoryMock.Object);
            var userController = new UserController(userManagerMock.Object, ReservationManagerMock.Object);

            List<Reservation> reservations = new List<Reservation>();

            userManagerMock.Setup(manager => manager.SearchReservationsAsync("test")).ReturnsAsync(reservations);

            // Act
            var result = await userController.SearchReservationsAsync("test");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}