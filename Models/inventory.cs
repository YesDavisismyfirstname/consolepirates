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
    public class Redwood: Loot
    {
        public Redwood(int AmmountInStore, double storeSellMultiplier, double storeBuyMultiplier)
        {
            name = "Redwood";
            description = @"Tallest Species of tree in the world. 
            It Grows in California so there is some confusion as 
            to how it became available in Carribean markets";
            baseCost = 50;
            StockMultiplier = .02;
            StoreStock = AmmountInStore;
            DisplayCost = (int)(AmmountInStore * storeSellMultiplier);
        }
    }
}