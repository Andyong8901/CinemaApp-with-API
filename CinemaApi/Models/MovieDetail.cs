using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Models
{
    public class MovieDetail
    {
        public int MovieDetailId { get; set; }
        public int MovieId { get; set; }
        public DateTime ShowTime { get; set; }
        public int Hall { get; set; }
    }
}
