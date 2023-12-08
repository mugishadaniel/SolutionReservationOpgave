﻿using SolutionReservation.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Domain.Model
{
    public class Restaurant
    {
        public Restaurant(string name, Location location, string keuken, int phone, string email)
        {
            SetName(name);
            SetLocation(location);
            SetKeuken(keuken);
            SetPhone(phone);
            SetEmail(email);
        }
        public string Name { get; private set; }
        public Location Location { get; private set; }
        public string Keuken { get; private set; }
        public int Phone { get; private set; }
        public string Email { get; private set; }

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

        public void SetPhone(int phone)
        {
            if (phone == 0) throw new RestaurantException("Phone is not valid");
            Phone = phone;
        }

        public void SetEmail(string email)
        {
            if (!email.Contains('@')) throw new RestaurantException($"{nameof(Email)}: {email} is invalid");
            Email = email;
        }
    }
}