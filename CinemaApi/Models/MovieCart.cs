using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApi.Models
{
    public class MovieCart
    {
        public int MovieCartId { get; set; }
        public string MovieName { get; set; }
        public double Amount { get; set; }


        public string SeatNo { get; set; }
        public int SeatId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}