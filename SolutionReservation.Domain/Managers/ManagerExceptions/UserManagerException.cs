using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Domain.Managers.ManagerExceptions
{
    public class UserManagerException : Exception
    {
        public UserManagerException(string message) : base(message)
        {

        }
        public UserManagerException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
