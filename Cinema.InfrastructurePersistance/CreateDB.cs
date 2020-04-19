using Cinema.DomainModelEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.InfrastructurePersistance
{
    public class CreateDB : DbContext
    {
        public CreateDB() : base("CinemaApp")
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<HallSeat> HallSeats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }
        public DbSet<MovieCart> MovieCarts { get; set; }
    }
}
