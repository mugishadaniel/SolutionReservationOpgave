using Microsoft.EntityFrameworkCore;
using SolutionReservation.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Context
{
    public class ReservationContext : DbContext
    {
        DbSet<UserEF> Users { get; set; }
        DbSet<LocationEF> Locations { get; set; }
        DbSet<ReservationEF> Reservations { get; set; }
        DbSet<RestaurantEF> Restaurants { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DANIEL\SQLEXPRESS;Initial Catalog=ReservationDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True
");
        }
    }
}
