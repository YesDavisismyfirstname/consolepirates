using System.Collections.Generic;
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
    }
}