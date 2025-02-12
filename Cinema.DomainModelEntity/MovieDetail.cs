﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DomainModelEntity
{
    public class MovieDetail
    {
        public int MovieDetailId { get; set; }
        public DateTime ShowTime { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int HallId { get; set; }
        public virtual Hall Hall { get; set; }

    }

}

