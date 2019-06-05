using System.Collections.Generic;

namespace consolepirates.Models
    {
        abstract public class Location
        {
            public string name;
            public string locationArt;
            public string description;
            public List<Location> availableLocations;
            public void displayInfo(){
                System.Console.Write(locationArt);
            }
        }
        public class WorldMap : Location, IEventable
        {
            public List<Action> actions{get;set;}
            public List<City> cityList;
            public WorldMap(){
                name = "World Map";

                locationArt = @"
###############################################
                                 _,__        .:
         Darwin <*  /        | \
            .-./     |.     :  :,
           /           '-._/     \_
          /                '       \
        .'                         *: Brisbane
     .-'                             ;
     |                               |
     \                              /
      |                            /
Perth  \*        __.--._          /
        \     _.'       \:.       |
        >__,-'             \_/*_.-'
                              Melbourne
                             :--,
                              '/
###############################################
                ");

                description = "You can plan your next destination here.";
                actions = new List<Action>();
                foreach(Location loc in availableLocations){
                    actions.Add(new Travel(loc));
                }
                actions.Add(new Travel(availableLocations))
                cityList = new List<City>();
            }
        }
        public class City : Location, IEventable
        {
            public List<Action> actions{get;set;}
            public City(string name, string description, string art){
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