using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Repositories.RepositoryExceptions
{
    public class AdminRepositoryException : Exception
    {
        public AdminRepositoryException(string message) : base(message)
        {

        }

        public AdminRepositoryException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
