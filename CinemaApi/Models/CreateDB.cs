using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Models
{
    public class CreateDB : DbContext
    {
        public CreateDB() : base("CinemaApp")
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieHallSeat> MovieHallSeats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }
    }
}
