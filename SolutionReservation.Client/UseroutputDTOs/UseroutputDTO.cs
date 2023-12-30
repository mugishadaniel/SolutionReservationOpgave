using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Client.UseroutputDTOs
{
    public class UseroutputDTO
    {
        public UseroutputDTO() { }
        public int Clientnumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public LocationoutputDTO Location { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Clientnumber: {Clientnumber}, Name: {Name}, Email: {Email}, Phone: {Phone}, Location: {Location.street} {Location.housenumber}  {Location.postalcode} {Location.municipality}, IsActive: {IsActive}";
        }
    }
}
