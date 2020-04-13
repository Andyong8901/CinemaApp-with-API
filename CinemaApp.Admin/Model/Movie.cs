﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Admin.Model
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsShowing { get; set; }
        //public ShowingType ShowingType { get; set; }
        //public string ShowTime { get; set; }
        //public string Hall { get; set; }
    }
    //public enum ShowingType
    //{
    //    [Description("Now Showing")]
    //    Now_Showing,
    //    [Description("Coming Soon")]
    //    Coming_Soon
    //}
}
