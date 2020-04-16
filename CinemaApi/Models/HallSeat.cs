using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Models
{
    public class HallSeat
    {
        [Key]
        public int SeatId { get; set; }
        public DateTime ShowTime { get; set; }
        public string SeatNumber { get; set; }
        public SeatStatus Seatstatus { get; set; }
        public int HallId { get; set; }
        public virtual Hall Hall { get; set; }
        //public int MovieDetailId { get; set; }
        //public virtual MovieDetail MovieDetail { get; set; }
    }
    public enum SeatStatus
    {
        Empty, Taken
    }
}
