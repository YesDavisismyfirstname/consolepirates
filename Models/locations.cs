using System.Collections.Generic;

namespace consolepirates.Models
    {
        abstract public class Location
        {
            public string description;
            public List<Location> availableLocations;
            public void displayLocation(string location){
                System.Console.WriteLine(locationArt);
            }
        }
        public class WorldMap : Location, IEventable
        {
            public List<City> cityList;
            public WorldMap(){
                description = "You can plan your next destination here.";
                actions = new List<Action>();
                cityList = new List<City>();
            }
        }
        public class City : Location, IEventable
        {
            public City(){
                description = "You can plunder here.";
                actions = new List<Action>();
            }
        }
        public class Shop : Location, IEventable
        {
            public Shop(){
                description = "You can buy and sell trades here.";
                actions = new List<Action>();
            }
        }
        public class Shipyard : Location, IEventable
        {
            public Shipyard(){
                description ="You can fix your ship here.";
                actions = new List<Action>();
            }
        }

      
    }