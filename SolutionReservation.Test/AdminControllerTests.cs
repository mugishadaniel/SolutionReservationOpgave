using Microsoft.AspNetCore.Mvc;
using Moq;
using SolutionReservation.API.Controllers;
using SolutionReservation.API.DTO.Input;
using SolutionReservation.API.MapperDTO;
using SolutionReservation.Domain.Interfaces;
using SolutionReservation.Domain.Managers;
using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Test
{
    public class AdminControllerTests
    {
        [Fact]
        public async Task AddRestaurantAsync_ShouldReturnOk()
        {
            // Arrange
            var iAdminRepositoryMock = new Mock<IAdminRepository>();
            var adminManagerMock = new Mock<AdminManager>(iAdminRepositoryMock.Object);
            var adminController = new AdminController(adminManagerMock.Object);
            RestaurantInputDTO restaurantinputDTO = new RestaurantInputDTO()
            {
                Name = "test",
                Keuken = "test",
                Phone = "01185",
                Email = "test@",
                PostalCode = 1,
                Municipality = "test",
                Street = "test",
                HouseNumber = "test"
            };
            Restaurant restaurant = new Restaurant();
            restaurant = RestaurantMapperDTO.ToDomain(restaurantinputDTO);
            adminManagerMock.Setup(manager => manager.AddRestaurantAsync(It.IsAny<Restaurant>())).ReturnsAsync(restaurant);
            // Act
            var result = await adminController.AddRestaurantAsync(restaurantinputDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task AddRestaurantAsync_ShouldReturnBadRequest()
        {
            // Arrange
            var iAdminRepositoryMock = new Mock<IAdminRepository>();
            var adminManagerMock = new Mock<AdminManager>(iAdminRepositoryMock.Object);
            var adminController = new AdminController(adminManagerMock.Object);
            var restaurantinputDTO = new RestaurantInputDTO()
            {
                Name = "test",
                Keuken = "test",
                Phone = "01185",
                Email = "test@",
                PostalCode = 1,
                Municipality = "test",
                Street = "test",
                HouseNumber = "test"
            };
            var restaurant = new Restaurant();
            adminManagerMock.Setup(manager => manager.AddRestaurantAsync(restaurant)).ReturnsAsync((Restaurant)null);
            // Act
            var result = await adminController.AddRestaurantAsync(restaurantinputDTO);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateRestaurantAsync_ShouldReturnOk()
        {
            // Arrange
            var iAdminRepositoryMock = new Mock<IAdminRepository>();
            var adminManagerMock = new Mock<AdminManager>(iAdminRepositoryMock.Object);
            var adminController = new AdminController(adminManagerMock.Object);
            var restaurantinputDTO = new RestaurantInputDTO()
            {
                Name = "test",
                Keuken = "test",
                Phone = "01185",
                Email = "test@",
                PostalCode = 1,
                Municipality = "test",
                Street = "test",
                HouseNumber = "test"
            };
            var restaurant = new Restaurant();
            adminManagerMock.Setup(manager => manager.ExistsRestaurantAsync(1)).ReturnsAsync(true);
            adminManagerMock.Setup(manager => manager.GetRestaurantAsync(1)).ReturnsAsync(restaurant);
            adminManagerMock.Setup(manager => manager.UpdateRestaurantAsync(1, restaurant)).ReturnsAsync(restaurant);
            // Act
            var result = await adminController.UpdateRestaurantAsync(1, restaurantinputDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateRestaurantAsync_ShouldReturnNotFound()
        {
            // Arrange
            var iAdminRepositoryMock = new Mock<IAdminRepository>();
            var adminManagerMock = new Mock<AdminManager>(iAdminRepositoryMock.Object);
            var adminController = new AdminController(adminManagerMock.Object);
            var restaurantinputDTO = new RestaurantInputDTO()
            {
                Name = "test",
                Keuken = "test",
                Phone = "01185",
                Email = "test@",
                PostalCode = 1,
                Municipality = "test",
                Street = "test",
                HouseNumber = "test"
            };
            var restaurant = new Restaurant();
            adminManagerMock.Setup(manager => manager.ExistsRestaurantAsync(1)).ReturnsAsync(false);
            adminManagerMock.Setup(manager => manager.GetRestaurantAsync(1)).ReturnsAsync(restaurant);
            adminManagerMock.Setup(manager => manager.UpdateRestaurantAsync(1, restaurant)).ReturnsAsync(restaurant);
            // Act
            var result = await adminController.UpdateRestaurantAsync(1, restaurantinputDTO);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task DeleteRestaurantAsync_ShouldReturnOk()
        {
            // Arrange
            var iAdminRepositoryMock = new Mock<IAdminRepository>();
            var adminManagerMock = new Mock<AdminManager>(iAdminRepositoryMock.Object);
            var adminController = new AdminController(adminManagerMock.Object);
            adminManagerMock.Setup(manager => manager.ExistsRestaurantAsync(1)).ReturnsAsync(true);
            // Act
            var result = await adminController.DeleteRestaurantAsync(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteRestaurantAsync_ShouldReturnNotFound()
        {
            // Arrange
            var iAdminRepositoryMock = new Mock<IAdminRepository>();
            var adminManagerMock = new Mock<AdminManager>(iAdminRepositoryMock.Object);
            var adminController = new AdminController(adminManagerMock.Object);
            adminManagerMock.Setup(manager => manager.ExistsRestaurantAsync(1)).ReturnsAsync(false);
            // Act
            var result = await adminController.DeleteRestaurantAsync(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }



        [Fact]
        public async Task GetReservationsAsync_ShouldReturnOk()
        {
            // Arrange
            var iAdminRepositoryMock = new Mock<IAdminRepository>();
            var adminManagerMock = new Mock<AdminManager>(iAdminRepositoryMock.Object);
            var adminController = new AdminController(adminManagerMock.Object);
            var reservations = new List<Reservation>();
            adminManagerMock.Setup(manager => manager.GetReservationsAsync(1)).ReturnsAsync(reservations);
            adminManagerMock.Setup(manager => manager.ExistsRestaurantAsync(1)).ReturnsAsync(true);
            // Act
            var result = await adminController.GetReservationsAsync(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetReservationsAsync_ShouldReturnNotFound()
        {
            // Arrange
            var iAdminRepositoryMock = new Mock<IAdminRepository>();
            var adminManagerMock = new Mock<AdminManager>(iAdminRepositoryMock.Object);
            var adminController = new AdminController(adminManagerMock.Object);
            var reservations = new List<Reservation>();
            adminManagerMock.Setup(manager => manager.GetReservationsAsync(1)).ReturnsAsync(reservations);
            adminManagerMock.Setup(manager => manager.ExistsRestaurantAsync(1)).ReturnsAsync(false);
            // Act
            var result = await adminController.GetReservationsAsync(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }


        [Fact]
        public async Task GetReservationsAsyncPeriodReturnsOk()
        {
            // Arrange
            var iAdminRepositoryMock = new Mock<IAdminRepository>();
            var adminManagerMock = new Mock<AdminManager>(iAdminRepositoryMock.Object);
            var adminController = new AdminController(adminManagerMock.Object);
            var user = new User(1, "test", "test", "test", new Location(1, "test", "test", ""), true);
            List<Reservation> reservations = new List<Reservation>();
            var restaurant = new Restaurant(1, "test", new Location(1, "test", "test", ""), "test", "test", "test@", true, new List<Table>());
            reservations.Add(new Reservation(1, restaurant, user, 1, new DateTime(2025, 1, 1), 1));
            DateOnly startDate = new DateOnly(2025, 1, 1);
            DateOnly endDate = new DateOnly(2025, 1, 2);
            adminManagerMock.Setup(manager => manager.GetReservationsAsync(1, startDate, endDate)).ReturnsAsync(reservations);
            adminManagerMock.Setup(manager => manager.ExistsRestaurantAsync(1)).ReturnsAsync(true);
            // Act
            var result = await adminController.GetReservationsAsync(1, startDate, endDate);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetReservationsAsyncPeriodReturnsNotFound()
        {
            // Arrange
            var iAdminRepositoryMock = new Mock<IAdminRepository>();
            var adminManagerMock = new Mock<AdminManager>(iAdminRepositoryMock.Object);
            var adminController = new AdminController(adminManagerMock.Object);

            List<Reservation> reservations = new List<Reservation>();
            var restaurant = new Restaurant(1, "test", new Location(1, "test", "test", ""), "test", "test", "test@", true, new List<Table>());
            var user = new User(1, "test", "test", "test", new Location(1, "test", "test", ""), true);
            reservations.Add(new Reservation(1, restaurant, user, 1, new DateTime(2025, 1, 1), 1));
            DateOnly startDate = new DateOnly(2025, 1, 1);
            DateOnly endDate = new DateOnly(2025, 1, 2);
            adminManagerMock.Setup(manager => manager.GetReservationsAsync(1, startDate, endDate)).ReturnsAsync(reservations);
            adminManagerMock.Setup(manager => manager.ExistsRestaurantAsync(1)).ReturnsAsync(false);
            // Act
            var result = await adminController.GetReservationsAsync(1, startDate, endDate);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

    }
}
