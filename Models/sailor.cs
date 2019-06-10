using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using consolepirates.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace consolepirates.Models
{
    public class Player
    {
        public string name;
        public Ship currentShip;
        public Location currentLocation;
        public Location lastLocation;
        public QuestList questHistory;
        public float gold;
        public int travelDays;

        public Player(string name, string shipName)
        {
            this.name = name; 
            currentShip = new Skipper(shipName);
            currentLocation = Program.world.availableLocations[0];
            lastLocation = Program.world;
            gold = 1000;
            travelDays = 0;    
            this.questHistory = new QuestList();
        }
    
    }
}


