﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DomainModelEntity
{
    public class Hall
    {
        public int HallId { get; set; }
        public int HallNo { get; set; }
        public int SeatRow { get; set; }
        public int SeatColumn { get; set; }
        public int TotalSeat => SeatRow * SeatColumn;

        public virtual ICollection<MovieDetail> MovieDetail { get; set; }
        public virtual ICollection<HallSeat> HallSeat { get; set; }
    }
}
