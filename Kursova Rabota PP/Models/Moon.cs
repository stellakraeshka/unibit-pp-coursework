using System;
using System.Collections.Generic;
using System.Text;

namespace Kursova_Rabota_PP.Models
{
    public class Moon
    {
        public Planet Planet { get; set; }
        public string MoonName { get; set; }
        public Moon(string moonname)
        {
            this.MoonName = moonname;
        }
    }

}
