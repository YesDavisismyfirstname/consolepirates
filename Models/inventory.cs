using System.Collections.Generic;
using System;
namespace consolepirates.Models
{
    public interface ILootable
    {
        string name {get;set;}
        int DisplayCost {get;set;} 
        int DisplaySellPrice {get;set;}
    }
    abstract public class Loot : ILootable {
        public string name{get;set;}
        public string description;
        public int inventorySpace;
        public int ammount;
        protected int baseCost;
        public int StoreStock;
        protected double storeSellMultiplier;
        protected double storeBuyMultiplier;
        protected double StockMultiplier;
        public int DisplayCost {get;set;} 
        public int DisplaySellPrice{get;set;}

        abstract public void buyItem(int quantity);
    }
    public class Fern: Loot
    {
        public Fern(int ammount)
        {
            name = "Fern";
            description = @"A very common plant located across the world,
            who knows why they're even worth anything.";
            baseCost = 10;
            StockMultiplier = .02;
            this.ammount = ammount;
            // DisplayCost = (int)(AmmountInStore * storeSellMultiplier);
        }
        public override void buyItem(int quantity){
            System.Console.WriteLine("Input how many you would like to buy?");
            string qty = System.Console.ReadLine();
            int purchaseamt = 0;
            if (Int32.TryParse(qty, out int numValue))
            {
            purchaseamt = numValue;
            if(purchaseamt > ammount){
                System.Console.WriteLine("Thats more than is in the store try again!");
                Program.newGame.newPlayer.currentLocation.displayInfo();
            }
            int currentload = Program.newGame.newPlayer.currentShip.currentCargo.Count;
            int spaceAvailable = Program.newGame.newPlayer.currentShip.cargoSpace - currentload;
            if(purchaseamt < spaceAvailable*inventorySpace){
                while(purchaseamt >0) {
                    if(purchaseamt > inventorySpace)
                    {
                    Program.newGame.newPlayer.currentShip.currentCargo.Add(new Fern(inventorySpace));
                    purchaseamt = purchaseamt - inventorySpace;
                    } else {
                        Program.newGame.newPlayer.currentShip.currentCargo.Add(new Fern(purchaseamt));
                        purchaseamt = purchaseamt - purchaseamt;
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
    public class Orchid: Loot
    {
        public Orchid(int amount)
        {
            name = "Orchid";
            description = @"A good looking plant that enjoys the simplier things
            in life, like Pina Coladas and its roots in the dirt.";
            baseCost = 20;
            StockMultiplier = .02;
            this.ammount = ammount;
            //DisplayCost = (int)(AmmountInStore * storeSellMultiplier);
        }
        public override void buyItem(int quantity){
            System.Console.WriteLine("Input how many you would like to buy?");
            string qty = System.Console.ReadLine();
            int purchaseamt = 0;
            if (Int32.TryParse(qty, out int numValue))
            {
            purchaseamt = numValue;
            if(purchaseamt > ammount){
                System.Console.WriteLine("Thats more than is in the store try again!");
                Program.newGame.newPlayer.currentLocation.displayInfo();
            }
            int currentload = Program.newGame.newPlayer.currentShip.currentCargo.Count;
            int spaceAvailable = Program.newGame.newPlayer.currentShip.cargoSpace - currentload;
            if(purchaseamt < spaceAvailable*inventorySpace){
                while(purchaseamt >0) {
                    if(purchaseamt > inventorySpace)
                    {
                    Program.newGame.newPlayer.currentShip.currentCargo.Add(new Orchid(inventorySpace));
                    purchaseamt = purchaseamt - inventorySpace;
                    } else {
                        Program.newGame.newPlayer.currentShip.currentCargo.Add(new Orchid(purchaseamt));
                        purchaseamt = purchaseamt - purchaseamt;
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
    public class Sunflower: Loot
    {
        public Sunflower(int ammount)
        {
            name = "Sunflower";
            description = @"A shining plant that will help you
            defend your lawn from unwanted guests.";
            baseCost = 30;
            StockMultiplier = .02;
            this.ammount = ammount;
            //DisplayCost = (int)(AmmountInStore * storeSellMultiplier);
        }
        public override void buyItem(int quantity){
            System.Console.WriteLine("Input how many you would like to buy?");
            string qty = System.Console.ReadLine();
            int purchaseamt = 0;
            if (Int32.TryParse(qty, out int numValue))
            {
            purchaseamt = numValue;
            if(purchaseamt > ammount){
                System.Console.WriteLine("Thats more than is in the store try again!");
                Program.newGame.newPlayer.currentLocation.displayInfo();
            }
            int currentload = Program.newGame.newPlayer.currentShip.currentCargo.Count;
            int spaceAvailable = Program.newGame.newPlayer.currentShip.cargoSpace - currentload;
            if(purchaseamt < spaceAvailable*inventorySpace){
                while(purchaseamt >0) {
                    if(purchaseamt > inventorySpace)
                    {
                    Program.newGame.newPlayer.currentShip.currentCargo.Add(new Sunflower(inventorySpace));
                    purchaseamt = purchaseamt - inventorySpace;
                    } else {
                        Program.newGame.newPlayer.currentShip.currentCargo.Add(new Sunflower(purchaseamt));
                        purchaseamt = purchaseamt - purchaseamt;
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
    public class Coconut: Loot
    {
        public Coconut(int ammount)
        {
            name = "Coconut";
            description = @"Not actually a nut, technically it's a drupe
            which is a fruit with fleshiness on the middle and 
            a hard shell on the outside, but you already knew that.";
            baseCost = 40;
            StockMultiplier = .02;
            this.ammount = ammount;
            //DisplayCost = (int)(AmmountInStore * storeSellMultiplier);
        }
        public override void buyItem(int quantity){
            System.Console.WriteLine("Input how many you would like to buy?");
            string qty = System.Console.ReadLine();
            int purchaseamt = 0;
            if (Int32.TryParse(qty, out int numValue))
            {
            purchaseamt = numValue;
            if(purchaseamt > ammount){
                System.Console.WriteLine("Thats more than is in the store try again!");
                Program.newGame.newPlayer.currentLocation.displayInfo();
            }
            int currentload = Program.newGame.newPlayer.currentShip.currentCargo.Count;
            int spaceAvailable = Program.newGame.newPlayer.currentShip.cargoSpace - currentload;
            if(purchaseamt < spaceAvailable*inventorySpace){
                while(purchaseamt >0) {
                    if(purchaseamt > inventorySpace)
                    {
                    Program.newGame.newPlayer.currentShip.currentCargo.Add(new Coconut(inventorySpace));
                    purchaseamt = purchaseamt - inventorySpace;
                    } else {
                        Program.newGame.newPlayer.currentShip.currentCargo.Add(new Coconut(purchaseamt));
                        purchaseamt = purchaseamt - purchaseamt;
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
    public class Redwood: Loot
    {
        public Redwood(int ammount)
        {
            name = "Redwood";
            description = @"Tallest Species of tree in the world. 
            It Grows in California so there is some confusion as 
            to how it became available in Carribean markets";
            baseCost = 50;
            StockMultiplier = .02;
            this.ammount = ammount;
            //DisplayCost = (int)(AmmountInStore * storeSellMultiplier);
        }
        public override void buyItem(int quantity){
            System.Console.WriteLine("Input how many you would like to buy?");
            string qty = System.Console.ReadLine();
            int purchaseamt = 0;
            if (Int32.TryParse(qty, out int numValue))
            {
            purchaseamt = numValue;
            if(purchaseamt > ammount){
                System.Console.WriteLine("Thats more than is in the store try again!");
                Program.newGame.newPlayer.currentLocation.displayInfo();
            }
            int currentload = Program.newGame.newPlayer.currentShip.currentCargo.Count;
            int spaceAvailable = Program.newGame.newPlayer.currentShip.cargoSpace - currentload;
            if(purchaseamt < spaceAvailable*inventorySpace){
                while(purchaseamt >0) {
                    if(purchaseamt > inventorySpace)
                    {
                    Program.newGame.newPlayer.currentShip.currentCargo.Add(new Redwood(inventorySpace));
                    purchaseamt = purchaseamt - inventorySpace;
                    } else {
                        Program.newGame.newPlayer.currentShip.currentCargo.Add(new Redwood(purchaseamt));
                        purchaseamt = purchaseamt - purchaseamt;
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
    public class Papaya: Loot
    {
        public Papaya(int ammount)
        {
            name = "Papaya";
            description = @"A very healthy plant that most moms would
            advise you to eat, but you're still not going too.";
            baseCost = 75;
            StockMultiplier = .02;
            this.ammount = ammount;
            //DisplayCost = (int)(AmmountInStore * storeSellMultiplier);
        }
        public override void buyItem(int quantity){
            System.Console.WriteLine("Input how many you would like to buy?");
            string qty = System.Console.ReadLine();
            int purchaseamt = 0;
            if (Int32.TryParse(qty, out int numValue))
            {
            purchaseamt = numValue;
            if(purchaseamt > ammount){
                System.Console.WriteLine("Thats more than is in the store try again!");
                Program.newGame.newPlayer.currentLocation.displayInfo();
            }
            int currentload = Program.newGame.newPlayer.currentShip.currentCargo.Count;
            int spaceAvailable = Program.newGame.newPlayer.currentShip.cargoSpace - currentload;
            if(purchaseamt < spaceAvailable*inventorySpace){
                while(purchaseamt >0) {
                    if(purchaseamt > inventorySpace)
                    {
                    Program.newGame.newPlayer.currentShip.currentCargo.Add(new Papaya(inventorySpace));
                    purchaseamt = purchaseamt - inventorySpace;
                    } else {
                        Program.newGame.newPlayer.currentShip.currentCargo.Add(new Papaya(purchaseamt));
                        purchaseamt = purchaseamt - purchaseamt;
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
    
    public class Cactus: Loot
    {
        public Cactus(int ammount)
        {
            name = "Golf Ball Cactus";
            description = @"A very rare and endagered plant,
            its home habitat is the hot desserts of Mexico";
            baseCost = 100;
            StockMultiplier = .02;
            this.ammount = ammount;
            //DisplayCost = (int)(AmmountInStore * storeSellMultiplier);
        }
        public override void buyItem(int quantity){
            System.Console.WriteLine("Input how many you would like to buy?");
            string qty = System.Console.ReadLine();
            int purchaseamt = 0;
            if (Int32.TryParse(qty, out int numValue))
            {
            purchaseamt = numValue;
            if(purchaseamt > ammount){
                System.Console.WriteLine("Thats more than is in the store try again!");
                Program.newGame.newPlayer.currentLocation.displayInfo();
            }
            int currentload = Program.newGame.newPlayer.currentShip.currentCargo.Count;
            int spaceAvailable = Program.newGame.newPlayer.currentShip.cargoSpace - currentload;
            if(purchaseamt < spaceAvailable*inventorySpace){
                while(purchaseamt >0) {
                    if(purchaseamt > inventorySpace)
                    {
                    Program.newGame.newPlayer.currentShip.currentCargo.Add(new Cactus(inventorySpace));
                    purchaseamt = purchaseamt - inventorySpace;
                    } else {
                        Program.newGame.newPlayer.currentShip.currentCargo.Add(new Cactus(purchaseamt));
                        purchaseamt = purchaseamt - purchaseamt;
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