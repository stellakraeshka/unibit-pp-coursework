using Kursova_Rabota_PP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kursova_Rabota_PP
{
    public class Engine
    {
        private List<Galaxy> Galaxies;
        private List<Planet> Planets;
        private List<Star> Stars;
        private List<Moon> Moons;

        public Engine()
        {
            this.Galaxies = new List<Galaxy>();
            this.Planets = new List<Planet>();
            this.Stars = new List<Star>();
            this.Moons = new List<Moon>();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "exit" && !String.IsNullOrEmpty(input))
            {
                string[] commandParts = SplitInput(input);
                string command = commandParts[0];
                switch (command)
                {
                    case ("add"):
                        switch (commandParts[1])
                        {
                            case ("galaxy"):
                                AddGalaxy(commandParts[2], commandParts[3], commandParts[4]);
                                break;
                            case ("star"):
                                AddStar(commandParts[2], commandParts[3], commandParts[6], commandParts[4], commandParts[7], commandParts[5]);
                                break;
                            case ("planet"):
                                AddPlanet(commandParts[2], commandParts[3], commandParts[4], commandParts[5]);
                                break;
                            case ("moon"):
                                AddMoon(commandParts[2], commandParts[3]);
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("stats"):
                        GetStats();
                        break;


                    case ("list"):
                        switch (commandParts[1])
                        {
                            case ("galaxies"):
                                ListGalaxies();
                                break;
                            case ("stars"):
                                ListStars();
                                break;
                            case ("planets"):
                                ListPlanets();
                                break;
                            case ("moons"):
                                ListMoons();
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("print"):
                        Print(commandParts[1]);
                        break;
                    default:
                        break;

                }
                input = Console.ReadLine();
            }
        }
        private void AddGalaxy(string newGalaxyName, string newGalaxyType, string newGalaxyAge)
        {
            Galaxy newGalaxy = new Galaxy();
            newGalaxy.GalaxyName = newGalaxyName;
            newGalaxy.GalaxyType = (GalaxyType)Enum.Parse(typeof(GalaxyType), newGalaxyType, true);

            newGalaxy.AgeMagnitude = newGalaxyAge[newGalaxyAge.Length - 1].ToString();
            newGalaxy.GalaxyAge = float.Parse(newGalaxyAge.Substring(0, newGalaxyAge.Length - 1));

            this.Galaxies.Add(newGalaxy);  // dobavia obekt Galaxy kam list Galaxies 

        }

        private void AddStar(string newGalaxyName, string newStarName, string newTemp, string newMass, string newLumin, string newSize)
        {
            float tmass = float.Parse(newMass);
            float tsize = float.Parse(newSize);
            int ttemp = int.Parse(newTemp);
            float tlumin = float.Parse(newLumin);
            Star newStar = new Star(newStarName, tmass, tsize, ttemp, tlumin);
            foreach (Galaxy g in Galaxies)
            {
                if (g.GalaxyName == newGalaxyName)
                {
                    g.Stars.Add(newStar);
                }
            }
            this.Stars.Add(newStar);

        }
        private void AddPlanet(string newStarName, string newPlanetName, string newPlanetType, string newPlanethabbit)
        {
            bool isHabbitable = newPlanethabbit == "yes";

            Planet newPlanet = new Planet(newPlanetName, newPlanetType, isHabbitable);

            foreach (Star s in Stars)

            {
                if (s.StarName == newStarName)
                {
                    s.Planets.Add(newPlanet);
                }
            }
            this.Planets.Add(newPlanet);
        }
        private void AddMoon(string newPlanetname, string newMoonName)
        {
            Moon newMoon = new Moon(newMoonName);

            foreach (Planet p in Planets)
            {
                if (p.PlanetName == newPlanetname)
                {
                    newMoon.Planet = p;
                    p.Moons.Add(newMoon);
                }
            }
            this.Moons.Add(newMoon);
        }
        private void ListGalaxies()
        {
            Console.WriteLine("--- List of all researched galaxies ---");
            foreach (Galaxy g in Galaxies)
            {
                Console.WriteLine(g.GalaxyName);
            }
            Console.WriteLine("--- End of galaxies list ---");
        }
        private void ListStars()
        {
            Console.WriteLine("--- List of all researched stars ---");
            foreach (Star s in Stars)
            {
                Console.WriteLine(s.StarName);
            }
            Console.WriteLine("--- End of stars list ---");
        }
        private void ListPlanets()
        {
            Console.WriteLine("--- List of all researched planets ---");
            foreach (Planet p in Planets)
            {
                Console.WriteLine(p.PlanetName);
            }
            Console.WriteLine("--- End of planets list ---");
        }
        private void ListMoons()
        {
            Console.WriteLine("--- List of all researched moons ---");
            foreach (Moon m in Moons)
            {
                Console.WriteLine(m.MoonName);
            }
            Console.WriteLine("--- End of moons list ---");
        }

        private string[] SplitInput(string input)
        {
            StringBuilder temp = new StringBuilder();
            var parts = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    parts.Add(temp.ToString());
                    temp.Clear();
                    continue;
                }
                if (input[i] == '[')
                {
                    i++;
                    while (input[i] != ']')
                    {
                        temp.Append(input[i]);
                        i++;
                    }
                    parts.Add(temp.ToString());
                    temp.Clear();
                    i++;
                    continue;
                }
                temp.Append(input[i]);
            }
            parts.Add(temp.ToString());

            return parts.ToArray();
        }

        private void GetStats()
        {
            Console.WriteLine("--- Stats ---");
            Console.WriteLine($"Galaxies: {this.Galaxies.Count}");
            Console.WriteLine($"Stars: {this.Stars.Count}");
            Console.WriteLine($"Planets: {this.Planets.Count}");
            Console.WriteLine($"Moons: {this.Moons.Count}");
            Console.WriteLine("--- End of Stats ---");
        }
        private void Print(string GalaxyName)
        {
            Console.WriteLine($"--- Data for {GalaxyName} galaxy ---");
            Galaxy galaxy = Galaxies.FirstOrDefault(g => g.GalaxyName == GalaxyName);
            Console.WriteLine($"Type:{galaxy.GalaxyType}");
            Console.WriteLine($"Age:{galaxy.GalaxyAge}{galaxy.AgeMagnitude}");
            Console.WriteLine("Stars:");
            foreach (Star s in galaxy.Stars)
            {
                Console.WriteLine($"    -  Name:{s.StarName}");
                Console.WriteLine($"       Class:{s.StarClass} ({s.StarMass},{s.StarSize},{s.StarTemp},{s.StarLuminosity:f2})");

                Console.WriteLine($"       Planets:");
                foreach (Planet p in s.Planets)
                {
                    Console.WriteLine($"         ■   Name:{p.PlanetName}");
                    Console.WriteLine($"             Type:{p.PlanetType}");
                    var isHabbitable = p.isHabitable ? "yes" : "no";
                    Console.WriteLine($"             Support life:{isHabbitable}");

                    Console.WriteLine($"             Moons:");
                    foreach (Moon m in p.Moons)
                    {
                        Console.WriteLine($"                    ■    {m.MoonName}");
                    }

                }
                Console.WriteLine($"--- End of data for {GalaxyName} galaxy ---");
            }


        }


    }
}
