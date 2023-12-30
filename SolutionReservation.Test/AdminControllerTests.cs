using Microsoft.AspNetCore.Mvc;
using Moq;
using SolutionReservation.API.Controllers;
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
    }
}
