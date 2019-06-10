using System;
using System.Collections.Generic;
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
    public class Game
    {
        public Player newPlayer;
        public string name;
        public Game(string newname, string startingship)
        {
            name = newname;
            // System.Console.WriteLine("Starting Game");
            Program.world = new WorldMap();
            newPlayer = new Player(newname, startingship);
            System.Console.WriteLine();
            // System.Console.WriteLine(newPlayer.name);


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
    public interface Action
    {
        string name { get; set; }
        string description { get; set; }

        void Act(string error = "");

    }
    public class Purchase : Action
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<Loot> Inventory;

        public Purchase(List<Loot> Inventory)
        {
            this.Inventory = Inventory;
            name = "View Stock";
            description = "Purchase items from a store";
        }
        public void Act(string error = "")
        {
            Player currentPlayer = Program.newGame.newPlayer;
            System.Console.Clear();
            System.Console.Write($@"
            ##################################################################
            #                                                                #
            {currentPlayer.currentLocation.locationArt}                  
            {currentPlayer.currentLocation.description}
            ##################################################################
            #                            For Sale                            #
            ##################################################################
            # Item              | Stock  | Price    | Space taken | Actions  #
            #----------------------------------------------------------------#
");
            for (int j = 0; j < Inventory.Count; j++)
            {
                string invSpace = Inventory[j].inventorySpace.ToString().PadRight(8);
                string itemprice = Math.Round((Inventory[j].baseCost * Inventory[j].storeSellMultiplier), 2).ToString();
                string amtString = (Inventory[j].ammount).ToString().PadRight(6);
                System.Console.Write(
$@"            # {j}-{Inventory[j].name.PadRight(16)}|  {amtString}| ${itemprice.PadRight(8)}|    {invSpace}| <Detail>  #
");
            };
            System.Console.Write(

$@"            ##################################################################                      
                    {error.PadRight(52)}
                      Type the name of the Item you wish to purchase 
                  or check details by adding 'Detail' to the end of the 
                        item name, type Return to exit Buy menu

            ##################################################################
             Ship: {currentPlayer.currentShip.name} Gold: {currentPlayer.gold}, 
             Cargo Space: {currentPlayer.currentShip.currentSpace}/{currentPlayer.currentShip.cargoSpace}

    Please make your selection:
");
            string choice = Console.ReadLine();
            string valid = "";
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (choice == "Return")
                {
                    return;
                }
                else if (choice == Inventory[i].name || choice == i.ToString())
                {
                    System.Console.WriteLine($"Buying {Inventory[i].name}");
                    Inventory[i].buyItem((float)(Inventory[i].baseCost * Inventory[i].storeSellMultiplier));
                    valid = "true";
                    System.Console.WriteLine("Are you done purchasing? y/n");
                    choice = Console.ReadLine();
                    if (choice == "n")
                    {
                        Act();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if (valid == "")
            {
                Act("You made an invalid selection");
            }
            return;
        }

    }
    public class Sell : Action
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<Loot> Inventory;

        public Sell(List<Loot> Inventory)
        {
            this.Inventory = Inventory;
            name = "Sell Cargo";
            description = "Sell your inventory";
        }
        public void Act(string error = "")
        {
            Player currentPlayer = Program.newGame.newPlayer;
            List<Loot> currentInv = currentPlayer.currentShip.currentCargo;
            System.Console.Clear();
            System.Console.Write($@"
            ##################################################################
            #                                                                #
            #{currentPlayer.currentLocation.locationArt}         #               
            {currentPlayer.currentLocation.description}
            ##################################################################
            #                           Sell Cargo                           #
            ##################################################################
            # Item             | Store Stock| Sell  | Your Stock | Actions   #
            #--------+-------------------------------------------------------#
");

            int youramt = 0;
            float itemprice = 0;
            double sellMult = 0;
            for (int j = 0; j < Inventory.Count; j++)
            {
                youramt = 0;
                itemprice = 0;
                sellMult = Inventory[j].storeBuyMultiplier;
                string amtString = Inventory[j].ammount.ToString().PadRight(10);
                itemprice = (float)Math.Round((Inventory[j].baseCost * sellMult), 2);
                youramt += currentInv[j].ammount;
                System.Console.Write(
$@"            # {j}-{Inventory[j].name.PadRight(16)}|  {amtString}| ${itemprice.ToString().PadRight(6)}");
                System.Console.Write(
                    $@"| {youramt.ToString().PadRight(11)}| <Detail>  #
"
                );

            };
            System.Console.Write(

$@"           ##################################################################                      
                    {error.PadRight(52)}
                    Type the name of the Item you wish to sell 
                or check details by adding 'Detail' to the end of the 
                     item name, type Return to exit Sell menu
            ############################################################
             Stats- Gold: {currentPlayer.gold}, Ship: {currentPlayer.currentShip.name}
             Cargo Space: {currentPlayer.currentShip.currentSpace}/{currentPlayer.currentShip.cargoSpace}

    Please make your selection:
");
            string choice = Console.ReadLine();
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (choice == "Return")
                {
                    Console.Clear();
                    return;

                }
                else if (choice == Inventory[i].name || choice == i.ToString())
                {
                    youramt = currentInv[i].ammount;
                    System.Console.WriteLine($"Input how many you would like to sell?(max: {youramt}) (or type cancel)");
                    string qty = System.Console.ReadLine();
                    int sellamt = 0;
                    if (Int32.TryParse(qty, out int parsedInt))
                    {
                        sellamt = parsedInt;
                        if (sellamt > youramt)
                        {
                            Act("You don't have that many...");
                        }
                        else
                        {
                            float totalPrice = sellamt * Inventory[i].purchasePrice;
                            System.Console.WriteLine($"The Total is {totalPrice}, is that ok? y/n");
                            string pending = Console.ReadLine();
                            if (pending == "y")
                            {
                                currentPlayer.gold += totalPrice;
                                Inventory[i].ammount += sellamt;
                                Inventory[i].storeSellMultiplier = Inventory[i].storeBuyMultiplier * 1.05;
                                currentInv[i].ammount -= sellamt;
                                System.Console.WriteLine("Are you done selling? y/n");
                                choice = Console.ReadLine();
                                if (choice == "n")
                                {
                                    Act();
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        Act("That isn't a number...");
                    }
                }
                else
                {
                    Act("You made an invalid selection");
                }
                return;
            }
        }
    }

    public class Travel : Action
    {
        public string name { get; set; }
        public string direction;
        public string description { get; set; }
        public Travel(string Location)
        {
            name = Location;
            description = "Travels to a destination";
        }
        public void Act(string error = "")
        {
            Player currentPlayer = Program.newGame.newPlayer;

            Console.WriteLine(error);
            Console.Clear();

            foreach (Location city in Program.world.availableLocations)
            {
                if (city.name == name && currentPlayer.currentLocation.name == "World Map")
                {
                    Console.Write($@"
            
            {currentPlayer.currentShip.shipArt}
                    You begin sailing towards {name}
            ");
                    currentPlayer.travelDays++;
                    currentPlayer.currentLocation.lastVisited = currentPlayer.travelDays;
                    Console.ReadLine();
                }
            }

            if (name == "World Map")
            {
                currentPlayer.currentLocation.lastVisited = currentPlayer.travelDays;
            }
            foreach (Location place in currentPlayer.currentLocation.availableLocations)
            {
                if (name == place.name && currentPlayer.currentLocation.actions[0].name == "View Stock")
                {
                    currentPlayer.currentLocation.lastVisited = currentPlayer.travelDays;
                }
                if (name == place.name)
                {
                    currentPlayer.currentLocation = place;
                }

            }
            if (currentPlayer.currentLocation.actions.Count == 4)
            {
                if (currentPlayer.currentLocation.lastVisited == 0)
                {
                    currentPlayer.currentLocation.lastVisited = currentPlayer.travelDays;
                }
            }
            if (currentPlayer.travelDays % 5 == 0)
            {
                foreach (Location city in Program.world.availableLocations)
                {
                    foreach (Location shop in city.availableLocations)
                    {
                        if (shop is Shop)
                        {
                            Shop place = (Shop)shop;
                            foreach (Loot item in place.Inventory)
                            {
                                item.refreshStock();
                            }
                        }
                        if (shop is Shipyard)
                        {
                            // Shipyard place = (Shipyard)shop;
                            // place.resetActions();
                        }
                    }
                }
            }
        }
    }
    public class PurchaseShip : Action
    {
        public string name { get; set; }
        public string description { get; set; }
        public Ship forsale;
        public PurchaseShip(Ship ship)
        {

            this.name = "View Available Ship";
            this.description = "View and purchase ship";
            this.forsale = ship;

        }
        public void Act(string error)
        {
            Player currentPlayer = Program.newGame.newPlayer;
            System.Console.Clear();
            System.Console.Write(forsale.shipArt);
            System.Console.Write(
$@"            #                 A brand new {forsale.name.PadRight(12)}                 #
            #   sits at the pier. The captain seems willing to sell    #
            #                       it to you.                         #
            #                                                          #
            ############################################################
            # Ship Class: {forsale.name.PadRight(12)} Hull: {forsale.hullHealth.ToString().PadRight(5)}");
            System.Console.Write($@"  Cannons: {forsale.cannons.ToString().PadRight(10)}#");
            System.Console.Write($@"
            # Crew: {forsale.sailors.ToString().PadRight(3)} CargoSpace: {forsale.cargoSpace.ToString().PadRight(3)}");
            System.Console.Write($@" Price: ${forsale.price.ToString().PadRight(23)}#
            ############################################################
                             {error.PadRight(52)}
                        What do you want to do? <1-Buy><2-Cancel>
            ");
            string choice = System.Console.ReadLine();
            if (choice == "1" || choice == "Buy")
            {
                if (currentPlayer.gold >= forsale.price)
                {
                    System.Console.WriteLine("Are you sure? You will lose any current cargo <y/n>");
                    string confirm = System.Console.ReadLine();
                    if (confirm == "y")
                    {
                        currentPlayer.currentShip = forsale;
                        currentPlayer.gold -= forsale.price;
                    }
                    else
                    {
                        System.Console.WriteLine("Returning to the Shipyard, press any key to continue");
                        System.Console.ReadLine();
                    }
                }
                else
                {
                    System.Console.WriteLine("You don't have enough! Returning to shipyard");
                    System.Console.ReadLine();
                }
            }
            else
            {
                System.Console.WriteLine("Returning to the Shipyard, press any key to continue");
                System.Console.ReadLine();
            }
        }
    }
    public class UpgradeShip : Action
    {
        public string name { get; set; }
        public string description { get; set; }
        public Ship myShip;
        public UpgradeShip()
        {

            this.name = "Purchase Upgrades";
            this.description = "Upgrade your current Ship";


        }
        public void Act(string error)
        {
            Player currentPlayer = Program.newGame.newPlayer;
            this.myShip = currentPlayer.currentShip;
            System.Console.Clear();
            System.Console.Write(myShip.shipArt);
            int cannonPrice = (int)Math.Round((500 * 10 / (myShip.cannonCapacity - myShip.cannons) * myShip.upgradeMult), 0);
            int hullPrice = (int)Math.Round((400 * 10 / (myShip.maxHullHealth - myShip.hullHealth) * myShip.upgradeMult), 0);
            int cargoPrice = (int)Math.Round((600 * 10 / (myShip.maxCargoSpace - myShip.cargoSpace) * myShip.upgradeMult), 0);
            System.Console.Write(
         $@"#        A number of upgrades are available for purchase   #
            #     Browse the options and upgrade your ship as needed   #
            #                                                          #
            ############################################################
            # Current Ship Class: {myShip.name.PadRight(37)}#   
            # Hull:       {myShip.hullHealth.ToString().PadRight(3)}| Max Hull:   {myShip.maxHullHealth.ToString().PadRight(4)}|");
            System.Console.Write($@" +1 Hull Price:   ${hullPrice.ToString().PadRight(4)}#
            ");
            System.Console.Write($@"# Cannons:    {myShip.cannons.ToString().PadRight(3)}| Max Cannons: {myShip.cannonCapacity.ToString().PadRight(3)}|");
            System.Console.Write($@" +1 Cannon Price: ${cannonPrice.ToString()}#
            # CargoSpace: {myShip.cargoSpace.ToString().PadRight(3)}| Max Space:   {myShip.maxCargoSpace.ToString().PadRight(3)}|");
            System.Console.Write($@" +1 Cargo Price:  ${cargoPrice.ToString()}#
            ############################################################
              Current Gold: {currentPlayer.gold}
                             {error.PadRight(52)}
                        What do you want to Upgrade? 
                     <1-Hull><2-Cannon><3-Cargo><4-Cancel>

            ");
            string choice = System.Console.ReadLine();
            if (choice == "1" || choice == "Hull")
            {
                if (currentPlayer.gold >= hullPrice && myShip.hullHealth < myShip.maxHullHealth)
                {

                    System.Console.WriteLine($"Total price = {hullPrice}, are you sure? <y/n>");
                    string confirm = System.Console.ReadLine();
                    if (confirm == "y")
                    {
                        myShip.hullHealth += 1;
                        currentPlayer.gold -= hullPrice;
                    }
                    else
                    {
                        System.Console.WriteLine("Returning to the Shipyard, press any key to continue");
                        System.Console.ReadLine();
                    }
                }
                else
                {
                    System.Console.WriteLine("You don't have have the resources or space! Returning to shipyard");
                    System.Console.ReadLine();
                }
            }
            else if (choice == "2" || choice == "Cannon")
            {
                if (currentPlayer.gold >= cannonPrice && myShip.cannons < myShip.cannonCapacity)
                {
                    System.Console.WriteLine($"Total price = {cannonPrice}, are you sure? <y/n>");
                    string confirm = System.Console.ReadLine();
                    if (confirm == "y")
                    {
                        myShip.cannons += 1;
                        currentPlayer.gold -= cannonPrice;
                    }
                    else
                    {
                        System.Console.WriteLine("Returning to the Shipyard, press any key to continue");
                        System.Console.ReadLine();
                    }
                }
                else
                {
                    System.Console.WriteLine("You don't have have the resources or space! Returning to shipyard");
                    System.Console.ReadLine();
                }
            }
            else if (choice == "3" || choice == "Cargo")
            {
                if (currentPlayer.gold >= cargoPrice && myShip.cargoSpace < myShip.maxCargoSpace)
                {
                    System.Console.WriteLine($"Total price = {cargoPrice}, are you sure? <y/n>");
                    string confirm = System.Console.ReadLine();
                    if (confirm == "y")
                    {
                        myShip.cargoSpace += 1;
                        currentPlayer.gold -= cargoPrice;
                    }
                    else
                    {
                        System.Console.WriteLine("Returning to the Shipyard, press any key to continue");
                        System.Console.ReadLine();
                    }
                }
                else
                {
                    System.Console.WriteLine("You don't have have the resources or space! Returning to shipyard");
                    System.Console.ReadLine();
                }
            }
            else
            {
                System.Console.WriteLine("Returning to the Shipyard, press any key to continue");
                System.Console.ReadLine();
            }
        }
    }
    public class Recruit : Action
    {

        public string name { get; set; }
        public string description { get; set; }
        public Recruit()
        {
            name = "Hire sailors";
            description = "Chat with sailors and hire them to your crew";
        }
        public void Act(string error)

        {
            Player currentPlayer = Program.newGame.newPlayer;
            System.Console.Clear();

            System.Console.Write($@"
            ############################################################
            #        A number of sailors are drinking at the bar.      #
            #     Would you like to hire any of them for your crew?    #
            #                  Hire Cost: 300 gold;                    #
            #                    <0-hire><1-cancel>                    #
            ############################################################
            ");
            string choice = Console.ReadLine();
            if (choice == "0" || choice == "hire")
            {
                if (currentPlayer.gold < 300)
                {
                    System.Console.WriteLine("You don't have enough gold for that. Press any key to leave");
                    System.Console.ReadLine();
                    return;
                }
                else if (currentPlayer.currentShip.sailors >= currentPlayer.currentShip.maxSailors)
                {
                    System.Console.WriteLine("Your ship doesn't have the rooms. Press any key to leave");
                    System.Console.ReadLine();
                    return;
                }
                else
                {
                    currentPlayer.currentShip.sailors += 1;
                    currentPlayer.gold -= 300;
                    System.Console.WriteLine("The hired sailor finishes his drink and heads to your ship");
                    Console.ReadLine();
                    return;
                }
            }
            System.Console.WriteLine("You return to your seat at the bar");
            Console.ReadLine();
            return;
        }
    }
    public class Barkeep : Action
    {
        public string name { get; set; }
        public string description { get; set; }
        public Barkeep()
        {
            name = "Chat with bartender";
            description = "Chat with bartender to find work";
        }
        public void Act(string error)
        {
            Player currentPlayer = Program.newGame.newPlayer;
            System.Console.Clear();

            System.Console.Write($@"
            ############################################################
            #        You approach the bar and catch the eye of         #
            #    the bartender, they will probably have work available #
            #             or may know of some good rumors.             #
            #     <0-Ask about rumors><1-Ask about work><2-return>     #
            ############################################################
            ");
            string choice = Console.ReadLine();
            if (choice == "0")
            {
                System.Console.WriteLine(getRumor());
                System.Console.ReadLine();
            }
            else if (choice == "1")
            {
                Quest availQuest = QuestList.questRandomizer();
                System.Console.WriteLine("Someone stopped by and posted some work have a look!");
                System.Console.Write(availQuest.Instructions);
                System.Console.WriteLine("Do you want to take on this work? <y><n>");
                string opt = Console.ReadLine();
                {
                    if (opt == "y")
                    {
                        currentPlayer.questHistory.currentQuest = availQuest;
                        if (availQuest.type == "Fetch")
                        {
                            availQuest.pickuplocation.actions.Add(new PickUp());
                        }
                        availQuest.targetlocation.actions.Add(new turnIn());
                        System.Console.WriteLine("You agree to take the job and return to your seat");
                        Console.ReadLine();
                        return;
                    }
                }
            }
            else
            {
                System.Console.WriteLine("You return to your seat at the bar");
                Console.ReadLine();
                return;
            }
        }
        public string getRumor()
        {
            Location randcity = Program.world.availableLocations[Program.rand.Next(0, 5)];
            double highSell = 0;
            string highsellitem = "";
            double lowBuy = 100;
            string highBuyItem = "";
            Shop shop = (Shop)randcity.availableLocations[0];
            foreach (Loot item in shop.Inventory)
            {
                if (item.purchasePrice / item.baseCost > highSell)
                {
                    highSell = item.purchasePrice/item.baseCost;
                    highsellitem = item.name;
                }
                if (item.purchasePrice / item.baseCost < lowBuy)
                {
                    lowBuy = item.purchasePrice/item.baseCost;
                    highBuyItem = item.name;
                }
            }
            if (Program.rand.Next(0, 2) == 1)
            {
                return $@"It looks like {randcity.name} is in short supply of {highsellitem}, 
                            any trader stocking {highsellitem} could make a fortune";
            }
            else
            {
                return $@"It looks like {randcity.name} is overstocked on {highsellitem}, 
                            if you've got the cargo space, you can get a great deal!";
            }
        }
    }
    public class turnIn : Action
    {
        public string name { get; set; }
        public string description { get; set; }
        public turnIn()
        {
            name = "Turn in Quest";
            description = "Turn in Quest";
        }
        public void Act(string error)
        {
            Player player = Program.newGame.newPlayer;
            if (player.questHistory.currentQuest.QuestItem != null)
            {
                System.Console.Write(@"You hand over the requested items and recieve your payment,
                    The Client seems pleased");
                player.questHistory.allQuests.Add(Program.newGame.newPlayer.questHistory.currentQuest);
                player.gold += player.questHistory.currentQuest.reward;
                player.currentLocation.actions.Remove(this);
                player.questHistory.currentQuest.QuestItem = null;
                player.questHistory.currentQuest = null;
                System.Console.ReadLine();
                return;
            }
            else
            {
                System.Console.WriteLine("You don't have the required item. You need to pick it up first");
                System.Console.ReadLine();
                return;
            }
        }
    }
    public class PickUp : Action
    {
        public string name { get; set; }
        public string description { get; set; }
        public QI pickup;
        public PickUp()
        {
            name = "Pick up Package";
            description = "pick up Package";
        }
        public void Act(string error)
        {
            Player player = Program.newGame.newPlayer;

            System.Console.Write(@"You speak to your contact and retrieve the package");
            player.questHistory.currentQuest.QuestItem = new QI("Package");
            player.currentLocation.actions.Remove(this);
            System.Console.ReadLine();
            return;


        }
    }
}