using System.Collections.Generic;
namespace consolepirates.Models
{
    public class Player
    {
        public string name;
        public Ship currentShip;
        public Location currentLocation;
        public int gold;
        public int travelDays;

        public Player(string name, string shipName)
        {
            this.name = name;
            currentShip = new Skipper(shipName);
            currentLocation = Program.world.locations[0];
            gold = 100;
            travelDays = 0;
        }
    
    }
}


