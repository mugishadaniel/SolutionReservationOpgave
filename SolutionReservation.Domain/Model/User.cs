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
        public User() { }
        public User(int clientnumber, string name, string email, string phone, Location location,bool isactive)
        {
            Clientnumber = clientnumber;
            Name = name;
            Email = email;
            Phone = phone;
            Location = location;
            IsActive = isactive;
        }

        public User(string name,string email, string phone, Location location)
        {
            SetName(name);
            SetEmail(email);
            SetPhone(phone);
            SetLocation(location);

        }

        public int Clientnumber { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public Location Location { get; set; }

        public bool IsActive { get; private set; }

        public void SetClientnumber(int clientnumber)
        {
            if (clientnumber < 0) throw new UserException("Clientnumber is invalid");
            Clientnumber = clientnumber;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new UserException("Name is invalid");
            Name = name;
        }

        public void SetEmail(string email)
        {
            if (!email.Contains('@')) throw new UserException($"{nameof(Email)}: {email} is invalid");
            Email = email;
        }

        public void SetPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone)) throw new UserException("Phone is invalid");
            if (!phone.All(char.IsDigit)) throw new UserException("Phone is invalid");
            Phone = phone;
        }

        public void SetLocation(Location location)
        {
            if (location is null) throw new UserException("location is invalid");
            Location = location;
        }

    }
}
