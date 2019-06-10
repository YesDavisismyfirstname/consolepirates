using System.Collections.Generic;
using System;
namespace consolepirates.Models
{
    public interface ILootable
    {
        string name { get; set; }
        string description { get; set; }
        int ammount { get; set; }
        int inventorySpace { get; set; }

    }
    public class Loot : ILootable
    {
        public int id;
        public string name { get; set; }
        public string description { get; set; }
        public int inventorySpace { get; set; }
        public int ammount { get; set; }
        public int baseCost {get; set;}
        public int baseStock;
        public int rarity;
        public double storeSellMultiplier;
        public double storeBuyMultiplier;
        public float purchasePrice { get; set; }
        public Loot(string name){
            this.name = name;
        }
        public Loot(int id,string name, string description, int ammount, int rarity, int reqSpace, int baseCost, float price)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.ammount = ammount;
            this.rarity = rarity;
            this.inventorySpace = reqSpace;
            this.baseCost = baseCost;
            this.purchasePrice = price;
        }
        public Loot(int id,string name, string description, int ammount, int reqSpace)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.ammount = ammount;
            this.inventorySpace = reqSpace;

        }

        public Loot(int id,string name, string description, int baseCost, int rarity, int reqSpace, int baseStock)
        {
            // System.Console.WriteLine($"Creating Loot Item {name} r={rarity}");
            this.id = id;
            this.name = name;
            this.description = description;
            this.baseCost = baseCost;
            this.rarity = rarity;
            this.baseStock = baseStock;
            this.inventorySpace = reqSpace;
            refreshStock();
        }
        public void refreshStock()
        {
            int instock = Program.rand.Next(0, 4);
            // System.Console.WriteLine($"Is in stock {instock}");
            if (instock == 0)
            {
                ammount = 0;
            }
            else
            {
            ammount = Program.rand.Next(1, baseStock * 4);
            // System.Console.WriteLine($"{ammount}{name}");
                        // System.Console.WriteLine(storeBuyMultiplier);
            }
            int power = (ammount >0) ? ammount: 1;
            this.storeSellMultiplier = Math.Pow((1-((rarity * rarity * rarity) * .0003)), power);
            purchasePrice = (float)(storeSellMultiplier * baseCost);
            this.storeBuyMultiplier = storeSellMultiplier;         
        }
        public void buyItem(float price)
        {
            System.Console.WriteLine("Input how many you would like to buy? (or type cancel)");
            string qty = System.Console.ReadLine();
            int purchaseamt = 0;
            Ship playerShip = Program.newGame.newPlayer.currentShip;
            if (Int32.TryParse(qty, out int numValue))
            {
                purchaseamt = numValue;
                float totalPrice = purchaseamt * price;
                System.Console.WriteLine($"The Total is {totalPrice}, is that ok? y/n");
                string pending = Console.ReadLine();
                if(pending == "n"){
                    return;
                }
                if (purchaseamt * price > Program.newGame.newPlayer.gold){
                    System.Console.WriteLine("You Don't have enough money!");
                    System.Console.ReadLine();
                    return;
                }
                if (purchaseamt > ammount)
                {
                    System.Console.WriteLine("Thats more than is in the store try again!");
                    buyItem(price);
                }
                // System.Console.WriteLine(Program.newGame.newPlayer);
                int currentload = playerShip.currentSpace ;
                int spaceAvailable = playerShip.cargoSpace - currentload;
                if (purchaseamt < spaceAvailable * inventorySpace)
                {   
                    this.ammount = ammount - purchaseamt;
                    playerShip.cargoSpace += (int)Math.Ceiling((decimal)(purchaseamt / inventorySpace));
                    System.Console.WriteLine(this.id);
                    System.Console.WriteLine(playerShip.currentCargo[0]);
                    playerShip.currentCargo[this.id].ammount += purchaseamt;
                
            
        
                    // while (purchaseamt > 0)
                    // {
                    //     if (purchaseamt > inventorySpace)
                    //     {
                    //         playerShip.currentCargo.Add(new Loot(name, description, inventorySpace, rarity, inventorySpace, baseCost, price));
                    //         purchaseamt = purchaseamt - inventorySpace;
                    //     }
                    //     else
                    //     {
                    //         playerShip.currentCargo.Add(new Loot(name, description, purchaseamt, rarity, inventorySpace, baseCost, price));
                    //         purchaseamt = purchaseamt - purchaseamt;
                    //     }
                    // }

                    System.Console.WriteLine("Thank you for your purchase");
                    Program.newGame.newPlayer.gold -= totalPrice;
                    int power = (ammount >0) ? ammount: 1;
                    this.storeSellMultiplier = Math.Pow((1-((rarity * rarity * rarity) * .0003)), power);
                    purchasePrice = (float)(storeSellMultiplier * baseCost);
                    return;
                }
                else
                {
                    Console.WriteLine($"You Don't have enough room for that");
                    buyItem(price);
                }
            } else if (qty != "cancel"){
                Console.WriteLine("That isn't a number...");
                buyItem(price);
            } else {    
                return;
            }
        }    
    }
    public class QI : Loot
    {
        public QI(string name) : base(name)
        {
            id = 10;
        }
    }
}
    