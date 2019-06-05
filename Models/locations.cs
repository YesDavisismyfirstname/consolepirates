using System.Collections.Generic;

namespace consolepirates.Models
    {
        abstract public class Location
        {
            public string name;
            public List<Action> actions;
            public string locationArt;
            public string description;
            public List<Location> availableLocations;
            public void displayInfo(){
                System.Console.Write(locationArt);
                System.Console.WriteLine("Pick from the following options");
                foreach(Action item in actions){
                    System.Console.WriteLine(item.name);
                }
            }
        }
        public class WorldMap : Location, IEventable
        {
            public List<Action> actions{get;set;}
            public List<City> locations;
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
     .-'           *Tortuga          ;
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
                ";
                City Tortuga = new City("Tortuga","Welcome to Tortuga a beautiful place","######################");
                locations.Add(Tortuga);
                availableLocations.Add(Tortuga);
                description = "You can plan your next destination here.";
                // actions = new List<Action>();
                // foreach(Location loc in availableLocations){
                //     actions.Add(new Travel(loc));
                // }
                // actions.Add(new Travel(availableLocations))
                // cityList = new List<City>();
            }
        }
        public class City : Location, IEventable
        {
            public List<Action> actions{get;set;}
            public City(string name, string description, string art){
                this.name = name;
                this.description = description;
                this.locationArt = art;
                actions = new List<Action>();
                this.availableLocations = new List<Location>();
                availableLocations.Add(new Shop("Tortuga Emporium"));
            }
        }
        public class Shop : Location, IEventable
        {
            public List<Action> actions{get;set;}
            public Shop(string name){
                description = "You can buy and sell trades here.";
                actions = new List<Action>(){
                new Purchase()
            };
            }
        }
        // public class Shipyard : Location, IEventable
        // {
        //     public Shipyard(){
        //         description ="You can fix your ship here.";
        //         actions = new List<Action>();
        //     }
        // }

      
    }