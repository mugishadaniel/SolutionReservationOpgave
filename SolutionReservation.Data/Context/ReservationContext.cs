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
        public DbSet<UserEF> Users { get; set; }
        public DbSet<LocationEF> Locations { get; set; }
        public DbSet<ReservationEF> Reservations { get; set; }
        public DbSet<RestaurantEF> Restaurants { get; set;}
        public DbSet<TableEF> Tables { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DANIEL\SQLEXPRESS;Initial Catalog=ReservationDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True
");
        }
    }
}
