using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Admin.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string ReleaseDate { get; set; }
        public bool IsShowing { get; set; }
        public string ShowingType { get; set; }
        public string ShowTime { get; set; }
        public string Hall { get; set; }
    }
}
