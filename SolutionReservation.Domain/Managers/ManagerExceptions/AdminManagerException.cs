﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Domain.Managers.ManagerExceptions
{
    public class AdminManagerException : Exception
    {
        public AdminManagerException(string message) : base(message)
        {

        }

        public AdminManagerException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
