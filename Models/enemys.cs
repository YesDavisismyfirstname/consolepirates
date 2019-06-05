using System.Collections.Generic;
using System;
namespace consolepirates.Models
{
    
    public class EnemySkipper : Skipper
    {
        public EnemySkipper(string name) : base (name)
        {
            cannons = Program.rand.Next(1,3);
            currentCargo = new List<ILootable>();
            randomInventory();
            
        }
    }
    public class EnemyHauler : Hauler
    {
        public EnemyHauler(string name) : base (name)
        {
            cannons = Program.rand.Next(2,4);
            currentCargo = new List<ILootable>();
            randomInventory();
        }
    }
    public class EnemyFighter : Fighter
    {
        public EnemyFighter(string name) : base (name)
        {
            cannons = Program.rand.Next(3,6);
            currentCargo = new List<ILootable>();
            randomInventory();
        }
    }
    public class EnemyNautilous : Nautilous
    {
        public EnemyNautilous(string name) : base (name)
        {
            cannons = Program.rand.Next(8,12);
            currentCargo = new List<ILootable>();
            randomInventory();
        }
    }
}