using System.Collections.Generic;
namespace consolepirates.Models
{
    public interface ILootable
    {
        string name {get;set;}
        int DisplayCost {get;set;} 
    }
    abstract class Loot : ILootable {
        public string name{get;set;}
        public int inventorySpace;
        public int ammount;
        private int baseCost;
        private float storeSellMultiplier;
        private float storeBuyMultiplier;
        private float storeStockMultiplier;
        public int DisplayCost {get;set;} 
    }
}