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
        Task<User> GetAsync(int clientNumber);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(int clientNumber,User user);
        Task<User> DeleteUserAsync(int clientNumber);
    }
}
