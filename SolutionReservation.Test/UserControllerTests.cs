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
        public async Task UpdateUserAsyncShouldReturnOk()
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

            userManagerMock.Setup(manager => manager.UpdateUserAsync(1, user)).ReturnsAsync(user);
            userManagerMock.Setup(manager => manager.GetUserAsync(1)).ReturnsAsync(user);
            userManagerMock.Setup(manager => manager.ExistsAsync(1)).ReturnsAsync(true);

            // Act
            var result = await userController.UpdateUserAsync(1, userinputDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateUserAsyncShouldReturnNotFound()
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

            userManagerMock.Setup(manager => manager.UpdateUserAsync(1, user)).ReturnsAsync(user);
            userManagerMock.Setup(manager => manager.GetUserAsync(1)).ReturnsAsync(user);
            userManagerMock.Setup(manager => manager.ExistsAsync(1)).ReturnsAsync(false);

            // Act
            var result = await userController.UpdateUserAsync(1, userinputDTO);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task DeleteUserAsyncShouldReturnOk()
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
        public async Task DeleteUserAsyncShouldReturnNotFound()
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
        public async Task SearchRestaurantAsyncReturnsOk()
        {
            // Arrange
            var iUserRepositoryMock = new Mock<IUserRepository>();
            var userManagerMock = new Mock<UserManager>(iUserRepositoryMock.Object);
            var AdminRepositoryMock = new Mock<IAdminRepository>();
            var ReservationManagerMock = new Mock<ReservationManager>(iUserRepositoryMock.Object, AdminRepositoryMock.Object);
            var userController = new UserController(userManagerMock.Object, ReservationManagerMock.Object);
            List<Restaurant> restaurants = new List<Restaurant>();
            restaurants.Add(new Restaurant(1, "test", new Location(1, "test", "test", ""), "test", "test", "test@", true, new List<Table>()));

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
        public async Task AddReservationAsyncReturnsOk()
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
            Table table = new Table(1, 1, 1);
            List<Table> tables = new List<Table>();
            tables.Add(table);
            var restaurant = new Restaurant(1, "test", new Location(1, "test", "test", ""), "test", "test", "test@", true, tables);
            var reservation = new Reservation(1, restaurant, user, 1, new DateTime(2025, 1, 1), 1);
            var reservationInputDTO = new ReservationInputDTO()
            {
                NumberofSeats = 1,
                DateTime = new DateTime(2025, 1, 1)
            };

            userManagerMock.Setup(manager => manager.AddReservationAsync(1, 1, reservation)).ReturnsAsync(reservation);
            userManagerMock.Setup(manager => manager.ExistsAsync(1)).ReturnsAsync(true);
            userManagerMock.Setup(manager => manager.ExistsRestaurantAsync(1)).ReturnsAsync(true);
            ReservationManagerMock.Setup(manager => manager.TryMakeReservationAsync(
                    It.IsAny<Reservation>(),
                    It.IsAny<int>(),
                    It.IsAny<int>())
                    ).ReturnsAsync(true);

            // Act
            var result = await userController.AddReservationAsync(1, 1, reservationInputDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task AddReservationAsyncReturnsBadRequest()
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

            Table table = new Table(1, 1, 1);
            List<Table> tables = new List<Table>();
            tables.Add(table);

            var restaurant = new Restaurant(1, "test", new Location(1, "test", "test", ""), "test", "test", "test@", true, tables);

            var reservation = new Reservation(1, restaurant, user, 1, new DateTime(2025, 1, 1), 1);

            var reservationInputDTO = new ReservationInputDTO()
            {
                NumberofSeats = 1,
                DateTime = new DateTime(2025, 1, 1)
            };

            userManagerMock.Setup(manager => manager.AddReservationAsync(1, 1, reservation)).ReturnsAsync(reservation);
            userManagerMock.Setup(manager => manager.ExistsAsync(1)).ReturnsAsync(true);
            userManagerMock.Setup(manager => manager.ExistsRestaurantAsync(1)).ReturnsAsync(true);
            ReservationManagerMock.Setup(manager => manager.TryMakeReservationAsync(
                                   It.IsAny<Reservation>(),
                                                      It.IsAny<int>(),
                                                                         It.IsAny<int>())
                               ).ReturnsAsync(false);

            // Act
            var result = await userController.AddReservationAsync(1, 1, reservationInputDTO);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public async Task UpdateReservationAsyncReturnsOK()
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

            Table table = new Table(1, 1, 1);
            List<Table> tables = new List<Table>();
            tables.Add(table);

            var restaurant = new Restaurant(1, "test", new Location(1, "test", "test", ""), "test", "test", "test@", true, tables);

            var reservation = new Reservation(1, restaurant, user, 1, new DateTime(2025, 1, 1), 1);

            var reservationInputDTO = new ReservationInputDTO()
            {
                NumberofSeats = 1,
                DateTime = new DateTime(2025, 1, 1)
            };

            userManagerMock.Setup(manager => manager.UpdateReservationAsync(1, reservation)).ReturnsAsync(reservation);
            userManagerMock.Setup(manager => manager.GetReservationAsync(1)).ReturnsAsync(reservation);
            userManagerMock.Setup(manager => manager.ExistsReservation(1)).ReturnsAsync(true);
            userManagerMock.Setup(manager => manager.ExistsAsync(1)).ReturnsAsync(true);
            userManagerMock.Setup(manager => manager.ExistsRestaurantAsync(1)).ReturnsAsync(true);
            ReservationManagerMock.Setup(manager => manager.TryMakeReservationAsync(
                   It.IsAny<Reservation>(),
                    It.IsAny<int>(), It.IsAny<int>())
                   ).ReturnsAsync(true);

            // Act
            var result = await userController.UpdateReservationAsync(1, reservationInputDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task UpdateReservationAsyncReturnsBadRequest()
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

            Table table = new Table(1, 1, 1);
            List<Table> tables = new List<Table>();
            tables.Add(table);

            var restaurant = new Restaurant(1, "test", new Location(1, "test", "test", ""), "test", "test", "test@", true, tables);

            var reservation = new Reservation(1, restaurant, user, 1, new DateTime(2025, 1, 1), 1);

            var reservationInputDTO = new ReservationInputDTO()
            {
                NumberofSeats = 1,
                DateTime = new DateTime(2025, 1, 1)
            };

            userManagerMock.Setup(manager => manager.UpdateReservationAsync(1, reservation)).ReturnsAsync(reservation);
            userManagerMock.Setup(manager => manager.GetReservationAsync(1)).ReturnsAsync(reservation);
            userManagerMock.Setup(manager => manager.ExistsReservation(1)).ReturnsAsync(true);
            userManagerMock.Setup(manager => manager.ExistsAsync(1)).ReturnsAsync(true);
            userManagerMock.Setup(manager => manager.ExistsRestaurantAsync(1)).ReturnsAsync(true);
            ReservationManagerMock.Setup(manager => manager.TryMakeReservationAsync(
                                  It.IsAny<Reservation>(),
                                                     It.IsAny<int>(), It.IsAny<int>())
                              ).ReturnsAsync(false);

            // Act
            var result = await userController.UpdateReservationAsync(1, reservationInputDTO);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task DeleteReservationAsyncReturnsOK()
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

            Table table = new Table(1, 1, 1);
            List<Table> tables = new List<Table>();
            tables.Add(table);

            var restaurant = new Restaurant(1, "test", new Location(1, "test", "test", ""), "test", "test", "test@", true, tables);

            var reservation = new Reservation(1, restaurant, user, 1, new DateTime(2025, 1, 1), 1);

            var reservationInputDTO = new ReservationInputDTO()
            {
                NumberofSeats = 1,
                DateTime = new DateTime(2025, 1, 1)
            };

            userManagerMock.Setup(manager => manager.DeleteReservationAsync(1)).ReturnsAsync(reservation);
            userManagerMock.Setup(manager => manager.ExistsReservation(1)).ReturnsAsync(true);

            // Act
            var result = await userController.DeleteReservationAsync(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteReservationAsyncReturnsNotFound()
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

            Table table = new Table(1, 1, 1);
            List<Table> tables = new List<Table>();
            tables.Add(table);

            var restaurant = new Restaurant(1, "test", new Location(1, "test", "test", ""), "test", "test", "test@", true, tables);

            var reservation = new Reservation(1, restaurant, user, 1, new DateTime(2025, 1, 1), 1);

            var reservationInputDTO = new ReservationInputDTO()
            {
                NumberofSeats = 1,
                DateTime = new DateTime(2025, 1, 1)
            };

            userManagerMock.Setup(manager => manager.DeleteReservationAsync(1)).ReturnsAsync(reservation);
            userManagerMock.Setup(manager => manager.ExistsReservation(1)).ReturnsAsync(false);

            // Act
            var result = await userController.DeleteReservationAsync(1);

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
            var restaurant = new Restaurant(1, "test", new Location(1, "test", "test", ""), "test", "test", "test@", true, new List<Table>());
            reservations.Add(new Reservation(1, restaurant, user, 1, new DateTime(2025, 1, 1), 1));

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