using SolutionReservation.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Domain.Model
{
    public class Restaurant
    {
        public Restaurant(int id,string name, Location location, string keuken, string phone, string email, bool isactive,List<Table> tables)
        {
            SetId(id);
            SetName(name);
            SetLocation(location);
            SetKeuken(keuken);
            SetPhone(phone);
            SetEmail(email);
            IsActive = isactive;
            SetTables(tables);
        }

        public Restaurant(string name, string keuken, string phone, string email, Location location, List<Table> tables)
        {
            SetName(name);
            SetLocation(location);
            SetKeuken(keuken);
            SetPhone(phone);
            SetEmail(email);
            IsActive = true;
            SetTables(tables);
        }

        public Restaurant(string name, string keuken, string phone, string email, Location location)
        {
            SetName(name);
            SetLocation(location);
            SetKeuken(keuken);
            SetPhone(phone);
            SetEmail(email);
            IsActive = true;
        }

        public Restaurant() { }

        public int Id { get;private set; }
        public string Name { get; private set; }
        public Location Location { get; private set; }
        public string Keuken { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        public List<Table> Tables { get; private set; }

        public bool IsActive { get; private set; }

        public void SetId(int id)
        {
            if (id == 0) throw new RestaurantException("Id is invalid");
            Id = id;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new RestaurantException("Name is invalid");
            Name = name;
        }

        public void SetLocation(Location location)
        {
            if (location == null) throw new ReservationException("location is invalid");
            Location = location;
        }

        public void SetKeuken(string keuken)
        {
            if (string.IsNullOrEmpty(keuken)) throw new RestaurantException("Keuken is invalid");
            Keuken = keuken;
        }

        public void SetPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) throw new RestaurantException("Phone is not valid");
            Phone = phone;
        }

        public void SetEmail(string email)
        {
            if (!email.Contains('@')) throw new RestaurantException($"{nameof(Email)}: {email} is invalid");
            Email = email;
        }

        public void SetTables(List<Table> tables)
        {
            if (tables == null) throw new RestaurantException("Tables is invalid");
            Tables = tables;
        }
    }
}
