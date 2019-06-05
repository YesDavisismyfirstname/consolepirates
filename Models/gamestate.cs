using System.Collections.Generic;
namespace consolepirates.Models
{
    public class Game
    {
        public Player newPlayer;

        public Game(string newname, string startingship)
        {
            Program.world = new WorldMap();
            newPlayer = new Player(newname, startingship);
            newPlayer.currentLocation.displayInfo();

        }
        public void Action(string choice)
        {

            // string choice = 
            newPlayer.currentLocation.displayInfo();
        }

    }
    public interface IEventable
    {
        List<Action> actions { get; set; }
    }
    public abstract class Action
    {
        public string name;
        public string description;

    }
    public class Purchase : Action
    {
        public Purchase(ILootable item, int quantity){
            name = "purchase";
            description = "Purchase items from a store"
            Program.newGame.newPlayer.currentShip.currentCargo.Add()
        }
        
    }
}