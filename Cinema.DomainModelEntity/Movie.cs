using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DomainModelEntity
{
    public class Movie
    {
        public int MovieId { get; set; }
        public int MovieNo { get; set; }
        public string MovieName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dddd dd MMM yyyy}")]
        public DateTime ReleaseDate { get; set; }
        public bool IsShowing { get; set; }
        //public ShowingType ShowingType { get; set; }
        //public string ShowTime { get; set; }
        //public string Hall { get; set; }

        public virtual ICollection<MovieDetail> MovieDetails { get; set; }
    }
    //public enum ShowingType
    //{
    //    [Description("Now Showing")]
    //    Now_Showing,
    //    [Description("Coming Soon")]
    //    Coming_Soon
    //}
}
