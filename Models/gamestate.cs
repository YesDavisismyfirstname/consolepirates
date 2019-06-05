using System.Collections.Generic;
using System;
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
        public Purchase(){
            name = "purchase";
            description = "Purchase items from a store";
        }
        public Action(object selection) {
            Loot option = (Loot)selection;
            int purchaseamt = 0;
            System.Console.WriteLine("Input how many you would like to buy?");
            string qty = System.Console.ReadLine();
            if (Int32.TryParse(qty, out int numValue))
            {
            purchaseamt = numValue;
            int currentload = Program.newGame.newPlayer.currentShip.currentCargo.Count;
            int spaceAvailable = Program.newGame.newPlayer.currentShip.cargoSpace - currentload;
            if(purchaseamt < spaceAvailable*option.inventorySpace){
                while(purchaseamt >0) {
                    if(purchaseamt > option.inventorySpace)
                    Program.newGame.newPlayer.currentShip.currentCargo.Add(option)
                }
            }
            }
            else
            {
            Console.WriteLine($"Thats not a valid ammount try again");
            Program.newGame.newPlayer.currentLocation.displayInfo();
            }

        }
        
    }
}