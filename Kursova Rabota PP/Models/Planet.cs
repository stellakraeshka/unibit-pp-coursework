using System;
using System.Collections.Generic;
using System.Text;

namespace Kursova_Rabota_PP.Models
{
    public class Planet
    {
        private Star star;
        public string PlanetName { get; set; }
        public string PlanetType { get; set; }
        public bool isHabitable { get; set; }   //support life of not
        public List<Moon> Moons;  ///
        public Planet(string name, string type, bool ishabitable)
        {
            PlanetName = name;
            PlanetType = type;
            isHabitable = ishabitable;
            this.Moons = new List<Moon>();
        }
        
    }
}

//terrestrial,
//giant planet,
//ice giant,
//mesoplanet,
//mini-neptune,
//planetar,
//super-earth,
//super-jupiter,
//sub-earth
