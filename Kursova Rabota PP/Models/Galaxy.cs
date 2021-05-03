using System;
using System.Collections.Generic;
using System.Text;

namespace Kursova_Rabota_PP.Models
{
    public class Galaxy
    {
        private string galaxyName;
        private GalaxyType galaxyType;  // enum GalaxyType
        private float galaxyAge;
        private string ageMagnitude;
        public List<Star> Stars { get; set; }

        public Galaxy()
        {
            Stars = new List<Star>();
        }

        public string GalaxyName
        {
            get { return this.galaxyName; }
            set { this.galaxyName = value; }
        }
        public float GalaxyAge
        {
            get { return this.galaxyAge; }
            set { this.galaxyAge = value; }
        }
        public string AgeMagnitude
        {
            get { return this.ageMagnitude; }
            set { this.ageMagnitude = value; }
        }

        public GalaxyType GalaxyType
        {
            get { return this.galaxyType; }
            set { this.galaxyType = value; }
        }





    }





}
