using SolutionReservation.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Domain.Model
{
    public class User
    {
        public User(int clientnumber, string name, string email, int phone, Location location)
        {
            Clientnumber = clientnumber;
            Name = name;
            Email = email;
            Phone = phone;
            Location = location;
        }

        public int Clientnumber { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Phone { get; private set; }
        public Location Location { get; set; }

        public void SetClientnumber(int clientnumber)
        {
            if (clientnumber < 0) throw new UserException("Clientnumber is invalid");
            Clientnumber = clientnumber;
        }

        public void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name)) throw new UserException("Name is invalid");
            Name = name;
        }

        public void SetEmail(string email)
        {
            if (!email.Contains('@')) throw new UserException($"{nameof(Email)}: {email} is invalid");
            Email = email;
        }

        public void SetPhone(int phone)
        {
            if (phone == 0) throw new UserException("Phone is not valid");
            Phone = phone;
        }

        public void SetLocation(Location location)
        {
            if (location is null) throw new UserException("location is invalid");
            Location = location;
        }

    }
}
