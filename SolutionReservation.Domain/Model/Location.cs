using SolutionReservation.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Domain.Model
{
    public class Location
    {
        public Location(int postalCode, string municipality, string? street, string? houseNumber)
        {
            SetPostalCode(postalCode);
            SetMunicipality(municipality);
            Street = street;
            HouseNumber = houseNumber;
        }

        public int PostalCode { get; private set; }
        public string Municipality { get; private set; }
        public string? Street { get; private set; }
        public string? HouseNumber { get; private set; }

        public void SetPostalCode(int postalCode)
        {
            if (postalCode < 0) throw new LocationException("PostalCode is invalid");
            PostalCode = postalCode;
        }

        public void SetMunicipality(string municipality)
        {
            if (string.IsNullOrEmpty(municipality)) throw new LocationException("Municipality is invalid");
            Municipality = municipality;
        }
    }
}
