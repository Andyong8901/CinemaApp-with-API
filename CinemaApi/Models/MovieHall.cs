using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Models
{
    public class MovieHall
    {
        public int HallId { get; set; }
        public int HallNo { get; set; }
        public int SeatRow { get; set; }
        public int SeatColumn { get; set; }
        public int TotalSeat => SeatRow * SeatColumn;
    }
}
