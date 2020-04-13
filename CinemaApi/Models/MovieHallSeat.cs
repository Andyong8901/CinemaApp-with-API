using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Models
{
    public class MovieHallSeat
    {
        public int HallId { get; set; }
        public string ShowTime { get; set; }
        public string MovieName { get; set; }
        public string SeatNumber { get; set; }
        public SeatStatus Seatstatus { get; set; }
    }
    public enum SeatStatus
    {
        Empty, Taken
    }
}
